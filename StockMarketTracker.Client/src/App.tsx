import Stocks from "./components/Stocks";

function App() {
	//const { store, dispatch } = useContext(Context);
	return (
		<>
			<div>
				<h1 className="text-3xl w-screen text-center mt-5">
					Stock Market Tracker
				</h1>
				<Stocks />
			</div>
		</>
	);
}

export default App;
