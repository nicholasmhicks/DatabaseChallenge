CREATE TABLE [dbo].[Product]
(
	[ProdID] VARCHAR(100) NOT NULL PRIMARY KEY,
	[Description] VARCHAR(200) NOT NULL,
	[UnitPrice] VARCHAR(100) NOT NULL,
	[Category] INT,
	CONSTRAINT [FK_Product_ToTable] FOREIGN KEY ([Category]) REFERENCES Category([CatID])
)
