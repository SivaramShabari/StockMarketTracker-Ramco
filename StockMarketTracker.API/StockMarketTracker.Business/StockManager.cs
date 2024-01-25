using AutoMapper;
using StockMarketTracker.Business.Contracts;
using StockMarketTracker.Model;
using StockMarketTracker.Repository.Contracts;

namespace StockMarketTracker.Business
{
    public class StockManager : IStockManager
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMapper _mapper;

        public StockManager(IStockRepository stockRepository, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _mapper = mapper;
        }

        public IEnumerable<StockTO> GetAllStocks()
        {
            return _mapper.Map<IEnumerable<StockTO>>(_stockRepository.GetAllStocks());
        }

        public IEnumerable<StockTO> GetStocksWithFilter(StockSearchFilter stockSearchFilter)
        {
            var stocks = _mapper.Map<IEnumerable<StockTO>>(_stockRepository.GetStocksWithFilter(stockSearchFilter));
            foreach(var stock in stocks)
            {
                stock.PrevDay = _stockRepository.GetRecentStockPriceHistory(stock.Id, 1).First();
            }
            return stocks;
        }

        public IEnumerable<StockPrice> GetRecentStockPriceHistory(Guid stockId, int numDays)
        {
            return _stockRepository.GetRecentStockPriceHistory(stockId, numDays);
        }
    }
}
