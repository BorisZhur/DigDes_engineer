USE AdventureWorks2017;
GO

-- Script 7.15

SELECT DISTINCT a.City 
FROM Person.Address AS a
ORDER BY a.City;

SELECT a.City
FROM Person.Address AS a
GROUP BY a.City
ORDER BY a.City;
GO


