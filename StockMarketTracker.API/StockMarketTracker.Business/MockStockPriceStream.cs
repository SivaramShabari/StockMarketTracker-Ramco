
namespace StockMarketTracker.Business
{
    public class MockStockPriceStream
    {
        private readonly Random _random = new Random();

        public async Task GenerateAsync(Guid stockId, double initialPrice, double volatility, int delay)
        {
            while (true)
            {
                double priceChange = _random.NextDouble() * volatility * 2 - volatility;
                double newPrice = initialPrice + priceChange;
                await Task.Delay(delay);
            }
        }
    }
}