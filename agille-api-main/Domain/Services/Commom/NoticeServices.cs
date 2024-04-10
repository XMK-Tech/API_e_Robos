using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Domain.Services.Commom;

public class NoticeServices : SessionServices
{
    private readonly INoticeRepository _repository;
    private readonly ITaxActionRepository _taxActionRepository;
    private readonly IReturnProtocolReporitory _returnProtocolReporitory;
    private readonly IDivergencyEntryServices _divergencyEntryServices;
    private readonly INoticeTemplateServices _templateServices;
    private readonly IJuridicalPersonServices _juridicalPersonServices;
    private readonly IJuridicalPersonRepository _juridicalPersonRepository;
    private readonly INoticeDivergencyEntryRepository _noticeDivergencyEntryRepository;
    private readonly IPDFGenerator _pdfGeneratorServices;
    private readonly IAddressService _addressServices;
    private readonly IJuridicalPersonNoticesRepository _juridicalPersonNoticesRepository;
    private readonly TaxpayerServices _taxpayerServices;
    private readonly IEntitiesServices _entitiesServices;
    
    private readonly ICardDivergencyEntryRepository _cardDivergencyEntryRepository;
    private readonly IAttachmentServices _attachmentsServices;
    private readonly IPersonServices _personServices;
    private readonly MiddlewareClient _middlewareClient;

    public static readonly CultureInfo Culture = new("pt-BR");

    public NoticeServices(IHttpContextAccessor httpContextAccessor, INoticeRepository repository, IDivergencyEntryServices divergencyEntryServices,
        INoticeTemplateServices templateServices, INoticeDivergencyEntryRepository noticeDivergencyEntryRepository, IAttachmentServices attachmentsServices,
        IPDFGenerator pdfGeneratorServices, IJuridicalPersonServices juridicalPersonServices, IAddressService addressServices,
        IJuridicalPersonNoticesRepository juridicalPersonNoticesRepository, TaxpayerServices taxpayerServices, IJuridicalPersonRepository juridicalPersonRepository,
        IEntitiesServices entitiesServices, ICardDivergencyEntryRepository cardDivergencyEntryRepository, ITaxActionRepository historicRepository,
        IReturnProtocolReporitory returnProtocolReporitory, IPersonServices personServices, MiddlewareClient middlewareClient)
        : base(httpContextAccessor)
    {
        _repository = repository;
        _divergencyEntryServices = divergencyEntryServices;
        _templateServices = templateServices;
        _noticeDivergencyEntryRepository = noticeDivergencyEntryRepository;
        _attachmentsServices = attachmentsServices;
        _pdfGeneratorServices = pdfGeneratorServices;
        _juridicalPersonServices = juridicalPersonServices;
        _addressServices = addressServices;
        _juridicalPersonNoticesRepository = juridicalPersonNoticesRepository;
        _taxpayerServices = taxpayerServices;
        _juridicalPersonRepository = juridicalPersonRepository;
        _entitiesServices = entitiesServices;
        _cardDivergencyEntryRepository = cardDivergencyEntryRepository;
        _taxActionRepository = historicRepository;
        _returnProtocolReporitory = returnProtocolReporitory;
        _personServices = personServices;
        _middlewareClient = middlewareClient;
    }

    private static IQueryable<Notice> Filter(IQueryable<Notice> query, GetNoticeParamsViewModel model, Metadata meta)
    {
        query = query
            .WhereIf(model.Type, i => i.Type == model.Type)
            .WhereIf(model.Document, i => i.TaxPayer.Person.Document.Contains(model.Document))
            .WhereIf(model.CompanyName, i => i.TaxPayer.Person.DisplayName.Contains(model.CompanyName))
            .WhereIf(model.Name, i => i.Template.Name.Contains(model.Name))
            .WhereIf(model.Document, i => i.Number == model.Number)
            .OrderByDescending(x => x.CreatedAt);

        return query;
    }

    public List<NoticeViewModel> GetAll(GetNoticeParamsViewModel model, Metadata meta)
    {
        var query = _repository.Query()
                        .Include(x => x.TaxPayer.Person)
                        .Include(x => x.Attachment)
                        .Include(x => x.Template)
                        .AsQueryable();

        query = Filter(query, model, meta);
        return _repository
                .ExecuteQuery(query, meta)
                .Select(ConvertToViewModel)
                .ToList();
    }

    public NoticeViewModel View(Guid id)
    {
        var entity = _repository.Query()
                        .Include(x => x.TaxPayer.Person)
                        .Include(x => x.Attachment)
                        .Include(x => x.Template)
                        .Include(x => x.TaxActions)
                        .ThenInclude(x => x.Attachment)
                        .Include(x => x.ReturnProtocol)
                        .Where(e => e.Id == id)
                        .FirstOrDefault();

        ThrowIfNull(entity, "Notice");

        return ConvertToViewModel(entity);
    }

    public IEnumerable<NoticeViewModel> ViewPersonNotices(GetNoticeParamsViewModel model, Metadata meta)
    {
        var userId = GetCurrentSession()?.UserId;
        var personId = _personServices.GetByUserId(userId)?.Id;

        var query = _repository.Query()
                        .Include(x => x.TaxPayer.Person)
                        .Include(x => x.Attachment)
                        .Include(x => x.Template)
                        .Where(x => x.PersonId == personId)
                        .AsQueryable();

        query = Filter(query, model, meta);

        return _repository
                .ExecuteQuery(query, meta)
                .Select(ConvertToViewModel)
                .ToList();
    }

    public string Insert(NoticeInsertUpdateViewModel model)
    {
        if(model.DivergencyIds == null || !model.DivergencyIds.Any())
            throw new BadRequestException("É necessário selecionar pelo menos uma divergência.");

        var template = _templateServices.GetById(model.TemplateId);
        ThrowIfNull(template, "Template");

        var expiresIn = (model.DaysToExpire is null) ? template.DaysToExpire : model.DaysToExpire.Value;
        var dueDate = DateTime.Now.AddDays(expiresIn);
        string noticeNumber = CalculateNoticeNumber();

        string content = GetContent(model, noticeNumber, dueDate);
        ThrowIfNull(content, "Content");

        AttachmentViewModel attachment = CreateAttachment(template.Id, content);

        var entity = new Notice(
            content,
            attachment.Id,
            model.TemplateId,
            model.Type,
            model.Aliquot,
            model.Observation,
            dueDate,
            model.RateType ?? NoticeBaseRate.Null
        )
        {
            Number = noticeNumber,
            Status = NoticeStatus.Issued,
            Module = template.Module
        };

        List<BaseDivergencyEntry> divergencyEntries = GetDivergencyEntries(model.DivergencyIds);
        
        var taxPayerDocument = divergencyEntries.First().Document;
        var taxPayer = _juridicalPersonServices.GetByDocument(taxPayerDocument);

        entity.TaxPayerId = taxPayer.Id;
        _repository.Insert(entity);
        InsertDivergencies(model, entity, divergencyEntries);

        return attachment.Url;
    }

    public string ManualInsert(NoticeManualInsertUpdateViewModel model)
    {
        var isValidPerson = _personServices.Exists(model.SubjectId);
        if (!isValidPerson)
            throw new BadRequestException("Sujeito passivo não encontrado.");

        var template = _templateServices.GetById(model.TemplateId);
        ThrowIfNull(template, "Template");

        var expiresIn = (model.DaysToExpire is null) ? template.DaysToExpire : model.DaysToExpire.Value;
        var dueDate = DateTime.Now.AddDays(expiresIn);
        string noticeNumber = CalculateNoticeNumber();

        string content = GetManualContent(model, template.Template, noticeNumber, dueDate);
        ThrowIfNull(content, "Content");

        AttachmentViewModel attachment = CreateAttachment(template.Id, content);

        var entity = new Notice(
            content,
            attachment.Id,
            model.TemplateId,
            model.Type,
            model.Aliquot,
            model.Observation,
            dueDate,
            model.RateType ?? NoticeBaseRate.Null
        )
        {
            PersonId = model.SubjectId,
            Number = noticeNumber,
            Status = NoticeStatus.Issued,
            Module = template.Module
        };

        _repository.Insert(entity);

        return attachment.Url; ;
    }

    public void UpdateStatus(NoticeUpdateStatusViewModel model)
    {
        if (string.IsNullOrEmpty(model.Description))
            throw new BadRequestException("Uma descrição para essa alteração é necessária.");

        if (model.AttachmentId.HasValue && !_attachmentsServices.Exists(model.AttachmentId))
            throw new BadRequestException("Arquivo não encontrado;");
        
        var notice = _repository.GetById(model.NoticeId);
        ThrowIfNull(notice, "Notice");

        var userId = GetCurrentSession()?.UserId;
        ThrowIfNull(userId, "User");

        var statusHasChanged = (model.Status.HasValue && model?.Status != notice.Status);

        var historic = new TaxAction()
        {
            Description = model.Description,
            StatusHasChanged = statusHasChanged,
            UserId = userId.Value,
            Date = model.Date,
            NoticeId = model.NoticeId,
            FromStatus = notice.Status,
            ToStatus = model.Status ?? notice.Status,
            AttachmentId = model.AttachmentId
        };

        _taxActionRepository.Insert(historic);

        if (statusHasChanged)
        {
            notice.Status = model.Status.Value;
            _repository.Update(notice);
        }
    }

    public void SetReturnProtocol(Guid id, ReturnProtocolInsertViewModel model)
    {
        ValidateProtocolModel(model);

        var notice = _repository.GetById(id);
        ThrowIfNull(notice, "Notice");

        if (notice.ReturnProtocolId.HasValue)
            throw new BadRequestException("Essa notificação já teve seu protocolo de retorno cadastrado no sistema.");

        var returnProtocol = new ReturnProtocol(model.Document, model.Name, model.Phone, model.Date, model.SignedBy);
        _returnProtocolReporitory.Insert(returnProtocol);

        notice.ReturnProtocolId = returnProtocol.Id;
        _repository.Update(notice);
    }

    private static void ValidateProtocolModel(ReturnProtocolInsertViewModel model)
    {
        if (string.IsNullOrEmpty(model.Document))
            throw new BadRequestException("Documento é um campo obrigatório.");

        if (string.IsNullOrEmpty(model.Phone))
            throw new BadRequestException("Telefone é um campo obrigatório.");

        if (string.IsNullOrEmpty(model.Name))
            throw new BadRequestException("Nome é um campo obrigatório.");
    }

    private string CalculateNoticeNumber()
    {
        var year = DateTime.Now.Year;
        var index = _repository.Query().Where(e => e.CreatedAt.Year == year).Count() + 1;
        var number = index.ToString().PadLeft(5,'0') + "/" + year;

        return number;
    }

    public List<NoticeViewModel> GetTaxpayerNotices()
    {
        var userId = GetCurrentSession().UserId;
        var companyId = _taxpayerServices.GetCompanyIdFromUser(userId);

        if (companyId == null || companyId == Guid.Empty)
            throw new BadRequestException("Você não está cadastrado como contribuinte de nenhuma empresa.");

        List<NoticeViewModel> collaboratorNotices = _juridicalPersonNoticesRepository
            .Query()
            .Include(e => e.JuridicalPerson)
            .Include(e => e.Notice)
            .Include(e => e.Notice.Attachment)
            .Include(e => e.Notice.Template)
            .Include(e => e.Notice.TaxActions)
            .Where(e => e.JuridicalPerson.Id == companyId)
            .Select(e => ConvertToViewModel(e.Notice))
            .ToList();

        return collaboratorNotices;
    }

    public void UpdateNoticeViewStatus(List<UpdateNoticeViewdState> data)
    {
        if (data == null)
            return;

        foreach (var status in data)
        {
            var notice = _juridicalPersonNoticesRepository.Get(e => e.NoticeId == status.NoticeId).FirstOrDefault();
            if (notice != null)
            {
                notice.WasViewed = status.WasViewd;
                _juridicalPersonNoticesRepository.Update(notice);
            }
        }
    }

    public CompleteNoticeViewModel ViewNotification(Guid id)
    {
        var notice = _repository.Query().Where(e => e.Id == id).FirstOrDefault();
        var companyNotice = _juridicalPersonNoticesRepository.Query()
            .Include(e => e.Notice)
            .ThenInclude(e => e.TaxActions)
            .Include(e => e.JuridicalPerson)
            .Include(e => e.JuridicalPerson.Person)
            .Where(e => e.NoticeId == id)
            .FirstOrDefault();

        ThrowIfNull(notice, "Notice");
        notice.NoticeDivergencyEntries = GetNoticeDivergencyEntries(notice.Id);

        if (companyNotice == null)
            throw new BadRequestException("Inválido. Essa notificação não está disponível para contribuintes.");

        var userId = GetCurrentSession().UserId; 
        if (!_taxpayerServices.IsTaxpayerOfCompany(userId, companyNotice.JuridicalPersonId))
            throw new BadRequestException("Inválido. Você não possui permissão para visualizar essa notificação.");
        
        var divergencyIds = notice
                            .NoticeDivergencyEntries
                            .Select(e => e.Id)
                            ?.ToList();
        var divergencys = GetDivergencyEntries(divergencyIds);

        var url = _attachmentsServices.View(notice.AttachmentId)?.Url;
        var companyName = companyNotice.JuridicalPerson.Person.Name;

        companyNotice.WasViewed = true;
        _juridicalPersonNoticesRepository.Update(companyNotice);

        var divergencysViewModels = divergencys.Select(i => new DivergencyEntryViewModel(i)).ToList();
        var taxActions = ConvertTaxActionToViewModel(notice.TaxActions);
        var returnProtocol = ConvertReturnProtocolToViewModel(notice.ReturnProtocol);

        return new CompleteNoticeViewModel(notice, companyName, url, divergencysViewModels, taxActions, returnProtocol);
    }

    public void SetNoticeVisibleForTaxpayers(Guid id)
    {
        var notice = _repository.Query()
                        .Include(n => n.TaxPayer.Person)
                        .FirstOrDefault(n => n.Id == id);
        notice.NoticeDivergencyEntries = GetNoticeDivergencyEntries(id);

        ThrowIfNull(notice, "Notice");

        var companyDocument = notice?.TaxPayer?.Person?.Document;
        var company = _juridicalPersonRepository.Get(e => e.Person.Document == companyDocument).FirstOrDefault();

        if (company == null)
            throw new NotFoundException("Essa notificação não está relacionada a nenhuma empresa.");

        var companyNotice = new JuridicalPersonNotices(notice.Id, company.Id);
        _juridicalPersonNoticesRepository.Insert(companyNotice);
    }

    public List<NoticeDivergencyEntry> GetNoticeDivergencyEntries(Guid id)
    {
        return _noticeDivergencyEntryRepository
                .Query()
                .Include(e => e.Notice)
                .Where(e => e.NoticeId == id)
                .ToList();
    }

    private void InsertDivergencies(NoticeInsertUpdateViewModel model, Notice entity, List<BaseDivergencyEntry> divergencyEntries)
    {
        var divergencyEntryNotice = divergencyEntries
                    .Select(x => new NoticeDivergencyEntry()
                    {
                        NoticeId = entity.Id,
                        DivergencyEntryId = x.Id
                    }).ToList();
        
        _noticeDivergencyEntryRepository.InsertMany(divergencyEntryNotice);
    }

    private AttachmentViewModel CreateAttachment(Guid templateId, string content)
    {
        //TODO: Generate Attachment
        var pdfBytes = _pdfGeneratorServices.Generate(content);
        var stream = new MemoryStream(pdfBytes);
        string filename = templateId.ToString();
        var attachmentViewModel = new AttachmentInsertUpdateViewModel()
        {
            Attachment = new FormFile(stream, 0, pdfBytes.Length, filename, filename + ".pdf")
            {
                Headers = new HeaderDictionary(),
                ContentType = "application/pdf"
            },
            Owner = "Notice",
            OwnerId = ""
        };
        return _attachmentsServices.Insert(attachmentViewModel);
    }

    public string GetContent(NoticeInsertUpdateViewModel model, string noticeNumber = "", DateTime? expiresAt = null)
    {
        var divergency = GetDivergencyEntry(model.DivergencyIds);
        return ReplaceTemplate(_templateServices.GetById(model.TemplateId).Template, model, divergency, noticeNumber, expiresAt);
    }

    public string GetManualContent(NoticeManualInsertUpdateViewModel model, string template, string noticeNumber = "", DateTime? expiresAt = null)
    {
        Dictionary<string, string> noticeData = new();

        var person = _personServices.GetById(model.SubjectId);

        EntitiesViewModel entityData = _entitiesServices.View();

        DefineBaseData(model.Observation, noticeNumber, expiresAt, ref noticeData);
        DefinePersonData(person, ref noticeData);
        DefineEntityData(entityData, ref noticeData);
        DefineAuditorData(ref noticeData);

        foreach(var (key, value) in model.Tags)
            if (!noticeData.ContainsKey(key))
                noticeData.Add(key, value);
        
        return PopulateTemplateService.Populate(template, noticeData);
    }

    public List<BaseDivergencyEntry> GetDivergencyEntries(IEnumerable<Guid> ids) {
        List<BaseDivergencyEntry> divergencies = _divergencyEntryServices
                                                    .GetByIds(ids)
                                                    .Select(i => i as BaseDivergencyEntry)
                                                    .ToList();

        if (!divergencies.Any())
            divergencies = _cardDivergencyEntryRepository
                            .Query()
                            .Where(e => ids.Contains(e.Id))
                            .Select(i => i as BaseDivergencyEntry)
                            .ToList();

        return divergencies;
    }
    
    public BaseDivergencyEntry GetDivergencyEntry(IEnumerable<Guid> ids)
    {
        if(ids != null && !ids.Any())
            return null;
        var id = ids.First();
        return GetDivergencyEntries(new List<Guid>() { id }).First();
    }

    public byte[] GetPreview(string template)
    {
        string content = this.GetPreviewContent(template);
        return _pdfGeneratorServices.Generate(content);
    }

    public string GetPreviewContent(string template)
    {
        return ReplaceWithDivergencyData(template,
                        new DivergencyEntry(
                            0,
                            "99.999.999/9999-99",
                            "Padaria",
                            new DateTime(2022, 3, 16, 12, 0, 0),
                            0,
                            0,
                            Guid.Empty
                        ),
                        new NoticeInsertUpdateViewModel()
                        {
                            Aliquot = 10,
                            Observation = "Observação",
                        }
                    );
    }

    private string ReplaceTemplate(string template, NoticeInsertUpdateViewModel model, BaseDivergencyEntry divergency, string noticeNumber = "", DateTime? expiresAt = null)
    {
        //TODO: Get more fields and fetch data from JuridicalPerson
        
        var companyData = _juridicalPersonServices.GetByDocument(divergency.Document);
        EntitiesViewModel entityData = _entitiesServices.View();

        return ReplaceWithDivergencyData(template, divergency, model, companyData, entityData, noticeNumber, expiresAt);
    }

    private string ReplaceWithDivergencyData(string template, BaseDivergencyEntry divergency, NoticeInsertUpdateViewModel model, JuridicalPersonBase companyData = null, EntitiesViewModel entityData = null, string noticeNumber = "", DateTime? expiresAt = null)
    {
        Dictionary<string, string> noticeData = new();

        DefineBaseData(model.Observation, noticeNumber, expiresAt, ref noticeData);
        DefineBaseDivergencyData(divergency, model, ref noticeData);
        DefineCompanyData(companyData, ref noticeData);
        DefineEntityData(entityData, ref noticeData);

        return PopulateTemplateService.Populate(template, noticeData);
    }

    public byte[] TaxStageARTerm(Guid templateId)
    {
        var template = _templateServices.GetById(templateId)?.Template ?? "Erro na localização do template.";
        return _pdfGeneratorServices.Generate(template);
    }

    public byte[] TaxStageTerms(Guid templateId, ForwardingTermNoticeModel termData)
    {
        EntitiesViewModel entityData = _entitiesServices.View();

        var template = _templateServices.GetById(templateId)?.Template ?? "Erro na localização do template.";
        var content = ReplaceWithTaxStageData(template, entityData, termData);
        return _pdfGeneratorServices.Generate(content);
    }

    private string ReplaceWithTaxStageData(string template, EntitiesViewModel entityData, ForwardingTermNoticeModel termData)
    {
        Dictionary<string, string> noticeData = new();

        DefineEntityData(entityData, ref noticeData);
        DefineForwardTermData(termData, ref noticeData);
        DefineDateTimes(ref noticeData);

        return PopulateTemplateService.Populate(template, noticeData);
    }

    private static void DefineBaseData(string observation, string noticeNumber, DateTime? expiresAt, ref Dictionary<string, string> data)
    {
        data.Add("@observacao", observation);
        data.Add("@dataAtual", DateTime.Now.ToString("dd/MM/yyyy"));
        data.Add("@numeroNotificacao", noticeNumber);

        if (expiresAt.HasValue)
            data.Add("@expiracao", expiresAt.Value.ToString("dd/MM/yyyy"));
    }

    private static void DefineBaseDivergencyData(BaseDivergencyEntry divergency, NoticeInsertUpdateViewModel model, ref Dictionary<string, string> data)
    {
        if (divergency == null || model == null)
            return;

        data.Add("@nomeContribuinte", divergency.CompanyName);
        data.Add("@cnpj", divergency.Document);
        data.Add("@aliquota", model.Aliquot.ToString(Culture));
        data.Add("@valorDivergente", divergency.Difference.ToString());

        decimal value = 0;
        if (divergency is CardDivergencyEntry cardDivergency)
        {
            if(model.RateType == Enums.NoticeBaseRate.Declared)             
                value = (divergency.Difference * cardDivergency.DeclaredRate * model.Aliquot);
            else if( model.RateType == Enums.NoticeBaseRate.Average)
                value = (divergency.Difference * cardDivergency.AverageRate * model.Aliquot);
        }
        else if(divergency is DivergencyEntry divergencyEntry)
        {
            value = (divergencyEntry.Difference * model.Aliquot);
        }

        data.Add("@valorMulta", value.ToString(Culture));
    }

    private static void DefinePersonData(PersonBase person, ref Dictionary<string, string> data)
    {
        if (person == null)
            return;

        data.Add("@nomeDoIntimado", person.Name);
        data.Add("@documentoDoIntimado", person.Document);

        var addressesData = person.Addresses?.FirstOrDefault()?.Address;
        if (addressesData != null)
        {
            data.Add("@estado", addressesData.City?.State?.Name);
            data.Add("@pais", addressesData.City?.State?.Country?.Name);
            data.Add("@cidade", addressesData.City?.Name);
            data.Add("@rua", addressesData.Street);
            data.Add("@numeroEndereco", addressesData.Number);
            data.Add("@cep", addressesData.ZipCode);
            data.Add("@tipoEndereco", addressesData?.Type.GetDescription());
            data.Add("@bairro", addressesData.District);
        }

        var email = person.EmailPersons?.FirstOrDefault()?.Email?.Value;
        data.Add("@email", email);

        var phone = person.Phones?.FirstOrDefault();
        data.Add("@telefone", phone?.Number);
        data.Add("@descricaoTelefone", phone?.Type.GetDescription());
    }

    private void DefineAuditorData(ref Dictionary<string, string> data)
    {
        var userId = GetCurrentSession()?.UserId;
        var userInfo = _middlewareClient.GetUserInfos(new List<Guid>() { userId.Value })?.FirstOrDefault();

        if (userInfo == null)
            return;

        data.Add("@nomeAuditor", userInfo.Fullname);
    }

    private static void DefineCompanyData(JuridicalPersonBase company, ref Dictionary<string, string> data)
    {
        var person = company?.Person;
        if (company == null || person == null)
            return;

        DefinePersonData(person, ref data);

        data.Add("@inscricaoMunicipal", company.MunicipalRegistration);
    }

    private void DefineEntityData(EntitiesViewModel entity, ref Dictionary<string, string> data)
    {
        if (entity == null)
            return;

        data.Add("@municipio", entity.Name);
        data.Add("@nomeMunicipio", entity.Name);
        data.Add("@logoMunicipio", entity.EntityImage);
        data.Add("@siglaEstado", _addressServices.GetStateByCityName(entity.Name));
        
        var content = entity?.ISS;
        data.Add("@responsavelMunicipio", content?.ResponsibleName);
        data.Add("@baseLegalAviso", content?.LegalBasisWarning);
        data.Add("@baseLegalNotificacao", content?.LegalBasisNotice);
    }

    private static void DefineForwardTermData(ForwardingTermNoticeModel termData, ref Dictionary<string, string> data)
    {
        if (termData == null)
            return;

        data.Add("@comOuSemImpugnacao", termData.WithObjectionText);

        data.Add("@numeroProcesso", termData.ProcessNumber);
        data.Add("@numeroDocumento", termData.DocumentNumber);
        
        data.Add("@sujeitoPassivo", termData.SubjectName);
        data.Add("@cibSujeitoPassivo", termData.ProprietyCib);
        data.Add("@documentoSujeitoPassivo", termData.SubjectDocument);
        
        data.Add("@folhaInicial", termData.HomePageNumber.ToString());
        data.Add("@folhaFinal", termData.FinalPageNumber.ToString());
        data.Add("@folhaAtual", termData.AtualPageNumber.ToString());
        
        data.Add("@nomeUsuario", termData.Auditor);
    }
    
    private static void DefineDateTimes(ref Dictionary<string, string> data)
    {
        data.Add("@dataHoraAtual", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
        data.Add("@dataPorExtenso", DateTime.Now.ToString("d' de 'MMMM' de 'yyyy"));
    }

    private static NoticeViewModel ConvertToViewModel(Notice i)
    {
        return new NoticeViewModel()
        {
            Aliquot = i.Aliquot,
            Id = i.Id,
            Observation = i.Observation,
            Url = i.Attachment.Url,
            TemplateId = i.TemplateId,
            Name = i.Template?.Name,
            Type = i.Type,
            CompanyName = i.TaxPayer?.Person?.DisplayName ?? i.Person?.DisplayName,
            Document = i.TaxPayer?.Person?.Document ?? i.Person?.Document,
            Date = i.CreatedAt,
            DueDate = i.DueDate,
            Number = i.Number,
            RateType = i.RateType,
            Module = i.Module,
            Status = i.Status,
            StatusDescription = i.Status.GetDescription(),
            TaxActions = ConvertTaxActionToViewModel(i.TaxActions),
            ReturnProtocol = ConvertReturnProtocolToViewModel(i.ReturnProtocol),
            PersonId = i?.TaxPayer?.PersonId ?? i.PersonId,
        };
    }

    private static IEnumerable<TaxActionViewModel> ConvertTaxActionToViewModel(IEnumerable<TaxAction> entities)
    {
        if (entities == null || !entities.Any())
            return null;
        
        return entities
                .OrderByDescending(e => e.CreatedAt)
                .Select(entity => new TaxActionViewModel(entity.Id, entity.Description, entity.StatusHasChanged, entity.FromStatus, entity.ToStatus, entity.UserId, entity.Date, entity.AttachmentId, AttachmentServices.ConvertToViewModel(entity.Attachment)))
                .ToList();
    }

    private static ReturnProtocolViewModel ConvertReturnProtocolToViewModel(ReturnProtocol entity)
    {
        if (entity == null)
            return null;

        return new ReturnProtocolViewModel(entity.Document, entity.Name, entity.Phone, entity.Date, entity.Id, entity.SignedBy);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }
}