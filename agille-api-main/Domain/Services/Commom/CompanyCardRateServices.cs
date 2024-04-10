using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class CompanyCardRateServices : Notifications
{
    private readonly ICompanyCardRateRepository _repository;
    private readonly JuridicalPersonServices _juridicalPersonServices;

    public CompanyCardRateServices(ICompanyCardRateRepository repository, JuridicalPersonServices juridicalPersonServices)
    {
        _repository = repository;
        _juridicalPersonServices = juridicalPersonServices;
    }

    public IEnumerable<CompanyCardRateViewModel> View(Metadata meta)
    {
        var allEntities = _repository.ExecuteQuery(GetAll(), meta).ToList();
        return allEntities.OrderBy(e => e.CreatedAt).Select(ConvertToViewModel).ToList();
    }

    public CompanyCardRateViewModel View(Guid id)
    {
        var entity = Get(id);

        ThrowIfNull(entity);

        return ConvertToViewModel(entity);
    }

    public IEnumerable<CompanyCardRateViewModel> ViewByCardOperatorId(Guid id, Metadata meta = null)
    {
        if (!IsValidCardOperator(id))
            throw new NotFoundException("Card Operator not found.");

        var entities = GetByJuridicalPersonId(id, meta);
        return entities.Select(ConvertToViewModel).ToList();
    }

    public CompanyCardRateViewModel Insert(CompanyCardRateInsertUpdateViewModel model)
    {
        ValidateModel(model);
        DeleteIfExist(model.CardOperatorId, model.CompanyId);

        var entity = ConvertToEntity(model);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    public CompanyCardRateViewModel Update(CompanyCardRateInsertUpdateViewModel model, Guid id)
    {
        var entity = Get(id);

        ThrowIfNull(entity);
        ValidateModel(model);

        entity.CompanyId = model.CompanyId;
        entity.CardOperatorId = model.CardOperatorId;
        entity.Rate = model.Rate;

        _repository.Update(entity);

        return ConvertToViewModel(entity);
    }

    public void Delete(Guid id)
    {
        var entity = Get(id);

        ThrowIfNull(entity);

        _repository.Delete(entity);
    }

    public CardOperatorAverageViewModel CardOperatorRateAverage(string document)
    {
        var allRates = GetByJuridicalPersonDocument(document);
        var declaredRate = (decimal)(GetCardOperatorRateByDocument(document) ?? 0);
        var average = (decimal) allRates.Select(e => e.Rate).DefaultIfEmpty(0).Average();

        return new CardOperatorAverageViewModel(document, declaredRate, average, allRates.Count());
    }

    public CardOperatorAverageViewModel CardOperatorRateAverage(Guid id)
    {
        var allRates = GetByJuridicalPersonId(id);
        var declaredRate = (decimal)(GetCardOperatorRate(id) ?? 0);
        var average = (decimal)allRates.Select(e => e.Rate).DefaultIfEmpty(0).Average();

        return new CardOperatorAverageViewModel(id, declaredRate, average, allRates.Count());
    }

    public decimal? GetCompanyRateOfOperator(Guid companyId, Guid operatorId)
    {
        var rate =  _repository
                        .Query()
                        .Where(e => e.CompanyId == companyId)
                        .Where(e => e.CardOperatorId == operatorId)
                        .FirstOrDefault()
                        ?.Rate;

        return (decimal?)rate;
    }

    public decimal? GetCompanyRateOfOperator(string document)
    {
        var company = _juridicalPersonServices.GetByDocument(document);
        return (decimal?)company?.CardRate;
    }

    public IEnumerable<JuridicalPersonWithOperatorRateViewModel> CompanyList(Guid operatorId, JuridicalPersonParams model, Metadata meta)
    {
        var @operator = _juridicalPersonServices.View(operatorId);
        ThrowIfNull(@operator, "CardOperator");

        if (!@operator.IsCardOperator)
            throw new BadRequestException("Invalid OperatorId.");

        // Attribute locked
        model.IsCardOperator = false;

        var entities = _juridicalPersonServices.List(model, meta);
        var juridicalPersons = new List<JuridicalPersonWithOperatorRateViewModel>();

        foreach(var item in entities)
        {
            decimal? personRate = GetCompanyRateOfOperator(item.Id, operatorId);
            juridicalPersons.Add(new JuridicalPersonWithOperatorRateViewModel(item.Id, item.Document, item.Name, item.DisplayName, @operator.Document, personRate));
        }

        return juridicalPersons;
    }

    private void DeleteIfExist(Guid operatorId, Guid companyId)
    {
        var target = GetAll()
                     .Where(e => e.CompanyId == companyId && e.CardOperatorId == operatorId)
                     .FirstOrDefault();

        if(target != null)
            _repository.Delete(target);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity is null)
            throw new NotFoundException($"{message} not found.");
    }

    private void ValidateModel(CompanyCardRateInsertUpdateViewModel model)
    {
        if (!IsValidCardOperator(model.CardOperatorId))
            throw new NotFoundException("Card operator not found.");

        if (!IsValidCompany(model.CompanyId))
            throw new NotFoundException("Company not found.");

        if (model.Rate < 0 || model.Rate > 100)
            throw new BadRequestException("Invalid Rate. Correct range: 0 to 100.");

        if (IsValidCardOperator(model.CompanyId))
            throw new BadRequestException("Company(companyId) cannot be a card operator!");        
    }

    private double? GetCardOperatorRate(Guid id)
    {
        var response = _juridicalPersonServices.View(id);
        return response?.CardRate;
    }

    private double? GetCardOperatorRateByDocument(string document)
    {
        var response = _juridicalPersonServices.GetByDocument(document);
        return response?.CardRate ?? 0;
    }

    private bool IsValidCardOperator(Guid id)
    {
        var response = _juridicalPersonServices.View(id);
        if (response == null)
            return false;

        return response.IsCardOperator;
    }

    private bool IsValidCompany(Guid id)
    {
        var response = _juridicalPersonServices.View(id);
        if (response == null)
            return false;

        return !response.IsCardOperator;
    }

    private CompanyCardRate Get(Guid id)
    {
        return GetAll()
               .Where(e => e.Id == id)
               .FirstOrDefault();
    }

    private IQueryable<CompanyCardRate> GetAll()
    {
        return _repository.Query()
                .Include(e => e.Company)
                .ThenInclude(e => e.Person)
                .Include(e => e.CardOperator)
                .ThenInclude(e => e.Person);
    }

    private IEnumerable<CompanyCardRate> GetByJuridicalPersonId(Guid id, Metadata meta = null) 
    {
        var query = GetAll().Where(e => e.CompanyId == id || e.CardOperatorId == id);

        return (meta == null) ? query : _repository.ExecuteQuery(query, meta);
    }

    private IEnumerable<CompanyCardRate> GetByJuridicalPersonDocument(string document, Metadata meta = null)
    {
        var query = GetAll().Where(e => e.Company.Person.Document.Replace("/", "").Replace(".", "").Replace("-", "").Contains(document) 
                                    || 
                                   e.CardOperator.Person.Document.Replace("/", "").Replace(".", "").Replace("-", "").Contains(document));

        return (meta == null) ? query : _repository.ExecuteQuery(query, meta);
    }

    private static CompanyCardRate ConvertToEntity(CompanyCardRateInsertUpdateViewModel model)
    {
        if (model == null)
            return null;

        return new CompanyCardRate(model.Rate, model.CompanyId, model.CardOperatorId);
    }

    private static CompanyCardRateViewModel ConvertToViewModel(CompanyCardRate entity)
    {
        if (entity == null)
            return null;

        var operatorName = entity.CardOperator?.Person?.Name;
        var company = entity.Company;
        return new CompanyCardRateViewModel(entity.Id, entity.Rate, entity.CompanyId, entity.CardOperatorId, operatorName, company.Person?.Name, company.Person?.Document);
    }
}