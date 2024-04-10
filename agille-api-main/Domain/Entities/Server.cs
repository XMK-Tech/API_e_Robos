using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities
{
    public class Server : Entity, ILoggable
    {
        public Server(){}
        public Server(Guid personId, DateTime admissionDate, string cTPSNumber, string cTPSSeries, string registration, string pIS_PASEPNumber, ServerCategory serverCategory)
        {
            PersonId = personId;
            AdmissionDate = admissionDate;
            CTPSNumber = cTPSNumber;
            CTPSSeries = cTPSSeries;
            Registration = registration;
            PIS_PASEPNumber = pIS_PASEPNumber;
            ServerCategory = serverCategory;
        }
        public void Update(DateTime admissionDate, string cTPSNumber, string cTPSSeries, string registration, string pIS_PASEPNumber, ServerCategory serverCategory)
        {
            AdmissionDate = admissionDate;
            CTPSNumber = cTPSNumber;
            CTPSSeries = cTPSSeries;
            Registration = registration;
            PIS_PASEPNumber = pIS_PASEPNumber;
            ServerCategory = serverCategory;
        }

        public Guid PersonId { get; set; }
        public PersonBase Person { get; set; }

        public DateTime AdmissionDate { get; set; }
        public string CTPSNumber { get; set; }
        public string CTPSSeries { get; set; }
        public string Registration { get; set; }
        public string PIS_PASEPNumber { get; set; }
        public ServerCategory ServerCategory { get; set; }
    }
    public class ServerMap : IEntityTypeConfiguration<Server>
    {
        public void Configure(EntityTypeBuilder<Server> builder)
        {
            builder.ToTable("Server");
            builder.HasKey(h => h.Id);

            builder.HasOne(s => s.Person)
                .WithOne(ad => ad.Server)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey<Server>(ad => ad.PersonId);
        }
    }
}
