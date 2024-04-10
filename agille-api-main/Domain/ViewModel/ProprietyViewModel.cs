using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Services.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AgilleApi.Domain.ViewModel;

public class ProprietyParams
{
    public string? Name { get; set; }
    public string? Cib { get; set; }
    public string? CityName { get; set; }
    public ProprietyType? Type { get; set; }
    public bool? HasSettlement { get; set; }
    public bool? HasPropertyCertificate { get; set; }
    public bool? HasRegularizedLegalReserve { get; set; }
    public bool? HasSquattersInTheArea { get; set; }

}

public abstract class ProprietyViewModelBase
{
    public string LinkedCib { get; set; }
    public string CibNumber { get; set; }
    public string Situation { get; set; }
    public string Name { get; set; }
    public ProprietyType? Type { get; set; } = ProprietyType.Null;
    public double DeclaredArea { get; set; }

    public string IncraCode { get; set; }
    public string MunicipalRegistration { get; set; }
    public string CARNumber { get; set; }
    public string Registration { get; set; }

    public bool HasSettlement { get; set; } = false;
    public string SettlementName { get; set; }
    public SettlementType? SettlementType { get; set; } = Enums.SettlementType.Null;

    public bool HasPropertyCertificate { get; set; } = false;
    public string CertificateNumber { get; set; }

    public bool HasRegularizedLegalReserve { get; set; } = false;
    public double LegalReserveArea { get; set; } = 0;

    public bool HasSquattersInTheArea { get; set; } = false;
    public double OccupancyPercentage { get; set; } = 0;
    public double OccupancyTime { get; set; } = 0;

    public decimal PermanentPreservation { get; set; }
    public decimal LegalReserve { get; set; }
    public decimal BusyWithImprovements { get; set; }
    public decimal Reforestation { get; set; }

    public decimal GoodSuitabilityFarming { get; set; }
    public decimal RegularFitnessFarming { get; set; }
    public decimal RestrictedAptitudeFarming { get; set; }
    public decimal PlantedPasture { get; set; }

    public ProprietyContactViewModel Contact { get; set; }
    public ProprietyCharacteristicsViewModel Characteristics { get; set; }
    public ProprietyAddressViewModel Address { get; set; }
}

public class ProprietyViewModel : ProprietyViewModelBase
{
    public ProprietyViewModel() { }
    public ProprietyViewModel(Propriety propriety)
    {
        Id = propriety.Id;
        CreatedAt = propriety.CreatedAt;
        LastUpdatedAt = propriety.LastUpdateAt;

        LinkedCib = propriety.LinkedCib;
        CibNumber = propriety.CibNumber;
        Situation = propriety.Situation;
        Name = propriety.Name;
        Type = propriety.Type;
        DeclaredArea = propriety.DeclaredArea;

        IncraCode = propriety.IncraCode;
        MunicipalRegistration = propriety.MunicipalRegistration;
        CARNumber = propriety.CARNumber;
        Registration = propriety.Registration;

        HasSettlement = propriety.HasSettlement;
        SettlementName = propriety.SettlementName;
        SettlementType = propriety.SettlementType;

        HasPropertyCertificate = propriety.HasPropertyCertificate;
        CertificateNumber = propriety.CertificateNumber;

        HasRegularizedLegalReserve = propriety.HasRegularizedLegalReserve;
        LegalReserveArea = propriety.LegalReserveArea;

        HasSquattersInTheArea = propriety.HasSquattersInTheArea;
        OccupancyPercentage = propriety.OccupancyPercentage;
        OccupancyTime = propriety.OccupancyTime;

        PermanentPreservation = propriety.PermanentPreservation;
        LegalReserve = propriety.LegalReserve;
        BusyWithImprovements = propriety.BusyWithImprovements;
        Reforestation = propriety.Reforestation;

        GoodSuitabilityFarming = propriety.GoodSuitabilityFarming;
        RegularFitnessFarming = propriety.RegularFitnessFarming;
        RestrictedAptitudeFarming = propriety.RestrictedAptitudeFarming;
        PlantedPasture = propriety.PlantedPasture;

        Owners = propriety.Owners?.Select(item => new ProprietyOwnerViewModel(item)).ToList();
        Location = new(propriety.Coordenates);

        if (propriety.Contact != null)
            Contact = new ProprietyContactViewModel(propriety.Contact);

        if (propriety.Characteristics != null)
            Characteristics = new ProprietyCharacteristicsViewModel(propriety.Characteristics);

        if (propriety.Address != null)
            Address = new ProprietyAddressViewModel(propriety.Address);
        
        if (propriety.Attachments != null)
            Attachments = propriety.Attachments.Select(e => e.Attachment).Select(AttachmentServices.ConvertToViewModel).ToList();
    }

    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime LastUpdatedAt { get; set; }
    public List<ProprietyOwnerViewModel> Owners { get; set; }
    public List<AttachmentViewModel> Attachments { get; set; }
    public ProprietyCoordenateViewModel Location { get; set; }
}

public class ProprietyInsertUpdateViewModel : ProprietyViewModelBase
{
    public ProprietyInsertUpdateViewModel() { }
    public List<Guid> Attachments { get; set; }
    public Guid? FromAttachmentId { get; set; } = null;
    public List<string> OwnersDocument { get; set; }
    public List<CoordenateViewModel> Coordenates { get; set; }
}

public class ProprietyOwnerViewModel
{
    public ProprietyOwnerViewModel() { }
    public ProprietyOwnerViewModel(string name, string document, PersonType type)
    {
        Name = name;
        Document = document;
        Type = type;
    }
    public ProprietyOwnerViewModel(ProprietyOwners owner)
        : this(owner.Owner.Name, owner.Owner.Document, owner.Owner.Type)
    { }   

    public string Name { get; set; }
    public string Document { get; set; }
    public PersonType Type { get; set; }
}

public class ShortProprietyViewModel
{
    public ShortProprietyViewModel() { }
    public ShortProprietyViewModel(Guid id, string cibNumber, string name)
    {
        Id = id;
        CibNumber = cibNumber;
        Name = name;
    }

    public Guid Id { get; set; }
    public string CibNumber { get; set; }
    public string Name { get; set; }
}

public class ProprietyDashboardViewModel
{
    public ProprietyDashboardViewModel() { }
    public ProprietyDashboardViewModel(string entityName, IEnumerable<ProprietyDashboardItem> proprieties)
    {
        EntityName = entityName;
        Proprieties = proprieties;
        ProprietyCount = proprieties?.Count() ?? 0;
    }

    public string EntityName { get; set; }
    public int ProprietyCount { get; set; }
    public IEnumerable<ProprietyDashboardItem> Proprieties { get; set; }
}

public class ProprietyDashboardItem
{
    public ProprietyDashboardItem() { }
    public ProprietyDashboardItem(Guid proprietyId, decimal hectares, bool hasOwnersFromAnotherEntity)
    {
        ProprietyId = proprietyId;
        Hectares = hectares;
        HasOwnersFromAnotherEntity = hasOwnersFromAnotherEntity;
    }

    public Guid ProprietyId { get; set; }
    public decimal Hectares { get; set; }
    public bool HasOwnersFromAnotherEntity { get; set; }
}

public class ProprietyCoordenateViewModel
{
    public ProprietyCoordenateViewModel() { }
    public ProprietyCoordenateViewModel(IEnumerable<CoordenateViewModel> coordenates)
    {
        Count = coordenates.Count();
        Coordenates = coordenates;
    }
    public ProprietyCoordenateViewModel(IEnumerable<Coordenate> coordenates)
    {
        Count = coordenates?.Count() ?? 0;
        Coordenates = coordenates
                        ?.OrderBy(e => e.Index)
                        .Select(e => new CoordenateViewModel(e))
                        .ToList();
    }

    public int Count { get; set; }
    public IEnumerable<CoordenateViewModel> Coordenates { get; set; }
}

public class CoordenateViewModel
{
    public CoordenateViewModel() { }
    public CoordenateViewModel(decimal lat, decimal lng)
    {
        Lat = lat;
        Lng = lng;
    }
    public CoordenateViewModel(Coordenate entity)
        : this(entity.Lat, entity.Lng)
    { }
    
    public decimal Lat { get; set; }
    public decimal Lng { get; set; }
}

public class ProprietyCARDataViewModel
{
    public ProprietyCARDataViewModel(Guid? id, string cAR, string cIB, string owner, string name)
    {
        Id = id;
        CAR = cAR;
        CIB = cIB;
        Owner = owner;
        Name = name;
    }

    public Guid? Id { get; set; }
    public string CAR { get; set; }
    public string CIB { get; set; }
    public string Name { get; set; }
    public string Owner { get; set; }
}

public class ProprietyAreaReportFilterViewModel
{
    public string Year { get; set; }
    public bool AllProprieties { get; set; }

    public string Document { get; set; }
    public string Name { get; set; }
    public string Cib { get; set; }
}

public class ProprietyAreaReportViewModel
{
    public bool AllProprieties { get; set; }

    public string EntityName { get; set; }
    public string StateInitials { get; set; }
    public string Image { get; set; }
    public string Year { get; set; }

    public string AuthenticityCode { get => Guid.NewGuid().ToString(); }

    public decimal Total { get => TableLines.Sum(e => e.TotalValue); }
    public List<ProprietyAreaReportTableLines> TableLines { get; set; }

    public string NIRF { get; set; }
    public string Cib { get; set; }
    public string Owner { get; set; }
    public string Name { get; set; }
    public string Lat { get; set; }
    public string Long { get; set; }
    public string Area { get; set; }
}

public class ProprietyAreaReportTableLines
{
    public string Title { get; set; }
    public decimal Value { get; set; }
    public decimal TotalArea { get; set; }
    public decimal TotalValue { get => Value * TotalArea; }
}
