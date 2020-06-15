USE AdventureWorksDW2017;

select DimCustomer.FirstName, DimCustomer.LastName, FactInternetSales.ProductKey, count (*) as total
from (FactInternetSales inner join DimCustomer on FactInternetSales.CustomerKey=DimCustomer.CustomerKey)
group by FirstName,LastName, ProductKey
order by FirstName ASC, LastName ASC, total desc

