using AgilleApi.Domain.Entities;

namespace AgilleApi.Domain.ViewModel;

public class ProprietyCharacteristicsViewModel
{
    public ProprietyCharacteristicsViewModel() { }
    public ProprietyCharacteristicsViewModel(ProprietyCharacteristics characteristics) 
    {
        HasElectricity = characteristics.HasElectricity;
        HasPhone = characteristics.HasPhone;
        HasInternet = characteristics.HasInternet;
        HasNaturalWaterSpring = characteristics.HasNaturalWaterSpring;
        HasFishingPotential = characteristics.HasFishingPotential;
        HasPotentialForEcotourism = characteristics.HasPotentialForEcotourism;
    }

    public bool HasElectricity { get; set; } = false;
    public bool HasPhone { get; set; } = false;
    public bool HasInternet { get; set; } = false;
    public bool HasNaturalWaterSpring { get; set; } = false;
    public bool HasFishingPotential { get; set; } = false;
    public bool HasPotentialForEcotourism { get; set; } = false;
}
