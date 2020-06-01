select mnth,yr, Sum(SalesAmount) as total
from (
select SalesAmount,MONTH( OrderDate) as mnth, YEAR(OrderDate) as yr from FactResellerSales
UNION ALL SELECT SalesAmount, MONTH(OrderDate) as mnth,YEAR(OrderDate) as yr from FactInternetSales
) as tbl
group by mnth,yr
order by yr,mnth


