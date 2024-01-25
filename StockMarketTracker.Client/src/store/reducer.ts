import { Stock } from "../types/Stock";
import { action, globalState } from "../types/store";

const reducer = (state: globalState, action: action): globalState => {
	switch (action.type) {
		case "SET_STATE":
			return {
				...(action.payload as globalState),
			};

		case "SET_STOCKS":
			return {
				...state,
				stocks: action.payload as Stock[],
			};

		case "SET_SELECTED_STOCK":
			return {
				...state,
				selectedStock: action.payload as Stock | null,
			};

		case "SET_STOCK_FILTER":
			return {
				...state,
				stockFilter: {
					name: action.payload as string,
				},
			};

		default:
			return state;
	}
};

export default reducer;
