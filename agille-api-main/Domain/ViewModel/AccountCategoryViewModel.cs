using AgilleApi.Domain.Services.Specialize;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AgilleApi.Domain.ViewModel
{
  public class AccountCategoryParams
  {
    public Guid Id { get; set; }
    public string Name { get; set; }
    [BindNever]
    public string NameWithoutAccent { get => TextFilter.RemoveAccents(Name); private set => TextFilter.RemoveAccents(Name); }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public bool? AlwaysShowAccountCategory { get; set; }
  }
  public class AccountCategoryChildrenParams : AccountCategoryParams
  {
    public bool DisplayChildren { get; set; }
  }
  public class AccountCategoryViewModel
  {
    public AccountCategoryViewModel(Guid? id, string name, string shortDescription, string description, bool? showAccountCategory, bool? showCurrency, Guid? accountCurrencyId, string accountCurrencyName, string accountCurrencyFormat, Guid? parentCategoryId)
    {
      

      Id = id;
      Name = name;
      ShortDescription = shortDescription;
      Description = description;
      ShowAccountCategory = showAccountCategory;
      ShowCurrency = showCurrency;
      AccountCurrency = new AccountCurrencyViewModel(accountCurrencyId, accountCurrencyName, accountCurrencyFormat);
      ParentCategoryId = parentCategoryId;
    }

    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string ShortDescription { get; set; }
    public string Description { get; set; }
    public bool? ShowAccountCategory { get; set; }
    public bool? ShowCurrency { get; set; }
    public AccountCurrencyViewModel AccountCurrency { get; set; }
    public Guid? ParentCategoryId { get; set; }
  }
  public class AccountCurrencyViewModel
  {
    public AccountCurrencyViewModel(Guid? id, string name, string format)
    {
      Id = id;
      Name = name;
      Format = format;
    }

    public Guid? Id { get; set; }
    public string Name { get; set; }
    public string Format { get; set; }
  }

  public class AccountCategoryChildren
  {
    public AccountCategoryChildren(AccountCategoryViewModel accountCategory)
    {
      AccountCategory = accountCategory;
    }

    public AccountCategoryViewModel AccountCategory { get; set; }
    public List<AccountCategoryChildren> ChildAccountCategory { get; set; }
  }

  public class AccountCategoryInsertUpdateViewModel
  {
    [Required]
    public string Name { get; set; }
    [Required]
    public string ShortDescription { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public bool? ShowAccountCategory { get; set; }
    [Required]
    public bool? ShowCurrency { get; set; }
    [Required]
    public Guid? AccountCurrencyId { get; set; }
    [Required]
    public Guid? ParentCategoryId { get; set; }
  }
}
