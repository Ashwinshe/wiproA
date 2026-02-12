import React, { createContext, useState, useEffect } from "react";
import socket from "../services/socket";

export const TaskContext = createContext();

export const TaskProvider = ({ children }) => {
  const [tasks, setTasks] = useState([]);
  const [notifications, setNotifications] = useState([]);

  useEffect(() => {
    // Initial load
    socket.on("loadTasks", setTasks);

    // Update tasks
    socket.on("taskUpdated", setTasks);

    // Notifications
    socket.on("notification", (data) => {
      setNotifications((prev) => [...prev, data.message]);
    });

    return () => {
      socket.off("loadTasks");
      socket.off("taskUpdated");
      socket.off("notification");
    };
  }, []);

  return (
    <TaskContext.Provider value={{ tasks, setTasks, notifications }}>
      {children}
    </TaskContext.Provider>
  );
};
