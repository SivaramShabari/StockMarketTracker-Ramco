using StockMarketTracker.Model;

namespace StockMarketTracker.Repository.Contracts
{
    public interface IStockRepository
    {
        IEnumerable<Stock> GetAllStocks();
        IEnumerable<Stock> GetStocksWithFilter(StockSearchFilter filter);
        IEnumerable<StockPrice> GetRecentStockPriceHistory(Guid stockId, int numDays);
    }
}