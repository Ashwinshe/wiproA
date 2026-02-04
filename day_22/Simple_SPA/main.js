let todos = [];

function showHome() {
  document.getElementById("app").innerHTML = `
    <h2>Welcome 👋</h2>
    <p>This is a Simple Single Page Application</p>
  `;
}

function showTodo() {
  document.getElementById("app").innerHTML = `
    <h2>Todo List</h2>
    <input id="todoInput" placeholder="Enter task" />
    <button onclick="addTodo()">Add</button>
    <ul id="todoList"></ul>
  `;
  renderTodos();
}

function addTodo() {
  const input = document.getElementById("todoInput");
  if (input.value === "") return;

  todos.push({ text: input.value, done: false });
  input.value = "";
  renderTodos();
}

function toggleTodo(index) {
  todos[index].done = !todos[index].done;
  renderTodos();
}

function deleteTodo(index) {
  todos.splice(index, 1);
  renderTodos();
}

function renderTodos() {
  const list = document.getElementById("todoList");
  if (!list) return;

  list.innerHTML = "";

  todos.forEach((todo, index) => {
    list.innerHTML += `
      <li class="${todo.done ? "completed" : ""}">
        ${todo.text}
        <button onclick="toggleTodo(${index})">✔</button>
        <button onclick="deleteTodo(${index})">❌</button>
      </li>
    `;
  });
}

// Load home page by default
showHome();
