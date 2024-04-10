using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel;

public class ProprietyContactViewModel
{
    public ProprietyContactViewModel() { }
    public ProprietyContactViewModel(ProprietyContact contact) 
    { 
        Email = contact.Email;
        PhoneNumber = contact.PhoneNumber;
        PhoneType = contact.PhoneType;
        Fax = contact.Fax;
    }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public PhoneType PhoneType { get; set; } = PhoneType.Null;
    public string Fax { get; set; }
}
