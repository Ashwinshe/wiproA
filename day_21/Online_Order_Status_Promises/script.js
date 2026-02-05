// Fake Order Data (Simulated)
let order = {
  orderId: 101,
  status: "delivered", // placed, confirmed, shipped, delivered
  delivered: true
};

// Function 1: Check Order Status
function checkOrderStatus(orderId) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (order.orderId === orderId) {
        resolve(order.status);
      } else {
        reject(" Order not found!");
      }
    }, 2000);
  });
}

// Function 2: Confirm Delivery
function confirmDelivery(status) {
  return new Promise((resolve, reject) => {
    setTimeout(() => {
      if (status === "delivered" && order.delivered === true) {
        resolve(" Order Delivered Successfully!");
      } else {
        reject("Order is not delivered yet!");
      }
    }, 2000);
  });
}

// Main Function (Called on Button Click)
function startChecking() {
  let inputId = Number(document.getElementById("orderId").value);
  let output = document.getElementById("output");

  output.innerHTML = " Checking order status...";

  checkOrderStatus(inputId)
    .then((status) => {
      output.innerHTML = ` Order Status: <b>${status}</b><br>⏳ Confirming delivery...`;
      return confirmDelivery(status);
    })
    .then((message) => {
      output.innerHTML += `<br><b>${message}</b>`;
    })
    .catch((error) => {
      output.innerHTML = `<b style="color:red;">${error}</b>`;
    });
}
