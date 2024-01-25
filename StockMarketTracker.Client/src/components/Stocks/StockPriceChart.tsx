import React from "react";
import {
	LineChart,
	Line,
	XAxis,
	YAxis,
	CartesianGrid,
	Tooltip,
	Legend,
} from "recharts";
import { Stock, StockPrice } from "../../types/Stock";

interface StockChartProps {
	stock: Stock | null;
	stockData: StockPrice[];
}

const StockChart: React.FC<StockChartProps> = ({ stockData }) => {
	return (
		<LineChart
			width={window.innerWidth * 0.9}
			height={window.innerHeight * 0.9}
			data={stockData}
			margin={{ top: 20, right: 30, left: 20, bottom: 10 }}
		>
			<CartesianGrid strokeDasharray="3 3" />
			<XAxis dataKey="date" />
			<YAxis />
			<Tooltip />
			<Legend />
			<Line type="monotone" dataKey="low" stroke="#8884d8" name="Low" />
			<Line type="monotone" dataKey="high" stroke="#82ca9d" name="High" />
			<Line type="monotone" dataKey="open" stroke="#ffc658" name="Open" />
			<Line type="monotone" dataKey="close" stroke="#ff7300" name="Close" />
			{/* You can add more lines for other properties like volume, price, etc. */}
		</LineChart>
	);
};

export default StockChart;
