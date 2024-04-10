using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities;

public class ProprietyContact : Entity, ILoggable
{
    public ProprietyContact() { }
    public ProprietyContact(string email, string phoneNumber, PhoneType phoneType, string fax)
    {
        Email = email;
        PhoneNumber = phoneNumber;
        PhoneType = phoneType;
        Fax = fax;
    }

    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public PhoneType PhoneType { get; set; }
    public string Fax { get; set; }
}

public class ProprietyContactMap : IEntityTypeConfiguration<ProprietyContact>
{
    public void Configure(EntityTypeBuilder<ProprietyContact> builder)
    {
        builder.ToTable("ProprietyContact");
        builder.HasKey(h => h.Id);
    }
}
