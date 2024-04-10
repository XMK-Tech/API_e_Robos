using System;
using System.Collections.Generic;

namespace AgilleApi.Domain.ViewModel
{
  public class FieldViewModelResult
  {
    public FieldViewModelResult(string displayTable, List<Fields> fields)
    {
      DisplayTable = displayTable;
      Fields = fields;
    }

    public string DisplayTable { get; set; }
    public List<Fields> Fields { get; set; } = new List<Fields>();
  }
  public class Fields
  {
    public Fields(Guid id,
        string code,
        string displayTable,
        string displayColumn,
        string table,
        string column,
        string schema, 
        string columnKey)
    {
      Id = id;
      Code = code;
      DisplayTable = displayTable;
      DisplayColumn = displayColumn;
      Table = table;
      Column = column;
      Schema = schema;
      ColumnKey = columnKey;
    }

    public Guid Id { get; set; }
    public string Code { get; set; }
    public string DisplayTable { get; set; }
    public string DisplayColumn { get; set; }
    public string Schema { get; set; }
    public string Table { get; set; }
    public string Column { get; set; }
    public string ColumnKey { get; set; }
  }

}
