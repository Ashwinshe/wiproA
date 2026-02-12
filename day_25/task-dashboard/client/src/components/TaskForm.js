import React, { useState } from "react";
import socket from "../services/socket";

const TaskForm = () => {
  const [form, setForm] = useState({
    title: "",
    description: "",
    assignee: "",
  });

  const handleChange = (e) => {
    setForm({ ...form, [e.target.name]: e.target.value });
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    if (!form.title || !form.assignee) return;

    socket.emit("addTask", {
      id: Date.now(),
      ...form,
      status: "Pending",
    });

    setForm({ title: "", description: "", assignee: "" });
  };

  return (
    <form onSubmit={handleSubmit} style={{ marginBottom: "20px" }}>
      <input
        name="title"
        value={form.title}
        onChange={handleChange}
        placeholder="Title"
        style={{ marginRight: "10px" }}
      />
      <input
        name="description"
        value={form.description}
        onChange={handleChange}
        placeholder="Description"
        style={{ marginRight: "10px" }}
      />
      <input
        name="assignee"
        value={form.assignee}
        onChange={handleChange}
        placeholder="Assign To"
        style={{ marginRight: "10px" }}
      />
      <button type="submit">Add Task</button>
    </form>
  );
};

export default TaskForm;
