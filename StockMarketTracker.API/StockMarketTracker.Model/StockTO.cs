
namespace StockMarketTracker.Model
{
    public class StockTO
    {
        public StockTO() { }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Symbol { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public StockPrice PrevDay {  get; set; }
    }
}
