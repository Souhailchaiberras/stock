namespace API2.Helpers
{
    public class QueryObject
    {
        public String? Symbole { get; set; } = null;
        public String? CompanyName { get; set; } = null;
        public String? SortBy { get; set; } = null;
        public bool IsDesceding { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 20;
    }
}
