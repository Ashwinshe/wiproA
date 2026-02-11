import React from "react";
import { Line } from "react-chartjs-2";

import {
  Chart as ChartJS,
  LineElement,
  CategoryScale,
  LinearScale,
  PointElement
} from "chart.js";

ChartJS.register(LineElement, CategoryScale, LinearScale, PointElement);

export default function StockChart({ prices }) {
  const data = {
    labels: prices.map((_, i) => `T${i + 1}`),
    datasets: [
      {
        label: "Stock Price",
        data: prices,
        borderColor: "blue",
        backgroundColor: "lightblue"
      }
    ]
  };

  return (
    <div style={{ height: "300px" }}>
      <Line data={data} />
    </div>
  );
}
