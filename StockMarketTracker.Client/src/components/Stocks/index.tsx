/* eslint-disable @typescript-eslint/no-explicit-any */
import { useContext, useEffect, useState } from "react";
import { Context } from "../../store";
import StockCard from "./StockCard";
import SearchBar from "./SearchBar";
import { useGetStocks } from "../../api/stockApi";
import { w3cwebsocket } from "websocket";
import config from "../../config";
import { Stock } from "../../types/Stock";

function Stocks() {
	const { store } = useContext(Context);
	const stockQuery = useGetStocks(store.stockFilter.name);

	const [receivedData, setReceivedData] = useState<any>(null);
	const [wsConnection, setWsConnection] = useState<w3cwebsocket>();

	useEffect(() => {
		const newSocket = new w3cwebsocket(config.stockPriceWebSocketUrl);
		newSocket.onopen = () => {
			setWsConnection(newSocket);
		};

		newSocket.onmessage = (message) => {
			const jsonData = JSON.parse(message.data as string);
			setReceivedData(jsonData);
		};

		newSocket.onclose = () => {
			console.log("WebSocket connection closed");
		};

		return () => {
			newSocket.close();
		};
	}, []);

	useEffect(() => {
		if (wsConnection?.readyState === WebSocket.OPEN && stockQuery.data) {
			const data = stockQuery?.data?.map((s: Stock) => ({
				id: s.id,
				price: s.prevDay.close,
			}));
			const interval = setInterval(
				() => wsConnection.send(JSON.stringify(data)),
				1000
			);
			return () => clearInterval(interval);
		}
	}, [stockQuery.data, wsConnection]);

	useEffect(() => {
		if (stockQuery.isError) {
			alert("Something went wrong while connecting to the server");
		}
	}, [stockQuery.isError, stockQuery.error]);

	return (
		<>
			<div>
				<div className="w-screen flex justify-center">
					<SearchBar />
				</div>
				<div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
					{stockQuery?.data?.map((stock, idx) => (
						<StockCard
							key={idx}
							stock={stock}
							price={
								receivedData?.stockPriceList?.find((d) => d.id === stock.id)
									?.price
							}
						/>
					))}
				</div>
			</div>
		</>
	);
}

export default Stocks;
