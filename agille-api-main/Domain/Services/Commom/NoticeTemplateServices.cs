using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;

namespace AgilleApi.Domain.Services.Commom;

public class NoticeTemplateServices : Notifications, INoticeTemplateServices
{
    private readonly INoticeTemplateRepository _repository;
    private readonly HTMLServices htmlServices;

    private static readonly List<string> APIFields = new()
    {
        "@observacao",
        "@dataAtual",
        "@numeroNotificacao",
        "@expiracao",
        "@nomeContribuinte",
        "@cnpj",
        "@aliquota",
        "@valorDivergente",
        "@valorMulta",
        "@nomeDoIntimado",
        "@documentoDoIntimado",
        "@estado",
        "@pais",
        "@cidade",
        "@rua",
        "@numeroEndereco",
        "@cep",
        "@tipoEndereco",
        "@bairro",
        "@email",
        "@telefone",
        "@descricaoTelefone",
        "@nomeAuditor",
        "@inscricaoMunicipal",
        "@municipio",
        "@nomeMunicipio",
        "@logoMunicipio",
        "@siglaEstado",
        "@responsavelMunicipio",
        "@baseLegalAviso",
        "@baseLegalNotificacao",
        "@dataHoraAtual",
        "@dataPorExtenso",
        "@nomeDoIntimado",
        "@documentoDoIntimado"
    };

    public NoticeTemplateServices(INoticeTemplateRepository repository)
    {
        _repository = repository;
        htmlServices = new HTMLServices();
    }

    public NoticeTemplate GetById(Guid id)
    {
        return _repository
                .Query()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    public List<NoticeTemplateViewModel> GetAll(Metadata metadata, NoticeTemplateParams  @params)
    {
        var query = _repository
                    .Query()
                    .WhereIf(@params.Type, e => e.Type == @params.Type)
                    .WhereIf(@params.Module, e => e.Module == @params.Module)
                    .OrderByDescending(e => e.CreatedAt);

        return _repository
                .ExecuteQuery(query, metadata)
                .Select(ConvertToViewModel)
                .ToList();
    }
    
    public NoticeTemplateViewModel View(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity);

        return ConvertToViewModel(entity);
    }

    public List<string> GetFields(Guid id, bool allFields = false)
    {
        var template = _repository.GetById(id);
        ThrowIfNull(template, "Template");

        var fields = new List<string>();
        var rawFields = template
                        .Template
                        .Replace("<", " ").Replace(">", " ")
                        .Split(" ")
                        .Where(e => e.StartsWith('@'))
                        .ToList();
        rawFields.ForEach(e =>
        {
            var aux = e.Replace("\n", "")
                       .Replace("\r", "")
                       .Replace(",", "");

            if(!fields.Contains(aux) && (!APIFields.Contains(aux) || allFields))
                fields.Add(aux);
        });

        return fields;
    }

    public NoticeTemplateViewModel Insert(NoticeTemplateInsertUpdateViewModel model)
    {
        ValidateModel(model);

        var entity = ConvertToEntity(model);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    public NoticeTemplateViewModel Update(NoticeTemplateInsertUpdateViewModel model, Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity);

        ValidateModel(model);

        UpdateEntity(model, entity);
        _repository.Update(entity);

        return ConvertToViewModel(entity);
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);
        ThrowIfNull(entity);

        _repository.Delete(entity);
    }

    public bool Exist(Guid id)
    {
        return _repository
                .Query()
                .Where(e => e.Id == id)
                .Any();
    }

    private NoticeTemplate Get(Guid id)
    {
        return _repository
                .Query()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private NoticeTemplate ConvertToEntity(NoticeTemplateInsertUpdateViewModel model)
    {
        var entity = new NoticeTemplate();
        UpdateEntity(model, entity);

        return entity;
    }

    private void UpdateEntity(NoticeTemplateInsertUpdateViewModel model, NoticeTemplate entity)
    {
        var safeHtml = htmlServices.Sanitize(model.HtmlTemplate);

        entity.Template = safeHtml;
        entity.Type = model.Type;
        entity.DaysToExpire = model.DaysToExpire;
        entity.Name = model.Name;
        entity.Module = model.Module;
    }

    private static NoticeTemplateViewModel ConvertToViewModel(NoticeTemplate e)
    {
        return new NoticeTemplateViewModel()
        {
            Id = e.Id,
            HtmlTemplate = e.Template,
            Name = e.Name,
            Type = e.Type,
            DaysToExpire = e.DaysToExpire,
            Module = e.Module,
        };
    }

    private static void ValidateModel(NoticeTemplateInsertUpdateViewModel model)
    {
        var messages = new List<string>();

        if (string.IsNullOrEmpty(model.HtmlTemplate))
            messages.Add("HtmlTemplate is required.");

        if (string.IsNullOrEmpty(model.Name))
            messages.Add("Name is required.");

        if (model.DaysToExpire <= 0)
            messages.Add("Invalid DaysToExpire.");

        if(messages.Any())
            throw new BadRequestException(messages);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if(entity == null)
            throw new NotFoundException($"{message} not found.");
    }
}