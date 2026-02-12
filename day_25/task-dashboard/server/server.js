const express = require("express");
const http = require("http");
const { Server } = require("socket.io");
const cors = require("cors");

const app = express();
const server = http.createServer(app);

const io = new Server(server, {
  cors: { origin: "*" },
});

app.use(cors());
app.use(express.json());

let tasks = [];
let users = [];

io.on("connection", (socket) => {
  console.log("User connected:", socket.id);

  // Register User
  socket.on("registerUser", (user) => {
    users.push({ ...user, socketId: socket.id });
  });

  // Send initial tasks
  socket.emit("loadTasks", tasks);

  // Add Task
  socket.on("addTask", (task) => {
    tasks.push(task);
    io.emit("taskUpdated", tasks);

    // Notify assigned user
    const assignedUser = users.find(
      (u) => u.name === task.assignee
    );

    if (assignedUser) {
      io.to(assignedUser.socketId).emit("notification", {
        message: `New Task Assigned: ${task.title}`,
      });
    }
  });

  // Update Task
  socket.on("updateTask", (updatedTask) => {
    tasks = tasks.map((task) =>
      task.id === updatedTask.id ? updatedTask : task
    );
    io.emit("taskUpdated", tasks);
  });

  // Delete Task
  socket.on("deleteTask", (taskId) => {
    tasks = tasks.filter((task) => task.id !== taskId);
    io.emit("taskUpdated", tasks);
  });

  socket.on("disconnect", () => {
    users = users.filter((u) => u.socketId !== socket.id);
    console.log("User disconnected:", socket.id);
  });
});

server.listen(5000, () =>
  console.log(" Server running on port 5000")
);
