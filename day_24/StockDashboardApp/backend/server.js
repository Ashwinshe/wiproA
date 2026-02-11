const express = require("express");
const cors = require("cors");
const http = require("http");
const { Server } = require("socket.io");

const app = express();
app.use(cors());

const server = http.createServer(app);

const io = new Server(server, {
  cors: {
    origin: "*",
    methods: ["GET", "POST"]
  }
});

// Fake Stock Data Generator
let stocks = {
  AAPL: 180,
  TSLA: 220,
  MSFT: 330,
  AMZN: 140,
  GOOGL: 125
};

// API to fetch stock data
app.get("/stock/:symbol", (req, res) => {
  const symbol = req.params.symbol.toUpperCase();

  if (!stocks[symbol]) {
    stocks[symbol] = Math.floor(Math.random() * 500) + 50;
  }

  res.json({
    symbol,
    price: stocks[symbol],
    time: new Date().toLocaleTimeString()
  });
});

// Socket.io Connection
io.on("connection", (socket) => {
  console.log("Client Connected:", socket.id);

  socket.on("trackStock", (symbol) => {
    symbol = symbol.toUpperCase();
    console.log("Tracking stock:", symbol);

    const interval = setInterval(() => {
      if (!stocks[symbol]) stocks[symbol] = 100;

      // Random Price Change
      const change = (Math.random() * 10 - 5).toFixed(2);
      stocks[symbol] = parseFloat((stocks[symbol] + parseFloat(change)).toFixed(2));

      socket.emit("stockUpdate", {
        symbol,
        price: stocks[symbol],
        change,
        time: new Date().toLocaleTimeString()
      });
    }, 2000);

    socket.on("disconnect", () => {
      clearInterval(interval);
      console.log("Client Disconnected:", socket.id);
    });
  });
});

server.listen(5000, () => {
  console.log("Server running on http://localhost:5000");
});
