using Microsoft.AspNetCore.Mvc;
using StockMarketTracker.Business.Contracts;
using StockMarketTracker.Model;

namespace StockMarketTracker.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StockController : ControllerBase
    {
        private readonly IStockManager _stockManager;

        public StockController(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        [HttpGet("all")]
        public IEnumerable<StockTO> GetAllStocks()
        {
            return _stockManager.GetAllStocks();
        }

        [HttpGet]
        public IEnumerable<StockTO> GetStocks([FromQuery]StockSearchFilter filters)
        {
            return _stockManager.GetStocksWithFilter(filters);
        }

        [HttpGet("priceHistory")]
        public IEnumerable<StockPrice> GetStockPrices(Guid stockId, int numDays)
        {
            return _stockManager.GetRecentStockPriceHistory(stockId, numDays);
        }
    }
}
