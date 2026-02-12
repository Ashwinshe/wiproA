// src/hooks/useSocket.js
import { useEffect, useState } from "react";
import socket from "../services/socket";

const useSocket = () => {
  const [tasks, setTasks] = useState([]);
  const [notifications, setNotifications] = useState([]);

  useEffect(() => {
    socket.on("loadTasks", setTasks);
    socket.on("taskUpdated", setTasks);
    socket.on("notification", (data) =>
      setNotifications((prev) => [...prev, data.message])
    );

    return () => {
      socket.off("loadTasks");
      socket.off("taskUpdated");
      socket.off("notification");
    };
  }, []);

  return { tasks, notifications };
};

export default useSocket;
