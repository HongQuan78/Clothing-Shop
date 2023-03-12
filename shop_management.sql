use master

CREATE DATABASE clothing_shop_management;
USE clothing_shop_management;

CREATE TRIGGER trg_OrderItems
ON OrderItems
AFTER INSERT
AS
BEGIN
    UPDATE Products
    SET InventoryQuantity = InventoryQuantity - inserted.OrderItems_Quantity
    FROM Products
    INNER JOIN inserted ON Products.ProductID = inserted.ProductID
END

CREATE TRIGGER tr_OrderItems_Delete
ON OrderItems
AFTER DELETE
AS
BEGIN
    UPDATE Products
    SET InventoryQuantity = InventoryQuantity + OrderItems_Quantity
    FROM Products p
    INNER JOIN deleted d ON p.ProductID = d.ProductID
END;

CREATE TRIGGER UpdateTotalAmount
ON OrderItems
AFTER INSERT, DELETE
AS
BEGIN
    -- Update TotalAmount for the affected order(s)
    UPDATE Orders
    SET TotalAmount = (
        SELECT SUM(ProductPrice * OrderItems_Quantity)
        FROM OrderItems
        INNER JOIN Products ON OrderItems.ProductID = Products.ProductID
        WHERE OrderItems.OrderID = Orders.OrderID
    )
    WHERE Orders.OrderID IN (
        SELECT DISTINCT OrderID FROM inserted
        UNION SELECT DISTINCT OrderID FROM deleted
    )
END;

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
	InventoryQuantity INT NOT NULL,
    FOREIGN KEY (CategoryID) REFERENCES Categories(CategoryID) ON DELETE CASCADE
);


CREATE TABLE Orders (
    OrderID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CustomerID INT NOT NULL,
    EmployeeID INT NOT NULL,
	OrderDate DATETIME NOT NULL DEFAULT(GETDATE()),
    TotalAmount FLOAT,
    [Status] VARCHAR(50) NOT NULL DEFAULT('Pending'),
	ModifiedDate DATETIME,
	FOREIGN KEY (EmployeeID) REFERENCES Employees(EmployeeID) ON DELETE CASCADE,
    FOREIGN KEY (CustomerID) REFERENCES Customers(CustomerID) ON DELETE CASCADE
);

CREATE TABLE OrderItems (
    OrderID INT NOT NULL,
    ProductID INT NOT NULL,
    OrderItems_Quantity INT NOT NULL,
    PRIMARY KEY (OrderID, ProductID),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE,
    FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE
);

CREATE TABLE [Returns] (
	[ReturnID] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    OrderID INT NOT NULL,
	Reason VARCHAR(200),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE
);

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay) 
VALUES 
('Admin', 'Manager', 'admin', 'admin123', '123-456-7890', '123 Main St', '1990-01-01'),
('Sarah Johnson', 'Staff', 'sarah.johnson', 'password456', '555-123-4567', '456 Elm St', '1995-02-14'),
('Michael Brown', 'Staff', 'michael.brown', 'password789', '888-555-1234', '789 Oak St', '1985-05-15'),
('Emily Davis', 'Staff', 'emily.davis', 'passwordabc', '111-222-3333', '321 Maple St', '1988-10-27'),
('David Lee', 'Staff', 'david.lee', 'passworddef', '444-777-8888', '567 Pine St', '1993-06-30');


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

INSERT INTO Products (ProductName, ProductDescription, ProductPrice, CategoryID, InventoryQuantity)
VALUES 
('Mens T-Shirt', 'A comfortable cotton T-shirt for men.', 19.99, 1, 999),
('Womens Dress', 'A stylish dress for women made from breathable fabric.', 49.99, 2, 999),
('Childrens Jeans', 'Durable jeans for kids.', 29.99, 3, 999),
('Athletic Shorts', 'Moisture-wicking shorts for sports and exercise.', 24.99, 4, 999),
('Winter Coat', 'A warm and cozy coat for cold weather.', 99.99, 5, 999);

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




select* from dbo.Returns

select * from dbo.OrderItems
select * from Categories
select * from dbo.Products

select Products.ProductID, Products.ProductName, Products.ProductDescription,
 Products.ProductPrice, Categories.CategoryID, Categories.CategoryName, Products.InventoryQuantity
from Products inner join Categories
on Products.CategoryID = Categories.CategoryID

select * from dbo.Employees

select OrderID, Products.ProductID, ProductName, ProductDescription, ProductPrice, OrderItems_Quantity from dbo.OrderItems inner join Products
on OrderItems.ProductID = Products.ProductID
where OrderID = 2


select * from Returns
SELECT * FROM Products


SELECT SUM(ProductPrice * OrderItems_Quantity)
                       FROM OrderItems
                       JOIN Products ON OrderItems.ProductID = Products.ProductID
                       WHERE OrderItems.OrderID = 3

					   select * from dbo.Orders where OrderID = 3
					   select * from OrderItems  where OrderID = 3
					   select * from dbo.Employees