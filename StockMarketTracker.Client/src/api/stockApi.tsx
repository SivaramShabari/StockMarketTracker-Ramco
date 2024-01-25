import { useQuery } from "@tanstack/react-query";
import config from "../config";
import axios from "axios";

export const useGetStocks = (name: string) => {
	return useQuery({
		queryKey: ["stocks", name],
		queryFn: async () => {
			const { data } = await axios.get(config.apiUrl + "/Stock", {
				params: {
					name,
				},
			});
			return data;
		},
	});
};

export const useGetStockPriceHistory = (stockId: string, numDays: number) => {
	return useQuery({
		queryKey: ["stockPriceHistory", stockId, numDays],
		queryFn: async () => {
			const { data } = await axios.get(config.apiUrl + "/Stock/priceHistory", {
				params: {
					stockId,
					numDays,
				},
			});
			return data;
		},
	});
};
