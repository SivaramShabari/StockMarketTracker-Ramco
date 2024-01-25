import { useContext, useState } from "react";
import SearchIcon from "../common/SearchIcon";
import { Context } from "../../store";

function SearchBar() {
	const { dispatch } = useContext(Context);
	const [filterName, setfilterName] = useState("");
	return (
		<div className="m-5">
			<label className="flex flex-row form-control w-full">
				<div>
					<div className="ml-4 mt-4 absolute w-4 h-4">
						<SearchIcon />
					</div>
					<input
						type="text"
						placeholder="Search stocks"
						className="pl-12 input input-bordered w-full"
						value={filterName}
						onChange={(e) => setfilterName(e.target.value || "")}
					/>
				</div>

				<button
					className="ml-2 btn btn-primary btn-round "
					onClick={() =>
						dispatch({
							type: "SET_STOCK_FILTER",
							payload: filterName,
						})
					}
				>
					<span className="px-4">Search</span>
				</button>
			</label>
		</div>
	);
}

export default SearchBar;
