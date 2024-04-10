namespace AgilleApi.Domain.ViewModel
{
    public class Metadata: MetadataParams
    {
        public int DataSize { get; set; }
    }

    public class MetadataParams
    {
        public string QuickSearch { get; set; }
        public string SortColumn { get; set; } = "";
        public string SortDirection { get; set; } = "desc";
        public int Offset { get; set; } = 0;
        public int Limit { get; set; } = 0;

        public Metadata ViewModelFromEntity()
        {
            return new Metadata
            {
                SortColumn = SortColumn,
                SortDirection = SortDirection,
                Offset = Offset,
                Limit = Limit
            };
        }
    }
}
