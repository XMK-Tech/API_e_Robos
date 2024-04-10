using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AgilleApi.Domain.Entities
{
    public class Param : Entity
    {
        protected Param()
        {

        }
        public Param(string code, string description)
        {
            Code = code;
            Description = description;
        }

        public string Code { get; set; }
        public string Description { get; set; }
    }

    public class ParamMap : IEntityTypeConfiguration<Param>
    {
        public void Configure(EntityTypeBuilder<Param> builder)
        {
            builder.ToTable("Param");
            builder.HasKey(h => h.Id);

            builder.Property(e => e.Code).HasMaxLength(200).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(200).IsRequired();
        }
    }
}
