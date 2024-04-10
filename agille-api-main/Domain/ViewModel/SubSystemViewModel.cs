using AgilleApi.Domain.Services.Specialize;
using System;

namespace AgilleApi.Domain.ViewModel
{
    public class SubSystemListViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string NameWithoutAccent { get => TextFilter.RemoveAccents(Name); set => TextFilter.RemoveAccents(Name); }
        public string Description { get; set; }
        public string DescriptionWithoutAccent { get => TextFilter.RemoveAccents(Description); set => TextFilter.RemoveAccents(Description); }
    }
    public class SubSystemInsertViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public bool FilledFields()
        {
            return (Name == null || Description == null);
        }
    }
    public class SubSystemUpdateViewModel
    {
        public Nullable<Guid> Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public bool FilledFields()
        {
            return ((Id == null || Id == Guid.Empty) || Name == null || Description == null);
        }
    }
}
