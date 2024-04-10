using System;
using System.Collections.Generic;
using System.Linq;
using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace AgilleApi.Domain.Services.Commom;

public class TaxpayerServices : SessionServices
{
    private readonly ITaxpayerRepository _repository;
    private readonly UserServices _userServices;
    private readonly JuridicalPersonServices _juridicalPersonServices;
    private readonly MiddlewareClient _middlewareClient;

    public TaxpayerServices(IHttpContextAccessor httpContextAccessor, ITaxpayerRepository taxpayerRepository, UserServices userServices, 
        JuridicalPersonServices juridicalPersonServices, MiddlewareClient middlewareClient)
        : base(httpContextAccessor)
    {
        _repository = taxpayerRepository;
        _userServices = userServices;
        _juridicalPersonServices = juridicalPersonServices;
        _middlewareClient = middlewareClient;
    }

    public IEnumerable<TaxpayerViewModel> View(Guid id)
    {
        var taxpayerData = GetByUserId(id).Select(e => ConvertToViewModel(e)).ToList();

        ThrowIfNull(taxpayerData, "Taxpayer");

        return taxpayerData;
    }

    public TaxpayerViewModel Insert(InsertTaxpayerViewModel model)
    {
        var user = _middlewareClient.GetUserInfos(new List<Guid>() { model.UserId}).FirstOrDefault();
        var company = _juridicalPersonServices.View(model.JuridicalPersonId);

        ThrowIfNull(user, "User");
        ThrowIfNull(company, "Company");

        if (TaxpayerExist(model.UserId, company.Id))
            throw new BadRequestException("Inválido. Esse usuário já está cadastrado como contribuinte dessa empresa.");

        var entity = new Taxpayer(model.UserId, company.Id);
        _repository.Insert(entity);

        return ConvertToViewModel(Get(entity.Id));
    }

    public void Delete(InsertTaxpayerViewModel model)
    {
        var entity = Get(model.UserId, model.JuridicalPersonId);
        ThrowIfNull(entity, "Taxpayer");

        _repository.Delete(entity);
    }

    public bool TaxpayerExist(Guid userId, Guid juridicalPersonId)
    {
        return _repository
                .Get(e => e.UserId == userId && e.JuridicalPersonId == juridicalPersonId)
                .Any();
    }

    public bool IsTaxpayerOfCompany(Guid userId, Guid companyId)
    {
        return _repository.Get(e => e.UserId == userId && e.JuridicalPersonId == companyId).Any();
    }

    public Guid? GetCompanyIdFromUser(Guid userId)
    {
        return _repository.Get(e => e.UserId == userId)?.Select(e => e.JuridicalPersonId).FirstOrDefault();
    }

    private Taxpayer Get(Guid id)
    {
        return GetAll()
                .Where(e => e.Id == id)
                .FirstOrDefault();
    }

    private Taxpayer Get(Guid userId, Guid companyId)
    {
        return GetAll()
                .Where(e => e.UserId == userId && e.JuridicalPerson.Id == companyId)
                .FirstOrDefault();
    }

    private List<Taxpayer> GetByUserId(Guid userId)
    {
        return GetAll()
                .Where(e => e.UserId == userId)
                .ToList();
    }

    private IQueryable<Taxpayer> GetAll()
    {
        return _repository
                .Query()
                .Include(e => e.JuridicalPerson)
                .ThenInclude(j => j.Person);
    }

    private TaxpayerViewModel ConvertToViewModel(Taxpayer entity)
    {
        var userViewModel = _middlewareClient.GetUserInfos(new List<Guid> { entity.UserId }).FirstOrDefault();
        var companyViewModel = _juridicalPersonServices.ConvertToViewModel(entity.JuridicalPerson);

        return new TaxpayerViewModel(entity.Id, userViewModel, companyViewModel);
    }

    private static void ThrowIfNull(object entity, string message = "Entity")
    {
        if (entity == null)
            throw new NotFoundException($"{message} not found.");
    }
}