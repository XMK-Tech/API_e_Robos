//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;

//namespace AgilleApi.Domain.Entities
//{
//  public class PhonePerson
//  {
//    public Phone Phone { get; set; }
//    public Guid PhoneId { get; set; }
//    public Person Person { get; set; }
//    public Guid PersonId { get; set; }
//  }

//  public class PhonePersonMap : IEntityTypeConfiguration<PhonePerson>
//  {
//    public void Configure(EntityTypeBuilder<PhonePerson> builder)
//    {
//      builder.ToTable("PhonePerson");
//      builder.HasKey(h => new { h.PhoneId, h.PersonId });

//      builder.HasOne(h => h.Phone)
//        .WithMany(w => w.PhonePersons)
//        .HasForeignKey(h => h.PhoneId)
//        .OnDelete(DeleteBehavior.Restrict)
//        .IsRequired();

//      builder.HasOne(h => h.Person)
//        .WithMany(w => w.PhonePersons)
//        .HasForeignKey(h => h.PersonId)
//        .OnDelete(DeleteBehavior.Cascade)
//        .IsRequired();
//    }
//  }
//}