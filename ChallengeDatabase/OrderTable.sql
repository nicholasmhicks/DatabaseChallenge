CREATE TABLE [dbo].[OrderTable]
(
	[OrderDate] VARCHAR(100) NOT NULL,
	[ProdID] VARCHAR(100) NOT NULL,
	[CustID] VARCHAR(100) NOT NULL,
	[ShippingMode] VARCHAR(100) NOT NULL,
	[Quantity] INT NOT NULL,
	[ShipDate] VARCHAR(100) NOT NULL,
	CONSTRAINT [PK_Order] PRIMARY KEY ([OrderDate],[ProdID],[CustID],[ShippingMode]),
	CONSTRAINT [FK_Order_ToTable] FOREIGN KEY ([ProdID]) REFERENCES Product([ProdID]),
	CONSTRAINT [FK_Order_ToTable_1] FOREIGN KEY ([CustID]) REFERENCES Customer([CustID]),
	CONSTRAINT [FK_Order_ToTable_2] FOREIGN KEY ([ShippingMode]) REFERENCES Shipping([ShipMode])
	
)
