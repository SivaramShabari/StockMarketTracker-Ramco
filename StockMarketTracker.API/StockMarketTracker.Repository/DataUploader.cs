using Abp;
using Dapper;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using StockMarketTracker.Model;
using System.Globalization;

namespace StockMarketTracker.Repository
{
    public static class DataUploader
    {

        public static void UploadData(string connectionString)
        {
            string formattedString = string.Format(CultureInfo.InvariantCulture, connectionString);

            using (var connection = new SqlConnection(formattedString))
            {
                const string jsonFilePath = "C:\\Users\\sshabaria\\source\\repos\\personal\\StockMarketTracker.API\\StockMarketTracker.Repository\\MockData.json";
                string jsonData = File.ReadAllText(jsonFilePath);

                List<Stock> stocks = JsonConvert.DeserializeObject<List<Stock>>(jsonData);

                connection.Open();

                // Insert each stock with its price history
                foreach (var stock in stocks)
                {
                    // Insert Stock record
                    string insertStockSql = "INSERT INTO Stocks (Id, Symbol, Name, Exchange) VALUES (@Id, @Symbol, @Name, 'National Stock Exchange')";
                    connection.Execute(insertStockSql, new { stock.Id, stock.Symbol, stock.Name });

                    // Get last inserted StockId

                    // Insert PriceHistory records for the stock
                    foreach (var priceHistory in stock.PriceHistory)
                    {
                        string insertPriceHistorySql = "INSERT INTO StockPriceHistory (StockId, Date, [Open], High, Low, [Close], Volume) VALUES (@StockId, @Date, @Open, @High, @Low, @Close, @Volume)";
                        connection.Execute(insertPriceHistorySql, new
                        {
                            StockId = stock.Id,
                            priceHistory.Date,
                            priceHistory.Open,
                            priceHistory.High,
                            priceHistory.Low,
                            priceHistory.Close,
                            priceHistory.Volume
                        });
                    }
                }

                connection.Close();
            }
        }
    }
}
