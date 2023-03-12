CREATE DATABASE clothing_shop_management;
USE clothing_shop_management;

CREATE TRIGGER trg_UpdateInventory
ON OrderItems
AFTER INSERT
AS
BEGIN
    UPDATE Inventory
    SET Inventory_Quantity = Inventory_Quantity - i.OrderItems_Quantity
    FROM Inventory 
    INNER JOIN inserted i ON Inventory.ProductID = i.ProductID
END

CREATE TRIGGER [dbo].[CalculateTotalAmount] ON [dbo].[OrderItems]
AFTER INSERT
AS
BEGIN
    DECLARE @OrderID INT
    SET @OrderID = (SELECT OrderID FROM inserted)
    
    UPDATE Orders
    SET TotalAmount = (SELECT SUM(ProductPrice * OrderItems_Quantity)
                       FROM OrderItems
                       JOIN Products ON OrderItems.ProductID = Products.ProductID
                       WHERE OrderItems.OrderID = @OrderID)
    WHERE OrderID = @OrderID
END

CREATE TABLE Employees (
    EmployeeID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    EmployeeName VARCHAR(250) NOT NULL,
    EmployeeRole VARCHAR(50) NOT NULL,
    EmployeeUsername VARCHAR(50) NOT NULL,
    EmployeePassword VARCHAR(50) NOT NULL,
    EmployeePhone VARCHAR(20) NOT NULL,
    EmployeeAddress VARCHAR(250) NOT NULL,
	EmployeeBirthDay DATETIME NOT NULL
);


CREATE TABLE Customers (
    CustomerID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(250) NOT NULL,
    CustomerPhone VARCHAR(20) NOT NULL,
    CustomerAddress VARCHAR(200) NOT NULL
);

CREATE TABLE Categories (
    CategoryID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CategoryName VARCHAR(50) NOT NULL UNIQUE,
    CategoryDescription VARCHAR(500)
);

CREATE TABLE Products (
    ProductID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ProductName VARCHAR(100) NOT NULL,
    ProductDescription VARCHAR(500),
    ProductPrice FLOAT NOT NULL,
    CategoryID INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID)
);

CREATE TABLE Inventory (
    InventoryID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ProductID INT NOT NULL,
    Inventory_Quantity INT NOT NULL,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE Orders (
    OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    EmployeeID INT NOT NULL,
	OrderDate DATETIME NOT NULL DEFAULT(GETDATE()),
    TotalAmount FLOAT NOT NULL,
    [Status] VARCHAR(50) NOT NULL DEFAULT('Pending'),
	ModifiedDate DATETIME,
	FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID),
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID)
);

CREATE TABLE OrderItems (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    OrderItems_Quantity INT NOT NULL,
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID),
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID)
);

CREATE TABLE [Returns] (
	[ReturnID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
	Reason VARCHAR(200),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
);

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay) 
VALUES 
('John Smith', 'Manager', 'john.smith', 'password123', '123-456-7890', '123 Main St', '1990-01-01'),
('Sarah Johnson', 'Sales', 'sarah.johnson', 'password456', '555-123-4567', '456 Elm St', '1995-02-14'),
('Michael Brown', 'IT', 'michael.brown', 'password789', '888-555-1234', '789 Oak St', '1985-05-15'),
('Emily Davis', 'HR', 'emily.davis', 'passwordabc', '111-222-3333', '321 Maple St', '1988-10-27'),
('David Lee', 'Finance', 'david.lee', 'passworddef', '444-777-8888', '567 Pine St', '1993-06-30');


INSERT INTO Customers (CustomerName, CustomerPhone, CustomerAddress)
VALUES 
('John Smith', '555-1234', '123 Main St.'),
('Jane Doe', '555-5678', '456 High St.'),
('Bob Johnson', '555-2468', '789 Broad St.'),
('Sarah Lee', '555-3691', '369 Maple Ave.'),
('David Chen', '555-4836', '483 Oak St.');

INSERT INTO Categories (CategoryName, CategoryDescription)
VALUES 
('Clothing for Men', 'A variety of clothing options designed for men.'),
('Clothing for Women', 'A variety of clothing options designed for women.'),
('Clothing for children', 'A variety of clothing options designed for children.'),
('Sportswear', 'Clothing designed for athletic and sport activities.'),
('Outerwear', 'Clothing designed to be worn over other garments, such as jackets and coats.');

INSERT INTO Products (ProductName, ProductDescription, ProductPrice, CategoryID)
VALUES 
('Mens T-Shirt', 'A comfortable cotton T-shirt for men.', 19.99, 1),
('Womens Dress', 'A stylish dress for women made from breathable fabric.', 49.99, 2),
('Childrens Jeans', 'Durable jeans for kids.', 29.99, 3),
('Athletic Shorts', 'Moisture-wicking shorts for sports and exercise.', 24.99, 4),
('Winter Coat', 'A warm and cozy coat for cold weather.', 99.99, 5);

INSERT INTO Inventory (ProductID, Inventory_Quantity)
VALUES 
(1, 100),
(2, 50),
(3, 75),
(4, 120),
(5, 25);

-- Insert orders
INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount)
VALUES 
(1, 1, 299.95),
(2, 1, 174.98),
(3, 2, 409.97),
(4, 2, 599.94),
(5, 3, 89.97);

-- Insert order items
INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity)
VALUES 
(1, 1, 3),
(1, 3, 2),
(2, 2, 1),
(2, 4, 2),
(3, 3, 1),
(3, 4, 4),
(3, 5, 2),
(4, 1, 2),
(4, 2, 1),
(4, 3, 3),
(5, 5, 1);

select * from dbo.Employees
select * from dbo.Orders