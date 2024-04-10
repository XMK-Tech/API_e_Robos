using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities;

public class Verification : Entity
{
    public Verification() { }
    
    public Verification(decimal valuetoarbitrate, decimal updatevalue, string exercice) 
    {
        ValueToArbitrate = valuetoarbitrate;
        UpdateValue = updatevalue;
        Exercice = exercice;
    }

    public decimal ValueToArbitrate { get; set; }  
    public decimal UpdateValue { get; set; }
    public string Exercice { get; set; }
}

public class VerificationMap : IEntityTypeConfiguration<Verification>
{
    public void Configure(EntityTypeBuilder<Verification> builder)
    {
        builder.HasKey(h => h.Id);
    }
}