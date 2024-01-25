import { useState } from "react";
import { Stock } from "../../types/Stock";
import ModalBasic from "../common/Modal";
import StockChart from "./StockPriceChart";
import { useGetStockPriceHistory } from "../../api/stockApi";

function StockCard({ stock, price }: { stock: Stock; price: number }) {
	const [modalOpen, setmodalOpen] = useState(false);
	const getPriceQuery = useGetStockPriceHistory(stock.id, 150);
	const data = getPriceQuery.data;
	return (
		<>
			<div className="m-3 card bg-base-200 shadow-xl">
				<div className="card-body">
					<h2 className="card-title">
						{stock.name} - {stock.symbol}
					</h2>
					<h2 className="card-title">${price}</h2>
					<div>
						<p>Low {stock.prevDay.low}</p>
						<p>High {stock.prevDay.high}</p>
						<p>Close {stock.prevDay.close}</p>
						<p>Volume {stock.prevDay.volume}</p>
					</div>
					<div className="card-actions justify-end">
						<button
							onClick={(e) => {
								e.stopPropagation();
								setmodalOpen((open) => !open);
							}}
							className="btn btn-primary"
						>
							Historical Price
						</button>
					</div>
				</div>
			</div>
			<ModalBasic
				id={1}
				modalOpen={modalOpen}
				setModalOpen={setmodalOpen}
				title={`Stock Price History:  ${stock.name} - ${stock.symbol}`}
			>
				<StockChart stock={stock} stockData={data} />
			</ModalBasic>
		</>
	);
}

export default StockCard;
