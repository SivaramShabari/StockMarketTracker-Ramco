namespace StockMarketTracker.Model
{
    public class Stock
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public IEnumerable<StockPrice> PriceHistory {  get; set; } = Enumerable.Empty<StockPrice>();
    }
}
