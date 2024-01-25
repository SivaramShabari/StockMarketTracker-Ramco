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
        private readonly ILogger<StockController> _logger;

        public StockController(IStockManager stockManager, ILogger<StockController> logger)
        {
            _stockManager = stockManager;
            _logger = logger;
        }

        [HttpGet("all")]
        public IActionResult GetAllStocks()
        {
            try
            {
                IEnumerable<StockTO> stocks = _stockManager.GetAllStocks();
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while fetching all stocks. " +  ex.Message);
                return StatusCode(500, "Internal Server Error. " +ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetStocks([FromQuery]StockSearchFilter filters)
        {
            try
            {
                IEnumerable<StockTO> stocks = _stockManager.GetStocksWithFilter(filters);
                return Ok(stocks);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while fetching stocks. " + ex.Message);
                return StatusCode(500, "Internal Server Error. " + ex.Message);
            }
        }

        [HttpGet("priceHistory")]
        public IActionResult GetStockPrices(Guid stockId, int numDays)
        {
            try
            {
                IEnumerable<StockPrice> stockPriceHistory = _stockManager.GetRecentStockPriceHistory(stockId, numDays);
                return Ok(stockPriceHistory);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error while fetching stocks. " + ex.Message);
                return StatusCode(500, "Internal Server Error. " + ex.Message);
            }
        }
    }
}
