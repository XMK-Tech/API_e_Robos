using AgilleApi.Domain.Services.Specialize;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;

namespace AgilleApi.Domain.ViewModel
{
  public class CurrencyListParams
  {
    public string Code { get; set; }
    public string Name { get; set; }
    [BindNever]
    public string NameWithoutAccent { get => TextFilter.RemoveAccents(Name); private set => TextFilter.RemoveAccents(Name); }
    public string Description { get; set; }
  }
  public class CurrencyListViewModel
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Format { get; set; }
  }
}
