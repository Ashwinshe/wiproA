CREATE DATABASE ECommerceDB;
USE ECommerceDB;
CREATE TABLE Customers(
CustomersID int IDENTITY PRIMARY KEY,
FullName VARCHAR(100) NOT NULL,
Email VARCHAR(100) NOT NULL UNIQUE,
Phone VARCHAR(15),
Address VARCHAR(255),
CreatedAt DATETIME DEFAULT GETDATE()
);
CREATE TABLE Products(
ProductID INT IDENTITY PRIMARY KEY,
ProductName VARCHAR(100) NOT NULL,
Price DECIMAL(10, 2) CHECK (price > 0),
StockQuantity INT CHECK (StockQuantity >= 0),
CreatedAt DATETIME DEFAULT GETDATE()
);
CREATE TABLE Orders(
OrderID INT IDENTITY PRIMARY KEY,
CustomerID INT NOT NULL,
OrderDate DATETIME DEFAULT GETDATE(),
OrderStatus VARCHAR(20) DEFAULT 'Pending',
CONSTRAINT AK_Orders_Customers
     FOREIGN KEY (CustomerID) REFERENCES Customers(CustomersID)
);
CREATE TABLE OrderItems(
OrderItemID INT IDENTITY PRIMARY KEY,
OrderID INT NOT NULL,
ProductID INT NOT NULL,
Quantity INT CHECK (Quantity > 0),
UnitPrice DECIMAL(10, 2) CHECK (UnitPrice > 0 ),
CONSTRAINT AK_OrderItem_Orders
     FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
        ON DELETE CASCADE,
    CONSTRAINT FK_OrderItems_Products
        FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

INSERT INTO Customers (FullName, Email, Phone, Address)
VALUES ('Ram Kumar', 'ram@gmail.com', '9999999999', 'Pune');

INSERT INTO Products (ProductName, Price, StockQuantity)
VALUES ('Wireless Mouse', 799.99, 50);

INSERT INTO Orders(CustomerID)
VALUES (1);

INSERT INTO OrderItems(OrderID, ProductID, Quantity, UnitPrice)
VALUES (1, 1, 2, 799.99);

UPDATE Products
SET StockQuantity = StockQuantity - 2
WHERE ProductID = 1;