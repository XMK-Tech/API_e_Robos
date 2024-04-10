using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace AgilleApi.Domain.Services.Commom;

public class AgiprevCrawlerServices : IAgiprevCrawlerServices
{
    private readonly ImportFileFetcher _fetcher;
    private readonly ICrawlerFileRepository _repository;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IRelatedEntityServices _relatedEntityServices;
    private readonly IVerificationServices _verificationServices;
    private readonly IAttachmentServices _attachmentServices;

    private readonly IRevenueRepository _revenueRepository;
    private readonly IFPMLaunchRepository _fpmLaunchRepository;
    private readonly IExpenseRepository _expenseRepository;
    private readonly ICollectionRepository _collectionRepository;

    private readonly string CRAWLER_EXECUTE_PATH;

    public AgiprevCrawlerServices(
        ImportFileFetcher fetcher,
        ICrawlerFileRepository repository,
        IEntitiesServices entitiesServices,
        IRelatedEntityServices relatedEntityServices,
        IVerificationServices verificationServices,
        IRevenueRepository revenueRepository,
        IFPMLaunchRepository fpmLaunchRepository,
        IExpenseRepository expenseRepository,
        ICollectionRepository collectionRepository,
        IAttachmentServices attachmentServices,
        IConfiguration configuration)
    {
        _fetcher = fetcher;
        _repository = repository;
        _entitiesServices = entitiesServices;
        _relatedEntityServices = relatedEntityServices;
        _verificationServices = verificationServices;

        _revenueRepository = revenueRepository;
        _fpmLaunchRepository = fpmLaunchRepository;
        _expenseRepository = expenseRepository;
        _collectionRepository = collectionRepository;
        _attachmentServices = attachmentServices;

        CRAWLER_EXECUTE_PATH = configuration["CrawlerPath"];
    }

    private string CreateCommand<T>(DateTime reference)
    {
        var agiprevEntityContent = _entitiesServices.View()?.Agiprev;
        ThrowExceptionIfConfigurationNotFound(agiprevEntityContent);

        var documentsList = agiprevEntityContent.Documents;
        var documents = string.Join(';', documentsList);

        var ipmUrl = agiprevEntityContent.IPMUrl;
        var fpmUrl = agiprevEntityContent.FPMUrl;

        var EstadoSigla = agiprevEntityContent.EstadoSigla;
        var MunicipioName = agiprevEntityContent.MunicipioNome;
        var cityComand = $"{MunicipioName.ToUpper()} - {EstadoSigla}";

        var competence = reference.ToShortDateString();
        var cityName = MunicipioName; 

        Dictionary<string, string> @params = new()
        {
            { "baseIPMUrl", ipmUrl },
            { "baseFPMUrl", fpmUrl },
            { "cityName", cityName },
            { "cityComand", cityComand },
            { "sanitizedName", cityName.RemoveDiacriticsAndSanitize() },
            { "Documents", documents },
            { "reference", competence },
            { "Document", "00.394.460/0001-41" },
            { "Creditor", "MINISTÉRIO DA ECONOMIA" },
            { "ExpenseDescription", "Contribuição para o PIS/PASEP" },
            { "action", ActionSelector<T>() }
        };

        return BuildCrawlerCommand(@params);
    }

    private static string ActionSelector<T>()
    {
        var type = typeof(T).Name.Replace("InsertUpdateViewModel", "").ToLower();

        var action = type switch
        {
            "fpm" => "fpm",
            "expense" => "expense",
            "collection" => "collection",
            "revenue" => "revenue",
            _ => throw new NotImplementedException()
        };

        return action;
    }

    private static void ThrowExceptionIfConfigurationNotFound(object configuration)
    {
        if (configuration == null)
            throw new NotFoundException("Configurações do robo não encontradas.");
    }

    public List<T> Import<T>(DateTime competence)
    {
        var commandParams = CreateCommand<T>(competence);

        var json = ExecuteCrawler(commandParams);
        var crawlerFile = CreateCrawlerFile<T>(competence, json);

        OverridePreviousCompetenceImport(crawlerFile);
        _verificationServices.InsertCompetenceIfNotExists(competence);

        return ParseJson<T>(json, crawlerFile.Id);
    }

private static string ExecuteCrawler(string parameters)
{
    // Construir o objeto de parâmetros para a chamada da API
    var requestData = new
    {
        commands = parameters
    };

    // Converter o objeto de parâmetros em uma string JSON
    var jsonRequest = JsonConvert.SerializeObject(requestData);

    try
    {
        // Configurar a solicitação HTTP
        var request = (HttpWebRequest)WebRequest.Create("https://us-central1-xmktec.cloudfunctions.net/agiprev-crawler-consulta-banco");
        request.Method = "POST";
        request.ContentType = "application/json";

        // Definir o tempo limite (timeout) da solicitação para 50 segundos
        request.Timeout = 480000; // 50 segundos em milissegundos

        // Escrever os dados da solicitação no corpo da requisição
        using (var streamWriter = new StreamWriter(request.GetRequestStream()))
        {
            streamWriter.Write(jsonRequest);
        }

        // Fazer a solicitação e obter a resposta
        var response = (HttpWebResponse)request.GetResponse();

        // Ler a resposta da API
        using (var streamReader = new StreamReader(response.GetResponseStream()))
        {
            var jsonResponse = streamReader.ReadToEnd();
            return jsonResponse;
        }
    }
    catch (WebException ex)
    {
        using (var stream = ex.Response.GetResponseStream())
        using (var reader = new StreamReader(stream))
        {
            // Obter detalhes da resposta de erro
            var errorMessage = reader.ReadToEnd();

            // Registrar o erro ou realizar ações adicionais com a mensagem de erro
        }

        // Tratar a exceção ou lançar novamente com mais detalhes
        throw new Exception($"Erro ao executar o crawler. Detalhes: {ex.Message}", ex);
    }
}


    private CrawlerFile FindFile(string entity, DateTime competence)
    {
        entity = entity.Replace("InsertUpdateViewModel", "");

        return _repository
                .Query()
                .Where(x => !x.WasImported)
                .Where(x => x.DataDescription.ToLower() == entity.ToLower())
                .Where(x => x.Competence.Year == competence.Year && x.Competence.Month == competence.Month)
                .OrderByDescending(x => x.CreatedAt)
                .FirstOrDefault();
    }

    private CrawlerFile CreateCrawlerFile<Type>(DateTime competence, string content)
    {
        var typeName = typeof(Type).Name.Replace("InsertUpdateViewModel", "");
        var sanitizedCompetence = competence.ToString("dd-MM-yy_HH-mm");

        var bytes = Encoding.UTF8.GetBytes(content);
        var fileName = $"{typeName}_{sanitizedCompetence}";
        var contentType = "application/json";

        var attachment = _attachmentServices.InsertByBytes(bytes, fileName, contentType, "crawler", "crawlerId");

        var entity = new CrawlerFile(attachment.Id, typeName, competence)
        {
            WasImported = true
        };
        _repository.Insert(entity);

        return entity;
    }

    private void OverridePreviousCompetenceImport(CrawlerFile newImport)
    {
        var previousCompetences = FindEntitiesToBeReverted(newImport);
        if (!previousCompetences.Any())
            return;

        previousCompetences.ForEach(RevertCompetence);

        _repository.UpdateMany(previousCompetences);
    }

    private void RevertCompetence(CrawlerFile previousImport)    
    {
        previousImport.WasReverted = true;
        _repository.Update(previousImport);

    }

private List<CrawlerFile> FindEntitiesToBeReverted(CrawlerFile newImport)
{
    var competence = newImport.Competence;

    // Verifica se a descrição do arquivo é diferente da descrição dos arquivos no banco de dados
    if 
    (
        _repository.Query().Any(file => file.WasImported && file.DataDescription.ToLower() == newImport.DataDescription.ToLower() && 
        file.Competence.Year == newImport.Competence.Year && 
        file.Competence.Month == newImport.Competence.Month)
    )
    {
        // Se a descrição já existe no banco de dados, retorna uma lista vazia para indicar que nenhum arquivo precisa ser revertido
        return new List<CrawlerFile>();
    }

    // Se a descrição não existe no banco de dados, retorna todos os arquivos com a mesma competência para serem revertidos, se houver algum
    return _repository
            .Query()
            .Include(file => file.Revenues)
            .Include(file => file.FPMLaunches)
            .Include(file => file.Expenses)
            .Include(file => file.Collections)
            .Where(file => file.WasImported &&
                           file.Id != newImport.Id &&
                           file.Competence.Year == newImport.Competence.Year &&
                           file.Competence.Month == newImport.Competence.Month)
            .OrderByDescending(file => file.CreatedAt)
        .ToList();
}

    private static string BuildCrawlerCommand(Dictionary<string, string> @params)
    {
        var formattedParams = @params.Select(ConcatParameter).ToList();
        var parameters = string.Join(' ', formattedParams);
        return parameters;
    }

    private static string ConcatParameter(KeyValuePair<string, string> pair)
    {
        return $"\"{pair.Key}={pair.Value}\"";
    }

    private string GetCityName()
    {
        return _entitiesServices?.View()?.Address?.CityName;
    }

    private List<T> ParseJson<T>(string json, Guid crawlerFileId)
    {
        var entities = new List<T>();

        var jsonArray = JArray.Parse(json).ToList();

        jsonArray.ForEach(item =>
        {
            try
            {
                var entity = item.ToObject<T>();
                entities.Add(entity);
            }
            catch
            {
                // Error when converting to object, will be ignored...
            }
        });

        SetRelatedEntityId(entities);
        SetEntitiesCrawlerFileId(entities, crawlerFileId);

        return entities;
    }

    private void SetRelatedEntityId<T>(List<T> importLines)
    {
        var cityName = GetCityName().RemoveDiacritics();
        var currentTenantName = $"municipio de {cityName}";

        Dictionary<string, Guid?> relatedEntities = new();

        foreach (var item in importLines)
        {
            dynamic dynamicItem = item;

            if (!DynamicExtensions.HasProperty(dynamicItem, "EntityName"))
                continue;

            var entityName = (dynamicItem?.EntityName as string)?.RemoveDiacritics();

            if (string.IsNullOrEmpty(entityName))
                continue;

            if (entityName.Contains(currentTenantName))
            {
                dynamicItem.IsFromMainEntity = true;
            }
            else if (relatedEntities.ContainsKey(entityName))
            {
                dynamicItem.RelatedEntityId = relatedEntities[entityName];
            }
            else
            {
                var entityId = _relatedEntityServices.FindIdByName(entityName);

                dynamicItem.RelatedEntityId = entityId;
                relatedEntities[entityName] = entityId;
            }
        }
    }

    private static void SetEntitiesCrawlerFileId<T>(List<T> importEntities, Guid crawlerFileId)
    {
        foreach (var item in importEntities)
        {
            dynamic dynamicItem = item;
            dynamicItem.CrawlerFileId = crawlerFileId;
        }
    }

    private static CrawlerFile ConvertToEntity(AgiprevCrawlerFileInsertViewModel model)
    {
        return new CrawlerFile(model.AttachmentId, model.DataDescription, model.Competence);
    }

    private static CrawlerFile ConvertToEntity(AgiprevCrawlerItemViewModel model, DateTime competence)
    {
        return new CrawlerFile(model.AttachmentId, model.DataDescription, competence);
    }
}
