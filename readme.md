This repository has 3 different projects

## StockMarketTracker.API

C# .NET Restful API to manage stock data and other business logic

It has 3 end points to

    - get all stocks,
    - get stocks by filter and
    - get historical stock data

It has a 3 layer architecture:

    - The controller to handle http requests
    - The business layer to handle application logic
    - The repository layer to interact with databases and other data sources

The code adheres as much to clean code principles and SOLID patterns. Automapper is used to convert Data domain models to data transfer objects.

The API is designed with scalability and flexibility in mind to add and change required features. Ad it sticks to standard .NET core features, the code is configurable to external dependencies like database connection.

SQL server database is used to store Stock and historical price data and Dapper as an ORM in the repository layer.

#### Unit Testing

Test project setup with MSTest for unit tests and Moq for mocking interfaces. Only one test case added due to time constraint.

#### Logging

Configured default logger to log in console. External loggers can be easiliy configured in program.cs startup code as logging extensions as per requirements.

---

## StockMarketTracker.Client

React JS Client with a single page to track stock data

Search bar to search stocks by name

Stocks have live price updates from mock price stream server usign web socket connection

Only searched stocks get subscribed to server for real time price

Redux pattern (with custom hooks) to handle state to enhance scalability

React Query library (SWR - stale while revalidate) through custom hooks to handle api data to handle multiple scenarios

Typescript for type safety to minimize run time errors.

Tailwind css + daisy ui for a good looking UI with theming system.

Recharts for data visualization.

_Todo: Unit tests and logging_

---

## StockMarketTracker.PriceStreaming

A node js server with websockets for mocking realtime stock price stream

This code represents a mock server for generating simulated stock market data. It uses WebSocket to communicate with clients and sends mock stock prices based on the received input.

### Setup

1. **Dependencies:**

   - Ensure that you have Node.js installed.

2. **Installation:**

   - No additional dependencies need to be installed.

3. **Run the Server:**
   - Execute the script to run the WebSocket server on port 4321.
     ```bash
     node your-script.js
     ```
   - The WebSocket server will be running on `ws://localhost:4321`.

### WebSocket Server

The server listens for incoming WebSocket connections on port 4321.

- **Connection Event:**

  - When a client connects, it logs the event.
  - When a client disconnects, it logs the event.

- **Message Event:**
  - Upon receiving a message from the client (expected as a JSON array), it generates mock stock data and sends it back to the client.

### Mock Data Generation

The `getJsonData` function generates mock stock data based on the input array received from the client.

- **Output Format:**

  - The output is a JSON string containing a timestamp and an array of stock prices.

- **Stock Price Generation:**
  - The `generateDayStockPrice` function is used to generate a new stock price based on the last day's price and a specified volatility percentage.

#### Example Usage

1. Connect to the WebSocket server using a WebSocket client or library.
2. Send a JSON array of stock data to the server.
3. Receive simulated stock data in response.
