export type Stock = {
	id: string;
	name: string;
	symbol: string;
	exchange: string;
	prevDay: StockPrice;
	priceHistory: StockPrice[];
};

export type StockPrice = {
	low: number;
	open: number;
	date: string;
	high: number;
	close: number;
	volume: number;
};
