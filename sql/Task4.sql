use AdventureWorks2017;
select * from
(
select top 1 with ties * from Sales.SalesOrderHeader
order by ROW_NUMBER() over (partition by CustomerID order by OrderDate)
) as tbl
order by CustomerID