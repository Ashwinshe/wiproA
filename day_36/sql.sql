CREATE DATABASE SmartMartRetailDB;
USE SmartMartRetailDB;
CREATE TABLE Suppliers (
    SupplierId INT IDENTITY(1,1) PRIMARY KEY,
    SupplierName NVARCHAR(200) NOT NULL,
    ContactEmail NVARCHAR(200),
    Phone NVARCHAR(50),
    CreatedDate DATETIME2 DEFAULT GETUTCDATE()
);
CREATE TABLE Products (
    ProductId INT IDENTITY(1,1) PRIMARY KEY,
    ProductName NVARCHAR(200) NOT NULL,
    Price DECIMAL(18,2) NOT NULL,
    SupplierId INT NOT NULL,
    CreatedDate DATETIME2 DEFAULT GETUTCDATE(),

    CONSTRAINT FK_Products_Suppliers
        FOREIGN KEY (SupplierId)
        REFERENCES Suppliers(SupplierId)
);
CREATE TABLE Inventory (
    InventoryId INT IDENTITY(1,1) PRIMARY KEY,
    ProductId INT NOT NULL,
    QuantityAvailable INT NOT NULL CHECK (QuantityAvailable >= 0),
    LastUpdated DATETIME2 DEFAULT GETUTCDATE(),
    RowVersion ROWVERSION,

    CONSTRAINT FK_Inventory_Products
        FOREIGN KEY (ProductId)
        REFERENCES Products(ProductId),

    CONSTRAINT UQ_Inventory_Product UNIQUE (ProductId)
);
CREATE TABLE Orders (
    OrderId INT IDENTITY(1,1) PRIMARY KEY,
    OrderDate DATETIME2 DEFAULT GETUTCDATE(),
    Status NVARCHAR(50) NOT NULL
);
CREATE TABLE OrderItems (
    OrderItemId INT IDENTITY(1,1) PRIMARY KEY,
    OrderId INT NOT NULL,
    ProductId INT NOT NULL,
    Quantity INT NOT NULL CHECK (Quantity > 0),

    CONSTRAINT FK_OrderItems_Orders
        FOREIGN KEY (OrderId)
        REFERENCES Orders(OrderId)
        ON DELETE CASCADE,

    CONSTRAINT FK_OrderItems_Products
        FOREIGN KEY (ProductId)
        REFERENCES Products(ProductId)
);

CREATE INDEX IX_Orders_OrderDate
ON Orders (OrderDate);

CREATE INDEX IX_Inventory_ProductId
ON Inventory (ProductId);

CREATE INDEX IX_OrderItems_OrderId
ON OrderItems (OrderId);

CREATE INDEX IX_OrderItems_ProductId
ON OrderItems (ProductId);

CREATE INDEX IX_Products_SupplierId
ON Products (SupplierId);

INSERT INTO Suppliers (SupplierName, ContactEmail, Phone)
VALUES
('TechWorld Distributors', 'tech@world.com', '9876543210'),
('FreshFarm Supplies', 'fresh@farm.com', '9123456780'),
('Urban Retail Hub', 'urban@retail.com', '9988776655'),
('ElectroZone Pvt Ltd', 'sales@electrozone.com', '9090909090'),
('HomeNeeds Wholesale', 'contact@homeneeds.com', '9012345678');

INSERT INTO Products (ProductName, Price, SupplierId)
VALUES
('Laptop', 55000, 1),
('Smartphone', 25000, 1),
('Headphones', 2000, 1),
('Tablet', 18000, 1),
('Bluetooth Speaker', 3500, 1),

('Organic Rice 5kg', 600, 2),
('Cooking Oil 1L', 150, 2),
('Wheat Flour 5kg', 400, 2),
('Sugar 1kg', 45, 2),
('Milk Powder 500g', 320, 2),

('Office Chair', 4500, 3),
('Study Table', 7000, 3),
('Bookshelf', 5500, 3),
('Wardrobe', 15000, 3),
('Dining Table', 20000, 3),

('Refrigerator', 40000, 4),
('LED TV', 60000, 4),
('Washing Machine', 35000, 4),
('Microwave Oven', 12000, 4),
('Air Conditioner', 45000, 4),

('Ceiling Fan', 2500, 5),
('Water Purifier', 9000, 5),
('Gas Stove', 3000, 5),
('Mixer Grinder', 5000, 5),
('Electric Kettle', 1800, 5);
INSERT INTO Inventory (ProductId, QuantityAvailable)
VALUES
(1, 40),(2, 60),(3, 150),(4, 70),(5, 90),
(6, 200),(7, 300),(8, 180),(9, 250),(10, 140),
(11, 80),(12, 50),(13, 45),(14, 30),(15, 25),
(16, 20),(17, 15),(18, 35),(19, 40),(20, 18),
(21, 120),(22, 55),(23, 75),(24, 65),(25, 95);
INSERT INTO Orders (OrderDate, Status)
VALUES
('2025-01-05','Completed'),('2025-01-12','Completed'),
('2025-01-20','Completed'),('2025-02-02','Completed'),
('2025-02-10','Completed'),('2025-02-18','Completed'),
('2025-03-01','Pending'),('2025-03-05','Completed'),
('2025-03-12','Cancelled'),('2025-03-20','Completed'),
('2025-04-01','Completed'),('2025-04-07','Completed'),
('2025-04-15','Completed'),('2025-04-25','Completed'),
('2025-05-02','Completed'),('2025-05-10','Completed'),
('2025-05-18','Completed'),('2025-05-25','Completed'),
('2025-06-01','Completed'),('2025-06-08','Completed'),
('2025-06-15','Completed'),('2025-06-22','Completed'),
('2025-07-01','Completed'),('2025-07-10','Completed'),
('2025-07-18','Completed'),('2025-07-25','Completed'),
('2025-08-02','Completed'),('2025-08-10','Completed'),
('2025-08-18','Completed'),('2025-08-28','Completed'),
('2025-09-05','Completed'),('2025-09-12','Completed'),
('2025-09-20','Completed'),('2025-09-28','Completed'),
('2025-10-05','Completed'),('2025-10-15','Completed'),
('2025-10-22','Completed'),('2025-11-02','Completed'),
('2025-11-10','Completed'),('2025-11-18','Completed');

INSERT INTO OrderItems (OrderId, ProductId, Quantity)
VALUES
-- January Orders
(1,1, 2),(1,3,1),
(2,2, 1),(2,6,4),
(3,4,1),(3,7 ,3),

-- February Orders
(4,5,2),(4,8,5),
(5, 9,3),(5 , 10,2),
(6,1,1 ),(6,12,1),

-- March Orders
(7, 2,1),(7,15,1),
(8,3,2),(8,16,1),
(9,4,1),(9, 17,1),
(10,5 ,1),(10,11, 2),

-- April Orders
(11 ,6 ,5),(11,18,1),
(12 ,7 ,4),(12,19 ,1),
(13, 8,3),(13,20,1),
(14,9 ,2),(14, 13,1),

-- May Orders
(15, 10,3),(15,14,1),
(16,1, 1),(16 ,21,2),
(17, 2,2),(17,22,1),
(18 ,3,1),(18 ,23 ,2),

-- June Orders
(19 ,4,2),(19,24,1),
(20,5 ,1),(20, 25,1),
(21,6,4),(21,11,1),
(22,7 ,3),(22,12 ,2),

-- July Orders
(23,8 ,2),(23, 13,1),
(24,9,1),(24, 14,1),
(25,10,2),(25,15,1),
(26,16,1),(26, 17,1),

-- August Orders
(27,18,1),(27,19,1),
(28, 20,1),(28 ,21,2),
(29,22,1),(29,23,2),
(30,24, 1),(30,25,1),

-- September Orders
(31, 1,1),(31,5 ,2),
(32,2 ,1),(32,6,3),
(33, 3,2),(33 ,7,4),
(34,4 ,1),(34,8,3),

-- October Orders
(35 ,9,2),(35,10,1),
(36,11,1),(36, 12,2),
(37,13, 1),(37,14,1),
(38 ,15,1),(38,16 ,1),

-- November Orders
(39, 17,1),(39,18,1),
(40 ,19,1),(40 ,20,1);

EXEC sp_rename 'Products.ProductName', 'Name', 'COLUMN';

SELECT COLUMN_NAME
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'Products';

USE SmartMartRetailDB;

SELECT * FROM Inventory;