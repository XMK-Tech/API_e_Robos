using AgilleApi.Domain.Enums;
using System;

namespace AgilleApi.Domain.ViewModel;

public class CultureTypeParams
{
	public string Name { get; set; }
	public CultureTypeOptions? Type { get; set; }
	public bool? IsDefault { get; set; }
	public bool? IsChecked { get; set; }
}

public abstract class CultureTypeViewModelBase
{
	public string Name { get; set; }	
	public CultureTypeOptions Type { get; set; }
	public bool IsChecked { get; set; }
}

public class CultureTypeViewModel : CultureTypeViewModelBase
{
	public Guid Id { get; set; }
	public Guid? UserId { get; set; }
	public DateTime CreatedAt { get; set; }
	public bool IsDefault { get; set; }
	public string TypeDescription { get => Type.GetDescription(); }
}

public class CultureTypeInsertUpdateViewModel : CultureTypeViewModelBase
{ }

public class CultureTypeUpdateCheckStateViewModel
{
	public Guid CultureId { get; set; }
	public bool IsChecked { get; set; }
}