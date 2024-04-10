using AgilleApi.Domain.Entities;
using AgilleApi.Domain.Interfaces.Repository;
using AgilleApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgilleApi.Domain.Services.Commom
{
  public class DynamicFieldsServices : Notifications
  {
    private readonly IDynamicFieldsRepository _repository;
    public DynamicFieldsServices(IDynamicFieldsRepository repository)
    {
      _repository = repository;
    }

    public List<FieldViewModelResult> List()
    {
      try
      {
        List<DynamicFieldOptions> fields = _repository.Query().OrderBy(e => e.Table).ToList();
        if (fields.Count == 0)
        {
          ValidationMessages.Add("None fiels was found");
          StatusCode = 200;
          return null;
        }

        return ConvertToListViewModel(fields);

      }
      catch (Exception ex)
      {
        StatusCode = 500;
        ValidationMessages.Add(ex.Message);
        if (ex.InnerException != null)
          ValidationMessages.Add(ex.InnerException.Message);
        return null;
      }
    }

    private List<FieldViewModelResult> ConvertToListViewModel(List<DynamicFieldOptions> fields)
    {
      List<FieldViewModelResult> result = new List<FieldViewModelResult>();

      foreach (var item in fields.GroupBy(x => x.DisplayTable).Select(x => x.Key).ToList())
      {
        result.Add(new FieldViewModelResult(item, fields.Where(e => e.DisplayTable.Equals(item)).Select(e => new Fields(e.Id,
                                                                                                                        e.Code,
                                                                                                                        e.DisplayTable,
                                                                                                                        e.DisplayColumn,
                                                                                                                        e.Table,
                                                                                                                        e.Column,
                                                                                                                        e.Schema,
                                                                                                                        e.ColumnKey)).ToList()));
      }
      return result;
    }
  }
}
