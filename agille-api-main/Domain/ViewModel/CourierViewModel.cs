using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class CourierResponseViewModel
{
    public CourierResponseViewModel() { }
    public CourierResponseViewModel(byte[] file, List<string> messages, bool fail = true)
    {
        File = file;
        Messages = messages;
        Fail = fail;
    }

    public byte[] File { get; set; }
    public List<string> Messages { get; set; }
    public bool Fail { get; set; } = false;
}

public class CourierAddressViewModel
{
    public string Street { get; set; }
    public string Number { get; set; }
    public string CityName { get; set; }
    public string StateName { get; set; }
    public string District { get; set; }
    public string Complement { get; set; }
    public string ZipCode { get; set; }
    public string Description { get; set; }
}