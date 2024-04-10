using AgilleApi.Domain.Entities;
using System;

namespace AgilleApi.Domain.ViewModel
{
  public class StatusParams
  {
    public Guid Id { get; set; }
    public string Code { get; set; }
    public Guid StatusCategoryId { get; set; }
    public string StatusCategoryCode { get; set; }
  }
  public class StatusViewModel
  {
    public StatusViewModel(Status status)
    {
      Id = status.Id;
      Code = status.Code;
      Name = status.Name;
      Description = status.Description;
      Color = status.Color;
      StatusCategory = new StatusCategoryViewModel(status.StatusCategory);
    }
    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Color { get; set; }
    public StatusCategoryViewModel StatusCategory { get; set; }
  }
  public class StatusCategoryViewModel
  {
    public StatusCategoryViewModel(StatusCategory statusCategory)
    {
      Id = statusCategory.Id;
      Code = statusCategory.Code;
      Name = statusCategory.Name;
      Description = statusCategory.Description;
    }

    public Guid Id { get; set; }
    public string Code { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
  }
}
