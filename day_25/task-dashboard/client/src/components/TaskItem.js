import React from "react";
import socket from "../services/socket";

const TaskItem = ({ task }) => {
  const toggleStatus = () => {
    socket.emit("updateTask", {
      ...task,
      status: task.status === "Pending" ? "Completed" : "Pending",
    });
  };

  const deleteTask = () => {
    socket.emit("deleteTask", task.id);
  };

  return (
    <div
      style={{
        border: "1px solid #ccc",
        padding: "10px",
        marginBottom: "10px",
        borderRadius: "5px",
        backgroundColor: task.status === "Completed" ? "#e0ffe0" : "#fff",
      }}
    >
      <h3>{task.title}</h3>
      <p>{task.description}</p>
      <p>
        <strong>Assigned to:</strong> {task.assignee}
      </p>
      <p>
        <strong>Status:</strong> {task.status}
      </p>
      <button onClick={toggleStatus} style={{ marginRight: "10px" }}>
        Toggle Status
      </button>
      <button onClick={deleteTask}>Delete</button>
    </div>
  );
};

export default TaskItem;
