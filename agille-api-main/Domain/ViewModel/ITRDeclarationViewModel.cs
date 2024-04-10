
using AgilleApi.Domain.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class ITRDeclarationEntryViewModel
{
    public decimal Area { get; set; }
    public decimal? LandValue { get; set; }
    public string Description { get; set; }
}
public class ITRDeclarationViewModel {
    public List<ITRDeclarationEntryViewModel> Declarations { get; set; }
    public decimal TotalITRValue { get; set; }
};

public class BareLandValuesViewModel {
    public BareLandValuesViewModel() { }
    public BareLandValuesViewModel(
        decimal goodAptitude,
        decimal regularAptitude,
        decimal restrictedFitness,
        decimal plantedPastures,
        decimal forestryOrNaturalPasture,
        decimal preservationOfFaunaOrFlora,
        decimal goodSuitabilityFarming,
        decimal regularFitnessFarming,
        decimal restrictedAptitudeFarming,
        decimal plantedPasture,
        string report
        )
    {
        GoodAptitude = goodAptitude;
        RegularAptitude = regularAptitude;
        RestrictedFitness = restrictedFitness;
        PlantedPastures = plantedPastures;
        ForestryOrNaturalPasture = forestryOrNaturalPasture;
        PreservationOfFaunaOrFlora = preservationOfFaunaOrFlora;
        GoodSuitabilityFarming = goodSuitabilityFarming;
        RegularFitnessFarming = regularFitnessFarming;
        RestrictedAptitudeFarming = restrictedAptitudeFarming;
        PlantedPasture = plantedPasture;
        Report = report;
    }

    public decimal GoodAptitude { get; set; } = 0;
    public decimal RegularAptitude { get; set; } = 0;
    public decimal RestrictedFitness { get; set; } = 0;
    public decimal PlantedPastures { get; set; } = 0;
    public decimal ForestryOrNaturalPasture { get; set; } = 0;
    public decimal PreservationOfFaunaOrFlora { get; set; } = 0;
    public decimal GoodSuitabilityFarming { get; set; } = 0;
    public decimal RegularFitnessFarming { get; set; } = 0;
    public decimal RestrictedAptitudeFarming { get; set; } = 0;
    public decimal PlantedPasture { get; set; } = 0;
    public string Report { get; set; }
}


public class TaxPayerDeclarationParams
{
    public string Year { get; set; }
    public string Cib { get; set; }

    public Guid? ProprietyId { get; set; } = null;
    public Guid? UserId { get; set; } = null;
    public string ProprietyName { get; set; }
}

public class TaxPayerDeclarationViewModel
{
    public TaxPayerDeclarationViewModel() { }
    public TaxPayerDeclarationViewModel(decimal total, decimal permanentPreservationArea, decimal legalReserveArea, decimal taxableArea, decimal areaOccupiedWithWorks, decimal usableArea, decimal areaWithReforestation, decimal areaUsedInRuralActivity, string number)
    {
        Total = total;
        PermanentPreservationArea = permanentPreservationArea;
        LegalReserveArea = legalReserveArea;
        TaxableArea = taxableArea;
        AreaOccupiedWithWorks = areaOccupiedWithWorks;
        UsableArea = usableArea;
        AreaWithReforestation = areaWithReforestation;
        AreaUsedInRuralActivity = areaUsedInRuralActivity;
        Number = number;
    }

    public string Number { get; set; }
    public decimal Total { get; set; }
    public decimal PermanentPreservationArea { get; set; }
    public decimal LegalReserveArea { get; set; }
    public decimal TaxableArea { get; set; }
    public decimal AreaOccupiedWithWorks { get; set; }
    public decimal UsableArea { get; set; }
    public decimal AreaWithReforestation { get; set; }
    public decimal AreaUsedInRuralActivity { get; set; }

    public string Cib { get; set; }
    public string Owner { get; set; }
    public string Year { get; set; }

    [JsonIgnore]
    public string OwnerDocument { get; set; }
}

public class TaxPayerDeclarationDashboardItemViewModel : TaxPayerDeclarationViewModel
{
    public TaxPayerDeclarationDashboardItemViewModel(string year, decimal total, decimal permanentPreservationArea, decimal legalReserveArea, decimal taxableArea, decimal areaOccupiedWithWorks, decimal usableArea, decimal areaWithReforestation, decimal areaUsedInRuralActivity, string number) 
        : base(total, permanentPreservationArea, legalReserveArea, taxableArea, areaOccupiedWithWorks, usableArea, areaWithReforestation, areaUsedInRuralActivity, number)
    {
        Year = year;
    }
    public TaxPayerDeclarationDashboardItemViewModel(TaxPayerDeclaration entity, string owner = "", string cib = "")
    {
        if (entity == null)
            return;

        Year = entity.Year;
        Total = entity.Total;
        PermanentPreservationArea = entity.PermanentPreservationArea;
        LegalReserveArea = entity.LegalReserveArea;
        TaxableArea = entity.TaxableArea;
        AreaOccupiedWithWorks = entity.AreaOccupiedWithWorks;
        UsableArea = entity.UsableArea;
        AreaWithReforestation = entity.AreaWithReforestation;
        AreaUsedInRuralActivity = entity.AreaUsedInRuralActivity;

        Owner = entity.Person?.Name ?? owner;
        Cib = cib;
    }

    public string Year { get; set; }
}

public class TaxPayerDeclarationDashBoardViewModel : ProprietyCARDataViewModel
{
    public TaxPayerDeclarationDashBoardViewModel(Guid? proprietyId, string cAR, string cIB, string owner, string name, TaxPayerDeclarationDashboardItemViewModel declarations)
        : base(proprietyId, cAR, cIB, owner, name)
    {
        Declarations = declarations;
        Owner = declarations?.Owner ?? owner;
    }

    public TaxPayerDeclarationDashBoardViewModel(Guid? proprietyId, string cAR, string cIB, string owner, string name)
        : base(proprietyId, cAR, cIB, owner, name)
    { }

    public TaxPayerDeclarationDashboardItemViewModel Declarations { get; set; }
}

public class DeclarationImportProprietyData
{
    public string Name { get; set; }
    public string CAR { get; set; }
    public string Situation { get; set; }
    public string IncraCode { get; set; }
    public double TotalArea { get; set; }
    public double LegalReserveArea { get; set; }

    public ProprietyAddressViewModel Address { get; set; }
}