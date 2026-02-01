const showMessage = message =>
  `QuickCart says: ${message}`;

const calculateFinalPrice = (price, taxRate, discount) =>
  price + price * taxRate - discount;

const products = [
  { name: "Laptop", price: 1200, inStock: true },
  { name: "Mouse", price: 25, inStock: false },
  { name: "Keyboard", price: 75, inStock: true }
];

console.log(showMessage("Welcome!"));
console.log(calculateFinalPrice(100, 0.1, 15));
console.log(products.filter(p => p.inStock));
