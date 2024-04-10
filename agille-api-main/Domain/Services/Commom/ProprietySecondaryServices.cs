using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Exceptions;
using AgilleApi.Domain.Extensions;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.Interfaces.Services;
using AgilleApi.Domain.Services.Specialize.PDF.Interfaces;
using AgilleApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom;

public class ProprietySecondaryServices : IProprietySecondaryServices
{
    private readonly IProprietyRepository _repository;
    private readonly IProprietyOwnerRepository _proprietyOwnerRepository;
    private readonly IEntitiesServices _entitiesServices;
    private readonly IPDFGenerator _pDFGenerator;
    private readonly IBareLandValueServices _bareLandValueServices;

    public ProprietySecondaryServices(
        IProprietyRepository repository,
        IProprietyOwnerRepository proprietyOwnerRepository,
        IEntitiesServices entitiesServices,
        IPDFGenerator pDFGenerator,
        IBareLandValueServices bareLandValueServices)
    {
        _repository = repository;
        _proprietyOwnerRepository = proprietyOwnerRepository;
        _entitiesServices = entitiesServices;
        _pDFGenerator = pDFGenerator;
        _bareLandValueServices = bareLandValueServices;
    }

    public IEnumerable<ShortProprietyViewModel> ProprietiesByOwnerId(Guid ownerId)
    {
        return _repository
                .Query()
                .Where(e => e.Owners.Where(e => e.OwnerId == ownerId).Any())
                .Select(e => new ShortProprietyViewModel(e.Id, e.CibNumber, e.Name));
    }

    public bool ProprietyExist(Guid? id)
    {
        return _repository.Query().Where(e => e.Id == id).Any();
    }

    public void SetOwnerProprieties(Guid ownerId, List<Guid> proprieties)
    {
        var allProps = GetOwnering(ownerId);

        var toInsert = CreateOwnerProprieties(ownerId, proprieties);

        if (toInsert.Any())
            _proprietyOwnerRepository.InsertMany(toInsert);

        var toDelete = allProps.Where(e => !proprieties.Contains(e.ProprietyId)).ToList();
        if (toDelete.Any())
            _proprietyOwnerRepository.DeleteMany(toDelete);
    }

    public List<ProprietyOwners> CreateOwnerProprieties(Guid ownerId, List<Guid> proprieties)
    {
        if (proprieties == null)
            proprieties = new();

        var allProps = GetOwnering(ownerId);

        var toInsert = new List<ProprietyOwners>();

        proprieties.ForEach(id => {
            if (!allProps.Where(e => e.ProprietyId == id).Any())
                toInsert.Add(new ProprietyOwners(id, ownerId));
        });

        return toInsert;
    }

    private List<ProprietyOwners> GetOwnering(Guid? ownerId)
    {
        return _proprietyOwnerRepository
                .Query()
                .Where(e => e.OwnerId == ownerId)
                .ToList();
    }

    public Dictionary<string, Guid> GetProprietyIds(List<string> cibs)
    {
        return _repository
                .Query()
                .Where(e => cibs.Contains(e.CibNumber))
                .ToDictionary(e => e.CibNumber, e => e.Id);
    }

    public ReportResponseViewModel AreaReport(ProprietyAreaReportFilterViewModel model)
    {
        if (string.IsNullOrEmpty(model.Year))
            model.Year = DateTime.UtcNow.Year.ToString();

        var query = _repository
                    .Query()
                    .Include(e => e.Coordenates)
                    .Include(e => e.Owners)
                    .ThenInclude(e => e.Owner)
                    .WhereIf(!model.AllProprieties, propriety => propriety.Name.ToLower().Contains(model.Name)
                                                    ||
                                                    propriety.CibNumber.Contains(model.Cib)
                                                    ||
                                                    propriety.Owners.Any(owner => owner.Owner.Document.Contains(model.Document)));

        ThrowExceptionIfQueryIsEmpty(query);

        var entityViewModel = _entitiesServices.View();
        var barelandValues = _bareLandValueServices.GetByYear(model.Year);

        var propriety = (!model.AllProprieties) ? query.FirstOrDefault() : null;
        var coodenates = propriety?.Coordenates?.FirstOrDefault();
        var owner = propriety?.Owners?.FirstOrDefault()?.Owner;

        var reportData = new ProprietyAreaReportViewModel()
        {
            AllProprieties = model.AllProprieties,

            Image = _entitiesServices.GetBase64Image(),
            EntityName = entityViewModel.Name,
            StateInitials = entityViewModel?.Address?.StateName,
            Year = model.Year,

            Cib = propriety?.CibNumber ?? "--" ,
            NIRF = propriety?.CertificateNumber ?? "--",
            Name = propriety?.Name ?? "--",
            Area = propriety?.DeclaredArea.ToString() ?? "--",
            Lat = coodenates?.Lat.ToString() ?? "--",
            Long = coodenates?.Lng.ToString() ?? "--",
            Owner = owner?.Name ?? "--",

            TableLines = new()
            {
                new()
                {
                    Title = "Lavoura Aptidão Boa",
                    Value = barelandValues.GoodAptitude,
                    TotalArea = query.Sum(propriety => propriety.GoodSuitabilityFarming)
                },
                new()
                {
                    Title = "Lavoura Aptidão Regular",
                    Value = barelandValues.RegularAptitude,
                    TotalArea = query.Sum(propriety => propriety.RegularFitnessFarming)
                },
                new()
                {
                    Title = "Lavoura Aptidão Restrita",
                    Value = barelandValues.RestrictedFitness,
                    TotalArea = query.Sum(propriety => propriety.RestrictedAptitudeFarming)
                },
                new()
                {
                    Title = "Pastagem Plantada",
                    Value = barelandValues.PlantedPastures,
                    TotalArea = query.Sum(propriety => propriety.PlantedPasture)
                },
                new()
                {
                    Title = "Silvicultura ou Pastagem Natural",
                    Value = barelandValues.ForestryOrNaturalPasture,
                    TotalArea = query.Sum(propriety => propriety.BusyWithImprovements) + query.Sum(propriety => propriety.Reforestation)
                },
                new()
                {
                    Title = "Preservação da Fauna ou Flora",
                    Value = barelandValues.PreservationOfFaunaOrFlora,
                    TotalArea = query.Sum(propriety => propriety.PermanentPreservation) + query.Sum(propriety => propriety.Reforestation)
                }
            }
        };

        var bytes = _pDFGenerator.Generate(reportData, "ProprietyArea").Result;
        return new()
        {
            Content = bytes,
            ContentType = "application/pdf",
            Title = "Report.pdf"
        };
    }

    private static void ThrowExceptionIfQueryIsEmpty(IQueryable<Propriety> query)
    {
        if (!query.Any())
            throw new ConflictException("Proprieties not found");
    }
}
