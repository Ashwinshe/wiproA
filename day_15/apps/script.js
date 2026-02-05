// =======================
// CALCULATOR FUNCTIONS
// =======================
let display = document.getElementById("calcDisplay");

function appendValue(value) {
  display.value += value;
}

function clearDisplay() {
  display.value = "";
}

function deleteLast() {
  display.value = display.value.slice(0, -1);
}

function calculateResult() {
  try {
    display.value = eval(display.value);
  } catch (error) {
    display.value = "Error";
  }
}


// =======================
// TODO LIST FUNCTIONS
// =======================
let taskInput = document.getElementById("taskInput");
let taskList = document.getElementById("taskList");

function addTask() {
  let taskText = taskInput.value.trim();

  if (taskText === "") {
    alert("Please enter a task!");
    return;
  }

  // Create list item
  let li = document.createElement("li");
  li.innerText = taskText;

  // Action buttons container
  let actionDiv = document.createElement("div");
  actionDiv.classList.add("task-actions");

  // Complete button
  let completeBtn = document.createElement("button");
  completeBtn.innerText = "Done";
  completeBtn.classList.add("complete-btn");

  completeBtn.onclick = function () {
    li.classList.toggle("completed");
  };

  // Delete button
  let deleteBtn = document.createElement("button");
  deleteBtn.innerText = "Delete";
  deleteBtn.classList.add("delete-btn");

  deleteBtn.onclick = function () {
    li.remove();
  };

  actionDiv.appendChild(completeBtn);
  actionDiv.appendChild(deleteBtn);

  li.appendChild(actionDiv);
  taskList.appendChild(li);

  taskInput.value = "";
}
