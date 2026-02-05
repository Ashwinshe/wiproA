let allProducts = [];
let cartCount = 0;

// -------------------------------
// AJAX Fetch using jQuery + Promise
// -------------------------------
function fetchProducts() {
  return new Promise((resolve, reject) => {
    $("#loader").removeClass("hidden");
    $("#errorBox").addClass("hidden");

    $.ajax({
      url: "products.json",
      method: "GET",
      dataType: "json",
      success: function (data) {
        resolve(data);
      },
      error: function () {
        reject(" Failed to load products. Please check products.json file.");
      },
      complete: function () {
        $("#loader").addClass("hidden");
      }
    });
  });
}

// -------------------------------
// Render Products (Performance Optimized)
// -------------------------------
function renderProducts(products) {
  const container = document.getElementById("productContainer");
  container.innerHTML = "";

  if (products.length === 0) {
    container.innerHTML = "<h2>No Products Found ❌</h2>";
    return;
  }

  let fragment = document.createDocumentFragment();

  products.forEach((p) => {
    let card = document.createElement("div");
    card.className = "product-card";

    card.innerHTML = `
      <h3>${p.name}</h3>
      <p><b>Category:</b> ${p.category}</p>
      <p><b>Price:</b> ₹${p.price}</p>
      <p><b>Stock:</b> ${p.stock}</p>
      <p><b>Rating:</b> ⭐ ${p.rating}</p>

      <button class="add-btn" data-id="${p.id}">Add to Cart</button>
      <button class="details-btn" data-id="${p.id}">View Details</button>
    `;

    fragment.appendChild(card);
  });

  container.appendChild(fragment);
}

// -------------------------------
// Apply Search + Filter + Sort
// -------------------------------
function applyFilters() {
  let searchValue = $("#searchBox").val().toLowerCase();
  let categoryValue = $("#categoryFilter").val();
  let sortValue = $("#sortBy").val();

  let filtered = allProducts.filter((p) => {
    let matchSearch = p.name.toLowerCase().includes(searchValue);
    let matchCategory = categoryValue === "all" || p.category === categoryValue;
    return matchSearch && matchCategory;
  });

  if (sortValue === "priceLow") {
    filtered.sort((a, b) => a.price - b.price);
  } else if (sortValue === "priceHigh") {
    filtered.sort((a, b) => b.price - a.price);
  } else if (sortValue === "ratingHigh") {
    filtered.sort((a, b) => b.rating - a.rating);
  }

  renderProducts(filtered);
}

// -------------------------------
// Load Products using Async/Await
// -------------------------------
async function loadProducts() {
  try {
    allProducts = await fetchProducts();
    renderProducts(allProducts);
  } catch (err) {
    $("#errorBox").removeClass("hidden").text(err);
  }
}

// -------------------------------
// Event Delegation (Efficient Handling)
// -------------------------------
document.getElementById("productContainer").addEventListener("click", function (e) {

  // Add to cart
  if (e.target.classList.contains("add-btn")) {
    cartCount++;
    document.getElementById("cartCount").textContent = cartCount;
    alert(" Added to cart successfully!");
  }

  // View details
  if (e.target.classList.contains("details-btn")) {
    let productId = Number(e.target.dataset.id);
    let product = allProducts.find((p) => p.id === productId);

    alert(
      `Product Details\n\nName: ${product.name}\nCategory: ${product.category}\nPrice: ₹${product.price}\nStock: ${product.stock}\nRating: ${product.rating}`
    );
  }
});

// -------------------------------
// Input Event Listeners
// -------------------------------
$("#searchBox").on("input", applyFilters);
$("#categoryFilter").on("change", applyFilters);
$("#sortBy").on("change", applyFilters);

// Reload Button
$("#reloadBtn").on("click", loadProducts);

// -------------------------------
// Initial Load
// -------------------------------
loadProducts();
