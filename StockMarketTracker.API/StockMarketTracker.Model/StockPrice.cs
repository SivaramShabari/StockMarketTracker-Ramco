namespace StockMarketTracker.Model
{
    public class StockPrice
    {
        public DateTime Date {  get; set; } = DateTime.UtcNow;
        public double Open {  get; set; }
        public double Close {  get; set; }
        public double High {  get; set; }
        public double Low {  get; set; }
        public int Volume {  get; set; }
    }
}
