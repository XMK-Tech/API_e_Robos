using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.ViewModel;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class BareLandValueServices : IBareLandValueServices
{
    private readonly IBareLandValueRepository _repository;

    public BareLandValueServices(IBareLandValueRepository repository)
    {
        _repository = repository;
    }

    public BareLandValuesViewModel GetByYear(string year)
    {
        var entity = Get(year) ?? new();
        return ConvertToViewModel(entity);
    }

    public BareLandValuesViewModel UpSert(BareLandValuesViewModel model, string year)
    {
        ValidateYear(year);
        return Exist(year) ? Update(model, year) : Insert(model, year);
    }

    private BareLandValuesViewModel Insert(BareLandValuesViewModel model, string year)
    {
        var entity = ConvertToEntity(model, year);
        _repository.Insert(entity);

        return ConvertToViewModel(entity);
    }

    private BareLandValuesViewModel Update(BareLandValuesViewModel model, string year)
    {
        var entity = Get(year);
        ApplyEntityData(entity, model);

        _repository.Update(entity);

        return ConvertToViewModel(entity);
    }

    public bool Exist(string year)
    {
        return _repository.Query().Where(e => e.Year == year).Any();
    }

    private BareLandValue Get(string year)
    {
        return _repository.Query().Where(e => e.Year == year).FirstOrDefault();
    }

    private static BareLandValue ApplyEntityData(BareLandValue entity, BareLandValuesViewModel model)
    {
        entity.Report = model.Report;
        entity.GoodAptitude = model.GoodAptitude;
        entity.RegularAptitude = model.RegularAptitude;
        entity.RestrictedFitness = model.RestrictedFitness;
        entity.PlantedPastures = model.PlantedPastures;
        entity.ForestryOrNaturalPasture = model.ForestryOrNaturalPasture;
        entity.PreservationOfFaunaOrFlora = model.PreservationOfFaunaOrFlora;
        entity.GoodSuitabilityFarming = model.GoodSuitabilityFarming;
        entity.RegularFitnessFarming = model.RegularFitnessFarming;
        entity.RestrictedAptitudeFarming = model.RestrictedAptitudeFarming;
        entity.PlantedPasture = model.PlantedPasture;

        return entity;
    }

    private static BareLandValue ConvertToEntity(BareLandValuesViewModel model, string year)
    {
        return new(
            year, 
            model.GoodAptitude, 
            model.RegularAptitude, 
            model.RestrictedFitness, 
            model.PlantedPastures, 
            model.ForestryOrNaturalPasture, 
            model.PreservationOfFaunaOrFlora,
            model.GoodSuitabilityFarming,
            model.RegularFitnessFarming,
            model.RestrictedAptitudeFarming,
            model.PlantedPasture,
            model.Report
        );
    }

    private static BareLandValuesViewModel ConvertToViewModel(BareLandValue entity)
    {
        return new(
            entity.GoodAptitude,
            entity.RegularAptitude,
            entity.RestrictedFitness,
            entity.PlantedPastures,
            entity.ForestryOrNaturalPasture,
            entity.PreservationOfFaunaOrFlora,
            entity.GoodSuitabilityFarming,
            entity.RegularFitnessFarming,
            entity.RestrictedAptitudeFarming,
            entity.PlantedPasture,
            entity.Report
        );
    }

    private static void ValidateYear(string year)
    {
        if (string.IsNullOrEmpty(year))
            throw new BadRequestException("O ano informado é inválido.");
    }
}