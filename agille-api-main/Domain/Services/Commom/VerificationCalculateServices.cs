using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using AgilleApi.Domain.Extensions;

namespace AgilleApi.Domain.Services.Commom;

public class VerificationCalculateServices : IVerificationCalculateServices
{
    private readonly IVerificationRepository _repository;
    private readonly IIndexServices _indexServices;
    private readonly IAgiprevCalculationServices _agiprevCalculationServices;

    public VerificationCalculateServices(IVerificationRepository repository,
        IIndexServices indexServices,
        IAgiprevCalculationServices agiprevCalculationServices)
    {
        _repository = repository;
        _indexServices = indexServices;
        _agiprevCalculationServices = agiprevCalculationServices;
    }

    public IEnumerable<VerificationViewModel> List(Metadata meta, VerificationParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, @params, meta);

        var results = _repository.ExecuteGenericQuery(query, meta, ViewModelConverter());

        UpdateValueToday(results);
        return results;
    }
    private void UpdateValueToday(List<VerificationViewModel> results)
    {
        foreach (var item in results)
        {
            var exercise = item.Exercise.Split('/');
            var month = exercise[0];
            var year = exercise[1];

            var amountToArbitrate = _agiprevCalculationServices.CalculateAmountToArbitrate(year, month);
            item.ValueToArbitrate = decimal.Round(amountToArbitrate, 2, MidpointRounding.AwayFromZero);

            var selicRate = _indexServices.GetSelicRate(year, month);
            var updateValue = item.ValueToArbitrate + (item.ValueToArbitrate * (selicRate / 100));
            item.UpdateValue = decimal.Round(updateValue, 2, MidpointRounding.AwayFromZero);
        }
    }
    private static IQueryable<Verification> Filter(IQueryable<Verification> query, VerificationParams @params, Metadata meta)
    {
        query = query
            .WhereInRange(@params.MinArbitrate, @params.MaxArbitrate, fpm => fpm.ValueToArbitrate)
            .WhereInRange(@params.MinUpdate, @params.MaxUpdate, fpm => fpm.UpdateValue)
            .WhereIf(@params.Exercise, e => e.Exercice.Contains(@params.Exercise))
            .WhereIf(@params.Year, e => e.Exercice.Contains(@params.Year));

        if (meta == null)
            return query;

        Expression<Func<Verification, object>> orderBy = meta.SortColumn.ToLower()
            switch
        {
            "year" => verify => verify.Exercice,
            "exercise" => verify => verify.Exercice,
            "value" => verify => verify.ValueToArbitrate,
            "updatedValue" => verify => verify.UpdateValue,
            _ => verify => verify.CreatedAt,
        };

        if (string.IsNullOrEmpty(meta.SortColumn))
            meta.SortColumn = "createdAt";

        query = query.Sort(meta.SortDirection, orderBy);

        return query;
    }
    private static Expression<Func<Verification, VerificationViewModel>> ViewModelConverter()
    {
        return verification => new VerificationViewModel()
        {
            Id = verification.Id,
            CreatedAt = verification.CreatedAt,

            ValueToArbitrate = verification.ValueToArbitrate,
            UpdateValue = verification.UpdateValue,
            Exercise = verification.Exercice,
        };
    }
}