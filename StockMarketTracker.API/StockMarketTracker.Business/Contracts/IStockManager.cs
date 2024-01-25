

using StockMarketTracker.Model;

namespace StockMarketTracker.Business.Contracts
{
    public interface IStockManager
    {
        IEnumerable<StockTO> GetAllStocks();
        IEnumerable<StockTO> GetStocksWithFilter(StockSearchFilter filter);
        IEnumerable<StockPrice> GetRecentStockPriceHistory(Guid stockId, int numDays);
    }
}
