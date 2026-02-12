import { TaskService } from "./services/task.service";
import { Logger } from "./utils/logger";

const taskService = new TaskService();

Logger.info("Application Started");

taskService.addTask({
  id: 1,
  title: "Setup TypeScript Project",
  completed: false
});

Logger.info("Task Added: Setup TypeScript Project");

taskService.completeTask(1);

Logger.warn("Task marked as completed");

console.log(taskService.getTasks());

Logger.info("Application Finished");
