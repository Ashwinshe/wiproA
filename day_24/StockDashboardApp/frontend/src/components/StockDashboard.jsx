import React, { Component } from "react";
import io from "socket.io-client";
import StockChart from "./StockChart";

const socket = io("http://localhost:5000");

export default class StockDashboard extends Component {
  constructor(props) {
    super(props);

    this.state = {
      symbol: "AAPL",
      stockData: null,
      previousSearches: [],
      theme: "light",
      chartPrices: []
    };

    this.uncontrolledRef = React.createRef();
  }

  // Lifecycle Method 1
  componentDidMount() {
    this.fetchStock(this.state.symbol);

    socket.on("stockUpdate", (data) => {
      this.setState((prevState) => ({
        stockData: data,
        chartPrices: [...prevState.chartPrices.slice(-9), data.price]
      }));
    });

    socket.emit("trackStock", this.state.symbol);
  }

  // Lifecycle Method 2
  componentDidUpdate(prevProps, prevState) {
    if (prevState.symbol !== this.state.symbol) {
      this.fetchStock(this.state.symbol);
      socket.emit("trackStock", this.state.symbol);
    }
  }

  fetchStock = async (symbol) => {
    try {
      const res = await fetch(`http://localhost:5000/stock/${symbol}`);
      const data = await res.json();

      this.setState({
        stockData: data,
        chartPrices: [data.price]
      });
    } catch (error) {
      console.log("Error fetching stock:", error);
    }
  };

  // Controlled Input
  handleChange = (e) => {
    this.setState({ symbol: e.target.value.toUpperCase() });
  };

  // Add to uncontrolled previous searches
  handleSearch = () => {
    const value = this.uncontrolledRef.current.value;

    if (value && !this.state.previousSearches.includes(value)) {
      this.setState((prev) => ({
        previousSearches: [...prev.previousSearches, value]
      }));
    }

    this.uncontrolledRef.current.value = "";
  };

  // Theme Toggle (Bonus)
  toggleTheme = () => {
    this.setState((prev) => ({
      theme: prev.theme === "light" ? "dark" : "light"
    }));
  };

  render() {
    const { stockData, previousSearches, theme, chartPrices } = this.state;

    return (
      <div className={`dashboard-container ${theme}`}>
        <div className="container py-4">
          <div className="d-flex justify-content-between align-items-center mb-4">
            <h2 className="fw-bold text-primary"> Stock Market Dashboard</h2>
            <button className="btn btn-warning" onClick={this.toggleTheme}>
              Toggle Theme 
            </button>
          </div>

          {/* Controlled Input */}
          <div className="card shadow-lg p-4 mb-4">
            <h5 className="fw-bold">Search Stock Symbol</h5>
            <div className="row mt-3">
              <div className="col-md-6">
                <input
                  type="text"
                  value={this.state.symbol}
                  onChange={this.handleChange}
                  className="form-control"
                  placeholder="Enter stock symbol (Ex: TSLA)"
                />
              </div>

              <div className="col-md-6 d-flex gap-2">
                <input
                  type="text"
                  ref={this.uncontrolledRef}
                  className="form-control"
                  placeholder="Save symbol in history"
                />

                <button className="btn btn-success" onClick={this.handleSearch}>
                  Save
                </button>
              </div>
            </div>
          </div>

          {/* Stock Display */}
          <div className="row">
            <div className="col-md-6">
              <div className="card shadow stock-card p-4">
                <h4 className="fw-bold text-center">Live Stock Price</h4>

                {stockData ? (
                  <div className="text-center mt-4">
                    <h2 className="text-success">{stockData.symbol}</h2>
                    <h1 className="fw-bold">₹ {stockData.price}</h1>
                    <p className="text-muted">Last Updated: {stockData.time}</p>

                    {stockData.change && (
                      <p
                        className={
                          stockData.change > 0
                            ? "text-success fw-bold"
                            : "text-danger fw-bold"
                        }
                      >
                        Change: {stockData.change}
                      </p>
                    )}
                  </div>
                ) : (
                  <p className="text-center text-danger">
                    Loading stock data...
                  </p>
                )}
              </div>
            </div>

            {/* Previous Searches */}
            <div className="col-md-6">
              <div className="card shadow p-4">
                <h4 className="fw-bold text-center"> Previous Searches</h4>
                <ul className="list-group mt-3">
                  {previousSearches.length > 0 ? (
                    previousSearches.map((s, index) => (
                      <li
                        key={index}
                        className="list-group-item d-flex justify-content-between"
                      >
                        {s}
                        <span className="badge bg-primary">Saved</span>
                      </li>
                    ))
                  ) : (
                    <p className="text-center text-muted mt-3">
                      No searches saved yet
                    </p>
                  )}
                </ul>
              </div>
            </div>
          </div>

          {/* Chart Section */}
          <div className="card shadow-lg p-4 mt-4">
            <h4 className="fw-bold text-center">Stock Trend Chart</h4>
            <StockChart prices={chartPrices} />
          </div>
        </div>
      </div>
    );
  }
}
