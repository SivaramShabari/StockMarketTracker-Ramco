namespace StockMarketTracker.Model
{
    public class StockSearchFilter
    {
        public string? Name { get; set; } = null;
        public int? Page { get; set; } = 1;
        public int? PageSize { get; set; } = 25;
        public SortDirection SortDirection { get; set; } = SortDirection.Ascending;
    }
    public enum SortDirection
    {
        Ascending,
        Descending,
    }
}
