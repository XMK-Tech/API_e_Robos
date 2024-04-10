using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace AgilleApi.Domain.Entities;

public class CultureDeclaration : Entity, ILoggable
{
	public Month Month { get; set; }
	public string Year { get; set; }

	public decimal Area { get; set; }
	
	public int MaleCount {  get; set; }
	public int FemaleCount {  get; set; }
	public int Count {  get; set; }
	
	public Guid? UserId {  get; set; }
	
	public Guid CultureId {  get; set; }
	public CultureType Culture {  get; set; }
	
	public Guid ProprietyId {  get; set; }
	public Propriety Propriety {  get; set; }
}

public class CultureDeclarationMap : IEntityTypeConfiguration<CultureDeclaration>
{
	public void Configure(EntityTypeBuilder<CultureDeclaration> builder)
	{
		builder.HasKey(h => h.Id);

		builder.HasOne(h => h.Culture)
			.WithMany(h => h.Declarations)
			.HasForeignKey(h => h.CultureId)
			.OnDelete(DeleteBehavior.NoAction)
			.IsRequired();
		
		builder.HasOne(h => h.Propriety)
			.WithMany(h => h.CultureDeclarations)
			.HasForeignKey(h => h.ProprietyId)
			.OnDelete(DeleteBehavior.NoAction)
			.IsRequired();
	}
}