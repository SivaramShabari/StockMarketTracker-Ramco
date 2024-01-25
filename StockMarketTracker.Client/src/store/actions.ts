import { Stock } from "../types/Stock";
import { action, globalState } from "../types/store";

export const setStocks = (stocks: Stock[]): action => {
	return {
		type: "SET_STOCKS",
		payload: stocks,
	};
};

export const setSelectedStock = (stock: Stock): action => {
	return {
		type: "SET_SELECTED_STOCK",
		payload: stock,
	};
};

export const setStockFilyer = (name: string): action => {
	return {
		type: "SET_STOCK_FILTER",
		payload: name,
	};
};

export const setState = (state: globalState): action => {
	return {
		type: "SET_SELECTED_STOCK",
		payload: state,
	};
};
