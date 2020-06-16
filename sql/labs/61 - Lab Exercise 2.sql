USE AdventureWorks2017;
GO

-- Script 7.6

SELECT * FROM Person.Person;
GO

-- Script 7.7

SELECT * FROM Person.Person WHERE BusinessEntityID = 12;
GO

-- Script 7.8

SELECT * FROM Production.ProductInventory ORDER BY Shelf;
GO

-- Script 7.9

SELECT * FROM dbo.DatabaseLog WHERE DatabaseLogID = 1;
GO

-- Script 7.10

SELECT AddressID, AddressLine1, AddressLine2,
       City, StateProvinceID, PostalCode
FROM Person.Address 
WHERE StateProvinceID = 32;
GO

-- Script 7.11

SELECT AddressID, AddressLine1, AddressLine2,
       City, StateProvinceID, PostalCode
FROM Person.Address 
WHERE StateProvinceID = 79;
GO

-- Script 7.12

SELECT City, COUNT(City) AS CityCount
FROM Person.Address
GROUP BY City;
GO

-- Script 7.13

SELECT StateProvinceID, COUNT(1) AS StateProvinceCount
FROM Person.Address
GROUP BY StateProvinceID;
GO

-- Script 7.14

SELECT City, COUNT(City) AS CityCount
FROM Person.Address
GROUP BY City
HAVING COUNT(1) > 5;
GO

