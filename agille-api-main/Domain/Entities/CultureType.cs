using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.Entities;

public class CultureType : Entity, ILoggable
{
	public CultureType() { }
	public CultureType(string name, Guid? userId, CultureTypeOptions type, bool isDefault = false, bool isChecked = false)
	{
		Name = name;
		UserId = userId;
		Type = type;
		IsDefault = isDefault;
		IsChecked = isChecked;
	}

	public string Name {  get; set; }
	public Guid? UserId {  get; set; }
	public CultureTypeOptions Type {  get; set; }
	
	public bool IsDefault { get; set; }
	public bool IsChecked { get; set; }

	public ICollection<CultureDeclaration> Declarations { get; set; }
}

public class CultureTypeMap : IEntityTypeConfiguration<CultureType>
{
	public void Configure(EntityTypeBuilder<CultureType> builder)
	{
		builder.HasKey(h => h.Id);

		builder.Property(e => e.IsDefault).HasDefaultValue(false);
		builder.Property(e => e.IsChecked).HasDefaultValue(false);
	}
}