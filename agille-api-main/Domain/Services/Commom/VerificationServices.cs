using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom;

public class VerificationServices : IVerificationServices
{
    private readonly IVerificationRepository _repository;

    public VerificationServices(IVerificationRepository repository)
    {
        _repository = repository;
    }

    public VerificationViewModel View(Guid id)
    {
        var entity = _repository
                        .Query()
                        .Where(x => x.Id == id)
                        .Select(ViewModelConverter())
                        .FirstOrDefault();
        if (entity == null)
            throw new NotFoundException("Verification Not Found");

        return entity;
    }

    public FilterSumViewModel GetFilterSum(VerificationParams @params)
    {
        var query = _repository.Query();
        query = Filter(query, @params, null);

        return new()
        {
            Sum = query.Select(e => e.UpdateValue).Sum(),
            Count = query.Count()
        };
    }

    public void InsertCompetenceIfNotExists(DateTime competence)
    {
        if (Exists(competence))
            return;

        var exercise = BuildCompetenceExercise(competence);
        var entity = new Verification(0, 0, exercise);

        _repository.Insert(entity);
    }

    private bool Exists(DateTime competence)
    {
        var exercise = BuildCompetenceExercise(competence);
        return _repository
                .Query()
                .Where(verification => verification.Exercice == exercise)
                .Any();
    }

    private static string BuildCompetenceExercise(DateTime competence)
    {
        var month = competence.Month.ToString().PadLeft(2, '0');
        return $"{month}/{competence.Year}";
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