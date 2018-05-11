CREATE TABLE [dbo].[Customer]
(
	[CustID] VARCHAR(100) NOT NULL PRIMARY KEY,
	[FullName] VARCHAR(100) NOT NULL,
	[Country] VARCHAR(100) NOT NULL,
	[City] VARCHAR(100) NOT NULL,
	[State] VARCHAR(10) NOT NULL,
	[PostCode] INT NOT NULL,
	[SegID] INT, 
    [Region] VARCHAR(100),
	CONSTRAINT [FK_Customer_ToTable] FOREIGN KEY ([SegID]) REFERENCES Segment([SegID]), 
    CONSTRAINT [FK_Customer_ToTable_1] FOREIGN KEY ([Region]) REFERENCES Region([Region])


)
