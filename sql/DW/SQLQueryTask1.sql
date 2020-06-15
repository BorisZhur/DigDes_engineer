USE AdventureWorksDW2017;
select City, count(City) as total from(
	select GeographyKey from DimCustomer where GeographyKey not in (select GeographyKey from DimReseller)
) as task1
left join DimGeography on DimGeography.GeographyKey=task1.GeographyKey
group by City
order by total DESC