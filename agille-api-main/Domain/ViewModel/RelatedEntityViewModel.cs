using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Enums;
using AgilleApi.Domain.Interfaces.Shared;
using AgilleApi.Domain.Shared;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class RelatedEntityParams
{
	public string Name { get; set; }
	public string Document { get; set; }
	public RelatedEntityType? Type { get; set; }
	public Guid? AddressId { get; set; }
}

public abstract class RelatedEntityViewModelBase
{
	public string Name { get; set; }
	public string Document { get; set; }
	public string ImageUrl { get; set; }
	public RelatedEntityType Type { get; set; }
}

public class RelatedEntityViewModel : RelatedEntityViewModelBase
{
	public Guid Id { get; set; }
	public DateTime CreatedAt { get; set; }
	public string TypeDescription { get => Type.GetDescription(); }
	public AddressViewModel Address { get; set; }
}

public class RelatedEntityInsertUpdateViewModel : RelatedEntityViewModelBase
{ 
	public AddressInsertUpdateViewModel Address { get; set; }
}