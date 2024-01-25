using Dapper;
using Microsoft.Data.SqlClient;
using StockMarketTracker.Model;
using System.Data;
using Microsoft.Extensions.Configuration;
using StockMarketTracker.Repository.Contracts;

namespace StockMarketTracker.Repository
{
    public class StockRepository : IStockRepository
    {
        private readonly IDbConnection connection;
        public StockRepository(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("StockMarketDB");
            connection = new SqlConnection(connectionString);
        }

        public IEnumerable<Stock> GetAllStocks()
        {
            const string sql = "SELECT * FROM Stocks";
            return connection.Query<Stock>(sql);
        }

        public IEnumerable<Stock> GetStocksWithFilter(StockSearchFilter filter)
        {
            const string sql = @"SELECT * FROM Stocks WHERE Name LIKE '%' + @name + '%'";

            var parameters = new DynamicParameters();
            parameters.Add("@name", filter.Name?.Trim() ?? "", DbType.String);
            //parameters.Add("@offset", (filter.Page - 1) * filter.PageSize, DbType.Int32);
            //parameters.Add("@sortColumn", GetSortColumn(filter.SortDirection), DbType.String);
            //parameters.Add("@pageSize", filter.PageSize, DbType.Int32);

            var res = connection.Query<Stock>(sql, parameters);
            return res;
        }

        public IEnumerable<StockPrice> GetRecentStockPriceHistory(Guid stockId, int numDays)
        {
            const string sql = @"SELECT TOP (@numDays) * FROM StockPriceHistory
                        WHERE StockId = @stockId
                        ORDER BY Date DESC";
            return connection.Query<StockPrice>(sql, new { stockId, numDays });
        }

        private string GetSortColumn(SortDirection direction)
        {
            switch (direction)
            {
                case SortDirection.Ascending:
                    return "Name";
                case SortDirection.Descending:
                    return "Name DESC";
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction));
            }
        }
    }
}
