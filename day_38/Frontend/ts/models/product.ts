

export interface Product {

    // Unique product identifier (Primary Key)
    id: number;

    // Name of the product (e.g., Barcode Scanner)
    name: string;

    // Selling price of product
    price: number;

    // Current available stock quantity
    stock: number;
}