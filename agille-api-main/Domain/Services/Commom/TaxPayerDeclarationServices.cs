using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace AgilleApi.Domain.Services.Commom;

public class TaxPayerDeclarationServices : ITaxPayerDeclarationServices
{
    private readonly ITaxPayerDeclarationRepository _repository;
    private readonly IProprietyServices _proprietyServices;
    private readonly ISessionServices _sessionServices;
    private readonly IPersonServices _personServices;
    private readonly INotificationServices _notificationServices;
    private readonly ITenantServices _tenantServices;
    private readonly IAttachmentServices _attachmentServices;
    private readonly MiddlewareClient _middlewareClient;
    private readonly TaxPayerDeclarationParser _taxPayerDeclarationParser;

    public TaxPayerDeclarationServices(ITaxPayerDeclarationRepository repository, IProprietyServices proprietyServices, ISessionServices sessionServices, IPersonServices personServices, INotificationServices notificationServices, ITenantServices tenantServices, MiddlewareClient middlewareClient, IAttachmentServices attachmentServices, TaxPayerDeclarationParser taxPayerDeclarationParser)
    {
        _repository = repository;
        _proprietyServices = proprietyServices;
        _sessionServices = sessionServices;
        _personServices = personServices;
        _notificationServices = notificationServices;
        _tenantServices = tenantServices;
        _middlewareClient = middlewareClient;
        _attachmentServices = attachmentServices;
        _taxPayerDeclarationParser = taxPayerDeclarationParser;
    }

    public IEnumerable<TaxPayerDeclarationViewModel> List(Metadata meta, TaxPayerDeclarationParams @params)
    {
        if(SessionIsTaxpayer())
            @params.UserId = _sessionServices.GetUserId();

        var query = _repository
                        .Query()
                        .Include(e => e.Propriety)
                        .ThenInclude(e => e.Owners)
                        .ThenInclude(e => e.Owner)
                        .Include(e => e.Person);
        var target = Filter(query, meta, @params);

        return _repository
                .ExecuteQuery(target, meta)
                .Select(ConvertToViewModel);
    }

    public TaxPayerDeclarationViewModel GetDeclaration(TaxPayerDeclarationParams @params)
    {
        return GetDeclaration(@params.Year, @params.Cib);
    }

    public TaxPayerDeclarationViewModel GetDeclaration(string year, string cib)
    {
        var userId = _sessionServices.GetUserId();

        if (!IsOwner(userId.Value, cib))
            throw new BadRequestException("Você não é proprietário desse imóvel, acesso negado.");
        
        var entity = Get(year, cib) ?? new();
        return ConvertToViewModel(entity);
    }

    public TaxPayerDeclarationViewModel GetDeclaration(string year, Guid proprietyId, string cib = "")
    {
        var entity = Get(year, proprietyId, cib) ?? new();
        return ConvertToViewModel(entity);
    }

    public TaxPayerDeclarationViewModel Upsert(TaxPayerDeclarationViewModel model, TaxPayerDeclarationParams @params)
    {
        ValidateModel(model, @params);
        var userId = _sessionServices.GetUserId().Value;
        
        return Exist(@params.Year, @params.Cib, null) ? Update(model, @params, userId) : Insert(model, @params, userId);
    }

    private TaxPayerDeclarationViewModel Insert(TaxPayerDeclarationViewModel model, TaxPayerDeclarationParams @params, Guid userId)
    {
        SetParamProprietyId(@params);
        ValidateOwner(userId, @params.ProprietyId);

        var personId = GetPersonId(userId);
        var entity = ConvertToEntity(model, @params, userId, personId);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    private TaxPayerDeclarationViewModel Update(TaxPayerDeclarationViewModel model, TaxPayerDeclarationParams @params, Guid userId)
    {
        SetParamProprietyId(@params);
        
        var entity = Get(@params.Year, @params.Cib);
        
        ValidateOwner(userId, entity.ProprietyId, entity.UserId);
        ApplyEntityData(entity, model, @params.ProprietyId);
        
        _repository.Update(entity);

        return ConvertToViewModel(entity);
    }

    public CsvResponseViewModel Import(CsvInsertViewModel model)
    {
        ValidateAttachment(model.AttachmentId);

        var declarations = _taxPayerDeclarationParser.Parse(model.AttachmentId);

        var cibs = declarations.Select(e => e.Item1.Item1.Cib).ToList();
        var proprieties = _proprietyServices.GetIdsByCib(cibs);
        var persons = _personServices.GetPersonIdByDocument(declarations.Select(e => e.Item1.Item1.OwnerDocument.SanitazeDocument()).ToList());
        var existingDeclarations = GetExistingDeclarations(cibs);

        var toInsert = new List<TaxPayerDeclaration>();
        var toUpdate = new List<TaxPayerDeclaration>();

        var proprietiesToUpdate = new List<Propriety>();

        var itens = new List<ItemCsvError>();
        var fails = new List<string>();

        declarations.ForEach(p =>
        {
            try
            {
                var model = p.Item1.Item1;
                var @params = new TaxPayerDeclarationParams()
                {
                    Cib = model.Cib,
                    Year =  model.Year,
                    ProprietyId = (proprieties.ContainsKey(model.Cib)) ? proprieties[model.Cib].Id : null,
                };

                var cibAux = model.Cib.SanitazeCib();
                var entity = (existingDeclarations.ContainsKey((cibAux, model.Year))) ? existingDeclarations[(cibAux, model.Year)] : null;
                Guid? personId = (persons.ContainsKey(model.OwnerDocument.SanitazeDocument())) ? persons[model.OwnerDocument.SanitazeDocument()] : null;
                
                if (entity == null || entity.Year != @params.Year)
                {    
                    entity = ConvertToEntity(model, @params, null, personId, true);
                    toInsert.Add(entity);
                }
                else
                {
                    ApplyEntityData(entity, model, @params.ProprietyId, personId);
                    toUpdate.Add(entity);
                }

                if (entity.ProprietyId.HasValue)
                {
                    var propriety = proprieties[model.Cib];
                    ApplyProprietyData(propriety, p.Item1.Item2);

                    proprietiesToUpdate.Add(propriety);
                }
            }
            catch (DomainException e)
            {
                fails.Add(p.Item2);
                itens.Add(new((itens.Count + 1), e.ValidationMessages));
            }
        });

        _repository.InsertMany(toInsert);
        _repository.UpdateMany(toUpdate);

        _proprietyServices.UpdateMany(proprietiesToUpdate);

        var url = GetErrosFileUrl(fails);
        var response = new CsvResponseViewModel(url, itens);
        PostNotification(response.ConvertToJson());

        return response;
    }

    private void ValidateAttachment(Guid? id)
    {
        if (!_attachmentServices.Exists(id))
            throw new NotFoundException("Arquivo não encontrado.");
    }

    private void PostNotification(string body)
    {
        _notificationServices.InsertMany(new NotificationInsertViewModel()
        {
            UserIds = new List<Guid>() { _sessionServices.GetCurrentSession().UserId },
            Title = "Importação de declarações realizada com sucesso",
            Message = "Clique para verificar",
            Link = "",
            Body = body,
            Priority = NotificationPriority.Normal,
        });
    }

    private string GetErrosFileUrl(List<string> fails)
    {
        AttachmentViewModel file = null;
        if (fails.Any())
        {
            var bytes = Encoding.Unicode.GetBytes(string.Join("\n", fails));
            file = _attachmentServices.InsertByBytes(bytes, "declarations-import-erros.csv", "text/csv", "TaxpayerDeclarations", "");
        }

        return file?.Url ?? "";
    }

    private Dictionary<(string, string), TaxPayerDeclaration> GetExistingDeclarations(List<string> cibs)
    {
        return _repository
                .Query()
                .Where(e => cibs.Contains(e.Cib))
                .ToDictionary(e => (e.Cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", ""), e.Year), j => j);
    }

    private void SetParamProprietyId(TaxPayerDeclarationParams @params)
    {
        var proprietyId = _proprietyServices.GetIdByCib(@params.Cib);
        var userId = _sessionServices.GetUserId();
        
        if (!proprietyId.HasValue)
            PostWarningToAuditors(@params.Cib, userId, @params.Year);
        else
            @params.ProprietyId = proprietyId;
    }

    private void PostWarningToAuditors(string cib, Guid? userId, string year)
    {
        var tenantId = _tenantServices.GetId();
        var ownerInfo = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value }).FirstOrDefault();

        if (ownerInfo == null)
            throw new NotFoundException("Os dados do usuário não foram encontrados");

        var auditors = _middlewareClient.GetUserInfosByPermission(tenantId, "ContribuinteDTE")?.Select(e => e.UserId)?.ToList();
        auditors ??= new();

        _notificationServices.InsertMany(new()
        {
            UserIds = auditors,
            Title = "Declaração do ITR",
            Message = $"O contribuinte {ownerInfo.Fullname}, cadastrado no documento {ownerInfo.Document}, realizou uma declaração para uma propriedade(Cib: {cib}) referente ao ano {year} que não está incluída na plataforma.",
            Link = "",
            Priority = NotificationPriority.High,
        }); ;
    }
    
    private void ValidateOwner(Guid userId, Guid? proprietyId, Guid? befodeDeclaredBy = null)
    {
        if (proprietyId.HasValue && !IsOwner(userId, proprietyId))
            throw new BadRequestException("Você não é proprietário desse imóvel, contate o suporte para mais informações.");

        if (befodeDeclaredBy.HasValue && befodeDeclaredBy != userId)
            throw new BadRequestException("Essa declaração já foi realizada por outro proprietário desse imóvel. Somente sua visualização está disponível.");
    }

    private bool IsOwner(Guid userId, Guid? proprietyId)
    {
        var ownerInfo = _personServices.ViewByUserId(userId);
        if (ownerInfo == null)
            return false;

        return _proprietyServices.IsOwner(ownerInfo.Id, proprietyId);
    }

    private bool IsOwner(Guid userId, string cib)
    {
        var proprietyId = _proprietyServices.GetIdByCib(cib);

        if (!proprietyId.HasValue)
            return true;
            
        var ownerInfo = _personServices.ViewByUserId(userId);
        if (ownerInfo == null)
            return false;

        return _proprietyServices.IsOwner(ownerInfo.Id, proprietyId);
    }

    private bool SessionIsTaxpayer()
    {
        var userId = _sessionServices.GetUserId();
        var person = _personServices.ViewByUserId(userId);

        return (person != null);
    }

    private Guid? GetPersonId(Guid userId)
    {
        var person = _personServices.ViewByUserId(userId);
        return person?.Id;
    }

    private TaxPayerDeclaration Get(string year, string cib, Guid? userId = null)
    {
        return _repository
                .Query()
                .WhereIf(userId, x => x.UserId == userId)
                .Where(x => x.Year == year)
                .Where(x => x.Propriety.CibNumber.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")) ||
                       x.Cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
                .FirstOrDefault();
    }

    private TaxPayerDeclaration Get(string year, Guid proprietyId, string cib)
    {
        return _repository
                .Query()
                .Where(x => x.Year == year)
                .Where(e => e.ProprietyId == proprietyId || e.Cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")))
                .FirstOrDefault();
    }

    private bool Exist(string year, string cib, Guid? userId)
    {
        return _repository
                .Query()
                .WhereIf(userId, x => x.UserId == userId)            
                .Where(e => e.Year == year && e.Cib == cib)
                .Any();
    }

    private static void ValidateModel(TaxPayerDeclarationViewModel model, TaxPayerDeclarationParams @params)
    {
        if (string.IsNullOrEmpty(@params.Year))
            throw new BadRequestException("O Ano informado é inválido.");

        var messages = new List<string>();

        ValidateDecimal("Área Total do Imóvel", model.Total, messages);
        ValidateDecimal("Área de Preservação Permanente", model.PermanentPreservationArea, messages);
        ValidateDecimal("Área de Reserva Legal", model.LegalReserveArea, messages);
        ValidateDecimal("Área tributável", model.TaxableArea, messages);
        ValidateDecimal("Área Ocupada com Bendeitorias", model.AreaOccupiedWithWorks, messages);
        ValidateDecimal("Área Aproveitável", model.UsableArea, messages);
        ValidateDecimal("Área com Reflorestamento", model.AreaWithReforestation, messages);
        ValidateDecimal("Área Utilizada na Atividade Rural", model.AreaUsedInRuralActivity, messages);

        if (messages.Any())
            throw new BadRequestException(messages);
    }

    private static void ValidateDecimal(string label, decimal value, List<string> message)
    {
        if (value <= 0)
            message.Add($"O valor({label}: {value}) deve ser maior que zero.");
    }

    private static void ApplyEntityData(TaxPayerDeclaration entity, TaxPayerDeclarationViewModel model, Guid? proprietyId = null, Guid? personId = null)
    {
        entity.Total = model.Total;
        entity.PermanentPreservationArea = model.PermanentPreservationArea;
        entity.LegalReserveArea = model.LegalReserveArea;
        entity.TaxableArea = model.TaxableArea;
        entity.AreaOccupiedWithWorks = model.AreaOccupiedWithWorks;
        entity.UsableArea = model.UsableArea;
        entity.AreaWithReforestation = model.AreaWithReforestation;
        entity.AreaUsedInRuralActivity = model.AreaUsedInRuralActivity;
        entity.ProprietyId = proprietyId;
        entity.Number = model.Number;

        if (personId.HasValue)
            entity.PersonId = personId;
    }

    private void ApplyProprietyData(Propriety propriety, DeclarationImportProprietyData model)
    {
        if (!model.Address.CityId.HasValue)
            throw new BadRequestException($"A propriedade(Cib: {propriety.CibNumber}) não foi atualizada porque seu endereço é inválido.");

        propriety.Name = propriety.Name.Patch(model.Name);
        propriety.CARNumber = propriety.CARNumber.Patch(model.CAR);
        propriety.IncraCode = propriety.IncraCode.Patch(model.IncraCode);
        propriety.Situation = propriety.Situation.Patch(model.Situation);

        propriety.LegalReserveArea = model.LegalReserveArea;
        propriety.DeclaredArea = model.TotalArea;

        _proprietyServices.UpdateProprietyAddress(propriety, model.Address, true);
    }

    private static TaxPayerDeclaration ConvertToEntity(TaxPayerDeclarationViewModel model, TaxPayerDeclarationParams @params, Guid? userId, Guid? personId, bool isFromImport = false)
    {
        return new(@params.Year, @params.Cib, @params.ProprietyId, model.Total, model.PermanentPreservationArea, model.LegalReserveArea, model.TaxableArea, model.AreaOccupiedWithWorks, model.UsableArea, model.AreaWithReforestation, model.AreaUsedInRuralActivity, userId, model.Number, personId , isFromImport);
    }

    private static TaxPayerDeclarationViewModel ConvertToViewModel(TaxPayerDeclaration entity)
    {
        return new(entity.Total, entity.PermanentPreservationArea, entity.LegalReserveArea, entity.TaxableArea, entity.AreaOccupiedWithWorks, entity.UsableArea, entity.AreaWithReforestation, entity.AreaUsedInRuralActivity, entity.Number)
        {
            Cib = entity?.Propriety?.CibNumber,
            Owner = entity?.Person?.Name ?? entity?.Propriety?.Owners?.FirstOrDefault()?.Owner?.Name,
            Year = entity.Year,
        };
    }

    private static IQueryable<TaxPayerDeclaration> Filter(IQueryable<TaxPayerDeclaration> query, Metadata meta, TaxPayerDeclarationParams @params)
    {
        query = query
            .WhereIf(@params.UserId, e => e.UserId == @params.UserId)
            .WhereIf(@params.ProprietyId, e => e.ProprietyId == @params.ProprietyId)
            .WhereIf(@params.Year, e => e.Year.Contains(@params.Year))
            .WhereIf(@params.ProprietyName, e => e.Propriety.Name.ToLower().Contains(@params.ProprietyName.ToLower()))
            .WhereIf(@params.Cib, e => e.Cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "").Contains(@params.Cib.Replace(".", "").Replace("-", "").Replace("/", "").Replace(" ", "")));

        string sortColLowercase = meta.SortColumn.ToLower();
        Expression<Func<TaxPayerDeclaration, Object>> filter = sortColLowercase switch
        {
            "year" => e => e.Year,
            "cib" => e => e.Cib,
            "proprietyname" => e => e.Propriety.Name,
            _ => x => x.CreatedAt
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdat";

        query = query.OrderByDescending(filter);

        return query;
    }
}