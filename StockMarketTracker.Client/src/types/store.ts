import { Stock } from "./Stock";

export type action = {
	type: string;
	payload: unknown;
	description?: string;
};

export type globalState = {
	stockFilter: {
		name: string;
	};
	stocks: Stock[];
	selectedStock: Stock | null;
};
