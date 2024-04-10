using System;

namespace AgilleApi.Domain.ViewModel;

public abstract class TaxProcessViewModelBase
{
}

public class TaxProcessViewModel : TaxProcessViewModelBase
{
    public Guid Id { get; set; }
    public DateTime CreatedAt { get; set; }
}

public class TaxProcessInsertUpdateViewModel : TaxProcessViewModelBase
{

}

public class TaxProcessPrintModel
{
    public string EntityName { get; set; }
    public string Image { get; set; }
    public string StateInitials { get; set; }

    public string Auditor { get; set; }
}