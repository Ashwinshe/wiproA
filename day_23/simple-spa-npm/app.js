const products = [
  { id: 1, name: "Laptop", price: 60000 },
  { id: 2, name: "Mobile", price: 25000 },
  { id: 3, name: "Headphones", price: 3000 }
];

const app = document.getElementById("app");

// Navigation handler
function navigate(page) {
  if (page === "home") loadHome();
  if (page === "products") loadProducts();
  if (page === "about") loadAbout();
}

// Home page
function loadHome() {
  app.innerHTML = `
    <h2>Welcome to QuickKart</h2>
    <p>Your one-stop shop for electronics.</p>
  `;
}

// Products page
function loadProducts() {
  let html = "<h2>Products</h2><div class='products'>";

  products.forEach(p => {
    html += `
      <div class="product">
        <h3>${p.name}</h3>
        <p>₹${p.price}</p>
      </div>
    `;
  });

  html += "</div>";
  app.innerHTML = html;
}

// About page
function loadAbout() {
  app.innerHTML = `
    <h2>About Us</h2>
    <p>QuickKart is a startup focused on fast and simple shopping experiences.</p>
  `;
}

// Default page load
loadHome();
