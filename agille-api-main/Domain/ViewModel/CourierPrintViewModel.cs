using System.Text.Json.Serialization;

namespace AgilleApi.Domain.ViewModel;

public class CourierDataViewModel
{
    public string AdditionalInformation { get; set; }
    public CourierAddressViewModel Recipient { get; set; }
    public CourierAddressViewModel Devolution { get; set; }
    public PersonListViewModel RecipientInfo { get; set; }

    [JsonIgnore]
    public PostOfficeConsumer.enderecoERP ZipcodeRecipientResponse { get; set; }
    [JsonIgnore]
    public PostOfficeConsumer.enderecoERP ZipcodeDevolutionResponse { get; set; }
    [JsonIgnore]
    public string Contract { get; set; }
    [JsonIgnore]
    public string EdicatteWithChecker { get; set; }
    [JsonIgnore]
    public string SenderName { get; set; }
}