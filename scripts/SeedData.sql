-- ============================
-- Insert sample clients
-- ============================
INSERT INTO [ShopAppDb].[dbo].[Clients] (Id, FullName, BirthDate, RegisteredAt) VALUES
(NEWID(), 'John Doe', '1990-11-05', '2025-01-01'),
(NEWID(), 'Jane Smith', '1985-11-05', '2025-02-15'),
(NEWID(), 'Alice Johnson', '2000-12-01', '2025-03-20');

-- ============================
-- Insert sample products
-- ============================
INSERT INTO [ShopAppDb].[dbo].[Products] (Id, Name, Category, SKU, Price) VALUES
(NEWID(), 'Laptop', 'Electronics', 'LP1001', 1200.00),
(NEWID(), 'Smartphone', 'Electronics', 'SP2001', 800.00),
(NEWID(), 'Book A', 'Books', 'BK3001', 25.50),
(NEWID(), 'Book B', 'Books', 'BK3002', 30.00),
(NEWID(), 'Headphones', 'Electronics', 'HP4001', 150.00);

-- ============================
-- Insert sample purchases
-- ============================
-- Purchase 1
DECLARE @purchase1Id UNIQUEIDENTIFIER = NEWID();
INSERT INTO [ShopAppDb].[dbo].[Purchases] (Id, Number, ClientId, Date, Total)
VALUES (@purchase1Id, 'PUR-001', (SELECT TOP 1 Id FROM Clients WHERE FullName='John Doe'), GETDATE(), 2050.00);

INSERT INTO [ShopAppDb].[dbo].[PurchaseItems] (Id, PurchaseId, ProductId, Quantity, UnitPrice)
VALUES
(NEWID(), @purchase1Id, (SELECT TOP 1 Id FROM Products WHERE Name='Laptop'), 1, 55),
(NEWID(), @purchase1Id, (SELECT TOP 1 Id FROM Products WHERE Name='Headphones'), 2, 88);

-- Purchase 2
DECLARE @purchase2Id UNIQUEIDENTIFIER = NEWID();
INSERT INTO [ShopAppDb].[dbo].[Purchases] (Id, Number, ClientId, Date, Total)
VALUES (@purchase2Id, 'PUR-002', (SELECT TOP 1 Id FROM Clients WHERE FullName='Jane Smith'), DATEADD(DAY, -3, GETDATE()), 830.00);

INSERT INTO [ShopAppDb].[dbo].[PurchaseItems] (Id, PurchaseId, ProductId, Quantity, UnitPrice)
VALUES
(NEWID(), @purchase2Id, (SELECT TOP 1 Id FROM Products WHERE Name='Smartphone'), 1, 852),
(NEWID(), @purchase2Id, (SELECT TOP 1 Id FROM Products WHERE Name='Book A'), 1, 61);

-- Purchase 3
DECLARE @purchase3Id UNIQUEIDENTIFIER = NEWID();
INSERT INTO Purchases (Id, Number, ClientId, Date, Total)
VALUES (@purchase3Id, 'PUR-003', (SELECT TOP 1 Id FROM Clients WHERE FullName='Alice Johnson'), DATEADD(DAY, -10, GETDATE()), 55.50);

INSERT INTO [ShopAppDb].[dbo].[PurchaseItems] (Id, PurchaseId, ProductId, Quantity, UnitPrice)
VALUES
(NEWID(), @purchase3Id, (SELECT TOP 1 Id FROM Products WHERE Name='Book A'), 1, 38),
(NEWID(), @purchase3Id, (SELECT TOP 1 Id FROM Products WHERE Name='Book B'), 1, 92);