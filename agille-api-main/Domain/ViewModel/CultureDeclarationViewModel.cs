using AgilleApi.Domain.Enums;
using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel;

public class CultureDeclarationParams
{
	public string CultureName { get; set; }
	
	public CultureTypeOptions? Type { get; set; }
	public Month? Month { get; set; }
	public string Year { get; set; }

	public int? MaleCount { get; set; }
	public int? FemaleCount { get; set; }
	public int? Count { get; set; }
	
	public decimal? Area { get; set; }
	public Guid? ProprietyId { get; set; }
}

public abstract class CultureDeclarationViewModelBase
{
	public Month Month { get; set; }
	
	public int MaleCount { get; set; }
	public int FemaleCount { get; set; }
	public int Count { get; set; }
	public decimal Area { get; set; }
	public Guid CultureId { get; set; }
}

public class CultureDeclarationViewModel : CultureDeclarationViewModelBase
{
	public Guid Id { get; set; }
	public DateTime CreatedAt { get; set; }

	public string Year { get; set; }

	public Guid? UserId { get; set; }
	public Guid ProprietyId { get; set; }
	
	public string CultureName { get; set; }
	public CultureTypeOptions Type { get; set; }
	
	public string TypeDescription { get => Type.GetDescription(); }
	public string MonthDescription { get => Month.GetDescription();  }

	public bool IsChecked { get; set; }
	public bool IsDefault { get; set; }
}

public class CultureDeclarationInsertUpdateViewModel : CultureDeclarationViewModelBase
{
	public Guid ProprietyId { get; set; }
	public string Year { get; set; }
}

public class CultureDeclarationInsertUpdateManyViewModel : CultureDeclarationViewModelBase
{ }

public class ProprietyDeclarationsViewModel
{
	public string Year { get; set; }
	public List<CultureDeclarationInsertUpdateManyViewModel> Declarations { get; set; }
}