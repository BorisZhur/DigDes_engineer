use AdventureWorks2017
select FirstName,LastName, productID, count (*) as total from sales.SalesOrderHeader
inner join Sales.Customer on (sales.SalesOrderHeader.CustomerID=Sales.Customer.CustomerID)
inner join Person.Person on (Sales.Customer.PersonID=Person.BusinessEntityID)
inner join Sales.SalesOrderDetail on (sales.SalesOrderHeader.SalesOrderID = Sales.SalesOrderDetail.SalesOrderID)
group by FirstName,LastName,ProductID
order by FirstName asc, LastName asc, total desc