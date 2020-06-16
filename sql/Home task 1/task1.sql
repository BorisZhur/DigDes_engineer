use AdventureWorks2017;

drop table #task1

select 
	Person.Person.PersonType,
	Person.BusinessEntityAddress.BusinessEntityID, 
	Person.BusinessEntityAddress.AddressID,
	Person.Address.City
into #task1	
from Person.BusinessEntityAddress
inner join Person.Person on (Person.Person.BusinessEntityID = Person.BusinessEntityAddress.BusinessEntityID)
inner join Person.Address on (Person.BusinessEntityAddress.AddressID = Person.Address.AddressID)

order by PersonType

Delete from #task1 where PersonType !='EM'

select city ,count(city) as k from Sales.SalesOrderHeader
inner join Person.Address on (ShipToAddressID = Person.Address.AddressID)
where City not in (select City from #task1)
group by city
order by k desc