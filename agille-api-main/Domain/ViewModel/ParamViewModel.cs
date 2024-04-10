using System;

namespace AgilleApi.Domain.ViewModel
{
  public class ParamViewModel
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
    public class ParamInsertViewModel
    {
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
