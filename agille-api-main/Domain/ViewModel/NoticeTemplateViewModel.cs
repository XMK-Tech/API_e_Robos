using System;
using System.ComponentModel.DataAnnotations;
using AgilleApi.Domain.Enums;

namespace AgilleApi.Domain.ViewModel;

public class NoticeTemplateParams
{
    public NoticeType? Type { get; set; }
    public Module? Module { get; set; } = Enums.Module.ISS;
}

public class NoticeTemplateInsertUpdateViewModel
{
    [Required(ErrorMessage = "O campo HtmlTemplate é obrigatório")]
    public string HtmlTemplate { get; set; }
    public string Name { get; set; }
    public NoticeType Type { get; set; }
    public int DaysToExpire { get; set; }
    public Module Module { get; set; } = Module.ISS;
}

public class NoticeTemplateViewModel
{
    public Guid Id { get; set; }
    public string HtmlTemplate { get; set; }
    public string Name {get;set;}
    public NoticeType Type { get; set; }
    public int DaysToExpire { get; set; }
    public Module Module { get; set; }
}