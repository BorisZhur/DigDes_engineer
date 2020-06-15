use AdventureWorks2017;
select mnth, yr, sum(TotalDue) as total from
(select month(OrderDate) as mnth, year(OrderDate) as yr, TotalDue from Sales.SalesOrderHeader) as tbl1
group by mnth, yr
order by yr asc, mnth asc