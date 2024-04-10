using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using Domain.Services.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace AgilleApi.Domain.Services.Commom
{
  public class StatusServices : Notifications
  {
    private readonly IStatusRepository _repository;

    public StatusServices(IStatusRepository repository)
    {
      _repository = repository;
    }
    public List<StatusViewModel> List(StatusParams model, Metadata metadata)
    {
      try
      {
        var query = _repository.Query().Include(x => x.StatusCategory).AsQueryable();
        Expression<Func<Status, Object>> sort = x => x.Name;

        if (metadata.SortColumn != null)
          if (metadata.SortColumn.ToLower() == "code")
            sort = x => x.Code;
          else if (metadata.SortColumn.ToLower() == "color")
            sort = x => x.Color;
          else if (metadata.SortColumn.ToLower() == "description")
            sort = x => x.Description;

        if (metadata.SortDirection.ToLower() == "asc")
          query = query.OrderBy(sort);
        if (metadata.SortDirection.ToLower() == "desc")
          query = query.OrderByDescending(sort);

        if (model.Id != Guid.Empty)
          query = query.Where(x => x.Id == model.Id);
        if (!String.IsNullOrEmpty(model.Code))
          query = query.Where(x => x.Code == model.Code);

        if (model.StatusCategoryId != Guid.Empty)
          query = query.Where(x => x.StatusCategory.Id == model.StatusCategoryId);
        if (!String.IsNullOrEmpty(model.StatusCategoryCode))
          query = query.Where(x => x.StatusCategory.Code == model.StatusCategoryCode);

        var result = ConvertToViewModel(_repository.ExecuteQuery(query, metadata));

        if (result == null)
        {
          StatusCode = 500;
          return null;
        }

        if (result.Count == 0)
        {
          ValidationMessages.Add("None Status was found.");
          StatusCode = 404;
          return null;
        }

        return result;
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }

    public Guid? GetByCode(string code)
    {
      try
      {
        var result = _repository.Get(x => x.Code == code)?.FirstOrDefault();

        if (result == null)
        {
          ValidationMessages.Add("None Status was found.");
          StatusCode = 500;
          return null;
        }

        return result.Id;
      }
      catch (Exception ex)
      {
        return ServiceErrorHandle.ExceptionThreatment(ValidationMessages, StatusCode, ex);
      }
    }

    private List<StatusViewModel> ConvertToViewModel(List<Status> list)
    {
      List<StatusViewModel> result = new List<StatusViewModel>();
      foreach (Status item in list)
      {
        result.Add(new StatusViewModel(item));
      }
      return result;
    }
  }
}
