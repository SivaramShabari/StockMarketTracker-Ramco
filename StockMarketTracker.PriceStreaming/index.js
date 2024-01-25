const WebSocket = require("ws");

const server = new WebSocket.Server({ port: 4321 });

server.on("connection", (socket) => {
	console.log("Client connected");

	socket.on("message", (message) => {
		const inputArray = JSON.parse(message);
		console.log("Size: ", inputArray?.length);
		const jsonData = getJsonData(inputArray);
		socket.send(jsonData);
	});

	socket.on("close", () => {
		console.log("Client disconnected");
	});
});

function getJsonData(inputArray) {
	const data = {
		timestamp: new Date().toISOString(),
		stockPriceList: inputArray.map((stock) => ({
			...stock,
			price: generateDayStockPrice(stock.price, 5),
		})),
	};
	return JSON.stringify(data);
}

function generateDayStockPrice(lastDayPrice, volatilityPercentage) {
	const randomPercentage = (Math.random() - 0.5) * 2 * volatilityPercentage;
	const newPrice = lastDayPrice * (1 + randomPercentage / 100);
	const roundedPrice = Math.round(newPrice * 100) / 100;
	return roundedPrice;
}
console.log("WebSocket server is running on port 4321");
