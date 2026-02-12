"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const task_service_1 = require("./services/task.service");
const taskService = new task_service_1.TaskService();
taskService.addTask({
    id: 1,
    title: "Setup TypeScript Project",
    completed: false
});
taskService.addTask({
    id: 2,
    title: "Implement Build Process",
    completed: false
});
taskService.completeTask(1);
console.log("All Tasks:");
console.log(taskService.getTasks());
//# sourceMappingURL=index.js.map