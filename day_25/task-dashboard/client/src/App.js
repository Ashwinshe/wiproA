import React from "react";
import { TaskProvider } from "./context/TaskContext";
import TaskForm from "./components/TaskForm";
import TaskList from "./components/TaskList";
import Notification from "./components/Notification";
import ThemeToggle from "./components/ThemeToggle";

function App() {
  return (
    <TaskProvider>
      <ThemeToggle>
        <h1>Real-Time Task Dashboard</h1>
        <Notification />
        <TaskForm />
        <TaskList />
      </ThemeToggle>
    </TaskProvider>
  );
}

export default App;
