use master

CREATE DATABASE clothing_shop_management COLLATE Latin1_General_100_CI_AI_SC_UTF8;

use clothing_shop_management

CREATE TRIGGER avoid_duplicate_username
ON Employees
AFTER INSERT, UPDATE
AS
BEGIN
    IF EXISTS (SELECT EmployeeUsername FROM Employees
               GROUP BY EmployeeUsername
               HAVING COUNT(*) > 1)
    BEGIN
        RAISERROR('Username already exists. Please choose a different one.', 16, 1)
        ROLLBACK TRANSACTION
    END
END



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
    EmployeeID INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    EmployeeName NVARCHAR(250) NOT NULL,
    EmployeeRole NVARCHAR(50) NOT NULL,
    EmployeeUsername NVARCHAR(50) NOT NULL UNIQUE,
    EmployeePassword NVARCHAR(50) NOT NULL,
    EmployeePhone NVARCHAR(20) NOT NULL,
    EmployeeAddress NVARCHAR(250) NOT NULL,
	EmployeeBirthDay DATETIME NOT NULL
);

CREATE TABLE Customers (
    CustomerID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CustomerName NVARCHAR(250) NOT NULL,
    CustomerPhone NVARCHAR(20) NOT NULL,
    CustomerAddress NVARCHAR(200) NOT NULL
);

CREATE TABLE Categories (
    CategoryID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    CategoryName NVARCHAR(50) NOT NULL UNIQUE,
    CategoryDescription NVARCHAR(500)
);

CREATE TABLE Products (
    ProductID INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    ProductName NVARCHAR(100) NOT NULL,
    ProductDescription NVARCHAR(500),
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
    [Status] NVARCHAR(50) NOT NULL DEFAULT('Pending'),
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
	Reason NVARCHAR(200),
    FOREIGN KEY (OrderID) REFERENCES Orders(OrderID) ON DELETE CASCADE
);





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


INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay)
VALUES (N'Nguyễn Thị B', N'Staff', N'nguyenthib', N'123', '0987654321', N'456 Đường Lê Duẩn, Quận Thanh Khê, TP Đà Nẵng', '1990-05-12');

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay)
VALUES (N'Trần Văn C', N'Staff', N'tranvanc', N'456', '0123456789', N'789 Đường Nguyễn Văn Linh, Quận Sơn Trà, TP Đà Nẵng', '1995-02-28');

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay)
VALUES (N'Lê Thị D', N'Staff', N'lethid', N'123', '0905123456', N'321 Đường Ngô Quyền, Quận Liên Chiểu, TP Đà Nẵng', '1985-11-07');

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay)
VALUES (N'Phạm Văn E', N'Staff', N'phamvane', N'123', '0987654321', N'741 Đường Hải Phòng, Quận Thanh Khê, TP Đà Nẵng', '1980-09-03');

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay)
VALUES (N'Hoàng Thị F', N'Staff', N'hoangthif', N'123', '0905123456', N'963 Đường Nguyễn Tất Thành, Quận Hải Châu, TP Đà Nẵng', '1997-07-12');

INSERT INTO Employees (EmployeeName, EmployeeRole, EmployeeUsername, EmployeePassword, EmployeePhone, EmployeeAddress, EmployeeBirthDay) 
VALUES 
('Admin', 'Manager', 'admin', 'admin123', '123-456-7890', '123 Main St', '1990-01-01')


INSERT INTO Customers (CustomerName, CustomerPhone, CustomerAddress)
VALUES 
    (N'Nguyễn Văn A', '0987654321', N'Hà Nội, Việt Nam'),
    (N'Phạm Thị B', '0123456789', N'Hồ Chí Minh, Việt Nam'),
    (N'Trần Văn C', '0987654321', N'Đà Nẵng, Việt Nam'),
    (N'Lê Thị D', '0123456789', N'Hải Phòng, Việt Nam'),
    (N'Võ Văn E', '0987654321', N'Cần Thơ, Việt Nam');


	INSERT INTO Categories (CategoryName, CategoryDescription)
	VALUES 
    (N'Áo sơ mi nam', N'Đồ án công sở cho nam giới'),
    (N'Áo sơ mi nữ', N'Đồ án công sở cho nữ giới'),
    (N'Quần jean nam', N'Quần jean dành cho nam giới'),
    (N'Quần jean nữ', N'Quần jean dành cho nữ giới'),
    (N'Đầm dạ hội', N'Đầm dành cho các buổi tiệc tối');

	INSERT INTO Products (ProductName, ProductDescription, ProductPrice, CategoryID, InventoryQuantity)
	VALUES 
    (N'Áo sơ mi trắng cổ đứng', N'Áo sơ mi công sở nam trắng', 250000, 1, 50),
    (N'Áo sơ mi xanh cổ trụ', N'Áo sơ mi công sở nam xanh', 270000, 1, 30),
    (N'Áo sơ mi hoa nữ', N'Áo sơ mi công sở nữ hoa', 220000, 2, 40),
    (N'Áo sơ mi caro nữ', N'Áo sơ mi công sở nữ caro', 200000, 2, 35),
    (N'Quần jean đen nam', N'Quần jean nam màu đen', 350000, 3, 20),
    (N'Quần jean xanh đen nam', N'Quần jean nam màu xanh đen', 370000, 3, 15),
    (N'Quần jean rách nữ', N'Quần jean nữ có đường rách', 300000, 4, 25),
    (N'Quần jean xám nữ', N'Quần jean nữ màu xám', 320000, 4, 30),
    (N'Đầm dạ hội xanh lá', N'Đầm dạ hội màu xanh lá cây', 500000, 5, 10),
    (N'Đầm dạ hội đen trắng', N'Đầm dạ hội đen trắng', 550000, 5, 8);


	INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount)
VALUES (1, 2, 15000000.0);

INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount)
VALUES (3, 1, 7500000.0);

INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount)
VALUES (2, 4, 18000000.0);

INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount)
VALUES (4, 3, 5000000.0);

INSERT INTO Orders (CustomerID, EmployeeID, TotalAmount)
VALUES (5, 2, 12000000.0);


INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity)
VALUES (1, 1, 2);

INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity)
VALUES (1, 2, 3);

INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity)
VALUES (2, 3, 1);

INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity)
VALUES (3, 5, 4);

INSERT INTO OrderItems (OrderID, ProductID, OrderItems_Quantity)
VALUES (5, 8, 2);

INSERT INTO [Returns] (OrderID, Reason) VALUES (1, N'Sản phẩm không đúng mô tả trên website');
INSERT INTO [Returns] (OrderID, Reason) VALUES (2, N'Sản phẩm bị lỗi khi nhận hàng');
INSERT INTO [Returns] (OrderID, Reason) VALUES (3, N'Sản phẩm không phù hợp với nhu cầu sử dụng');
INSERT INTO [Returns] (OrderID, Reason) VALUES (4, N'Sản phẩm bị hỏng trong quá trình vận chuyển');
INSERT INTO [Returns] (OrderID, Reason) VALUES (5, N'Sản phẩm nhận được không đúng kích thước');

select * from Returns


SELECT DISTINCT Products.*
FROM Products
INNER JOIN OrderItems ON Products.ProductID = OrderItems.ProductID
INNER JOIN Orders ON OrderItems.OrderID = Orders.OrderID
WHERE Orders.Status = 'Pending' or Orders.Status = 'Delivered';


SELECT MONTH(OrderDate) AS Month, YEAR(OrderDate) AS Year, SUM(TotalAmount) AS TotalRevenue
FROM Orders
WHERE OrderDate BETWEEN '2023-01-01' AND '2023-12-31'
GROUP BY MONTH(OrderDate), YEAR(OrderDate)
ORDER BY YEAR(OrderDate), MONTH(OrderDate)

SELECT r.ReturnID, o.OrderID, c.CustomerName, r.Reason
FROM Returns r
INNER JOIN Orders o ON r.OrderID = o.OrderID
INNER JOIN Customers c ON o.CustomerID = c.CustomerID
WHERE c.CustomerName like '%a%'

select * from orders where Month(OrderDate) = '4'

SELECT SUM(o.TotalAmount) AS TotalAmountSum 
FROM Orders o
JOIN Customers c ON o.CustomerID = c.CustomerID
JOIN OrderItems oi ON o.OrderID = oi.OrderID
JOIN Products p ON oi.ProductID = p.ProductID
WHERE p.ProductName like N'%z%'


SELECT SUM(TotalAmount) AS TotalAmountSum FROM Orders
WHERE YEAR(OrderDate) = '2023' AND MONTH(OrderDate) = '4'