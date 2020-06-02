USE AdventureWorksDW2017;
select * from
(
select top 1 with ties * from FactInternetSales
order by ROW_NUMBER() over (partition by CustomerKey order by OrderDate)
) as tbl
order by SalesOrderNumber