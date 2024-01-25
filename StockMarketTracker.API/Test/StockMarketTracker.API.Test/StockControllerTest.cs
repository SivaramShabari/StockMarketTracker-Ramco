using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StockMarketTracker.API.Controllers;
using StockMarketTracker.Business.Contracts;
using StockMarketTracker.Model;

namespace StockMarketTracker.API.Test
{
    [TestClass]
    public class StockControllerTest
    {
        private readonly Mock<IStockManager> _mockStockManager;
        private readonly StockController _controller;
        private readonly Mock<ILogger<StockController>> _mockLogger;

        public StockControllerTest()
        {
            _mockStockManager = new Mock<IStockManager>();
            _mockLogger = new Mock<ILogger<StockController>>();
            _controller = new StockController(_mockStockManager.Object, _mockLogger.Object);
        }

        [TestMethod]
        [DataRow(true, "Error message")]
        [DataRow(false, null)]
        public void GetAllStocks_HandlesSuccessAndErrorScenarios(bool isError, string expectedErrorMessage)
        {
            // Arrange
            var expectedStocks = new List<StockTO> { };
            if (isError)
            {
                _mockStockManager.Setup(m => m.GetAllStocks()).Throws(new Exception(expectedErrorMessage));
            }
            else
            {
                _mockStockManager.Setup(m => m.GetAllStocks()).Returns(expectedStocks);
            }

            // Act
            var result = _controller.GetAllStocks();

            // Assert
            if (isError)
            {
                Assert.IsInstanceOfType(result, typeof(StatusCodeResult));
                Assert.AreEqual(500, ((StatusCodeResult)result).StatusCode);
                Assert.AreEqual("Internal Server Error. " + expectedErrorMessage, ((StatusCodeResult)result).Value);
                _mockLogger.Verify(l => l.LogError(It.IsAny<string>(), It.IsAny<Exception>()));
            }
            else
            {
                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
                Assert.AreEqual(expectedStocks, ((OkObjectResult)result).Value);
            }
        }
    }
}