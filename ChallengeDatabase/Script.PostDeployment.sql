/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/


IF '$(LoadTestData)' = 'true'

BEGIN

DELETE FROM OrderTable;
DELETE FROM Customer;
DELETE FROM Product;
DELETE FROM Shipping;
DELETE FROM Category;
DELETE FROM Region;
DELETE FROM Segment;

INSERT INTO Segment (SegID, SegName) VALUES
(1,'Consumer'),
(2,'Corporate'),
(3,'Home Officer');

INSERT INTO Region (Region) VALUES
('South'),
('Central'),
('West'),
('East'),
('North');

INSERT INTO Category (CatID, CatName) VALUES
(1,'Furniture'),
(2,'Office Supplies'),
(3,'Technology');

INSERT INTO Shipping (ShipMode) VALUES
('Second Class'),
('Standard Class'),
('First Class'),
('Overnight Express');

INSERT INTO Product (ProdID, Description, UnitPrice, Category) VALUES
('FUR-BO-10001798', 'Bush Somerset Collection Bookcase', '261.96', 1),
('FUR-CH-10000454', 'Mitel 5320 IP Phone VoIP phone', '731.94', 2),
('OFF-LA-10000240', 'Self-Adhesive Address Labels for Typewriters by Universal', '14.62', 3);

INSERT INTO Customer (CustID, FullName, Country, City, State, PostCode, SegID, Region) VALUES
('CG-12520', 'Claire Gute',	'United States', 'Henderson', 'Oklahoma', 42420, 1,	'Central'),
('DV-13045', 'Darrin Van Huff',	'United States', 'Los Angeles', 'California', 90036, 2, 'West'),
('SO-20335', 'Sean O''Donnell',	'United States', 'Fort Lauderdale', 'Florida', 33311, 1, 'South'),
('BH-11710', 'Brosina Hoffman',	'United States', 'Los Angeles', 'California', 90032, 3,	'West');

INSERT INTO OrderTable (CustID, ProdID, OrderDate, Quantity, ShipDate, ShippingMode) VALUES 
('CG-12520', 'FUR-BO-10001798', '8/11/2016', 2, '11/11/2016', 'Second Class'),
('CG-12520', 'FUR-CH-10000454',	'8/11/2016', 3,	'11/11/2016',	'Second Class'),
('CG-12520',	'OFF-LA-10000240',	'12/06/2016',	2,	'16/06/2016',	'Second Class'),
('DV-13045',	'OFF-LA-10000240',	'21/11/2015',	2,	'26/11/2015',	'Second Class'),
('DV-13045',	'OFF-LA-10000240',	'11/10/2014',	1,	'15/10/2014',	'Standard Class'),
('DV-13045',	'FUR-CH-10000454',	'12/11/2016',	9,	'16/11/2016',	'Standard Class'),
('SO-20335',	'OFF-LA-10000240',	'2/09/2016',	5,	'8/09/2016',	'Standard Class'),
('SO-20335',	'FUR-BO-10001798',	'25/08/2017',	2,	'29/08/2017',	'Overnight Express'),
('SO-20335',	'FUR-CH-10000454',	'22/06/2017',	2,	'26/06/2017',	'Standard Class'),
('SO-20335',	'FUR-BO-10001798',	'1/05/2017',	3,	'2/05/2017',	'First Class');

END;