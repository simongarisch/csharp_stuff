-- CREATE THE DATABASE
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'CustomerOrderViewer')
BEGIN
	CREATE DATABASE CustomerOrderViewer;
END
GO

USE CustomerOrderViewer;

-- AND THE TABLES
-- CUSTOMER TABLE
IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Customer')
BEGIN
CREATE TABLE [dbo].[Customer] (
	CustomerId INT IDENTITY(1,1) NOT NULL,
	FirstName VARCHAR(50) NOT NULL,
	MiddleName VARCHAR(50) NULL,
	LastName VARCHAR(50) NOT NULL,
	Age INT NOT NULL,
	PRIMARY KEY (CustomerId)
);
END
GO

-- ITEM TABLE
IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'Item')
BEGIN
CREATE TABLE [dbo].[Item] (
	ItemId INT IDENTITY(1,1) NOT NULL,
	[Description] VARCHAR(100) NOT NULL,
	Price DECIMAL(4,2) NOT NULL,
	PRIMARY KEY (ItemId)
);
END
GO

-- CUSTOMER_ORDER TABLE
IF NOT EXISTS (SELECT [name] FROM sys.tables WHERE [name] = 'CustomerOrder')
BEGIN
CREATE TABLE [dbo].[CustomerOrder] (
	CustomerOrderId INT IDENTITY(1,1) NOT NULL,
	CustomerId INT NOT NULL,
	ItemId INT NOT NULL,
	PRIMARY KEY (CustomerOrderId),
	FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId),
	FOREIGN KEY (ItemId) REFERENCES Item(ItemId)
);
END
GO
