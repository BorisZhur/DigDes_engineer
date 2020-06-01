
select GeographyKey, count(GeographyKey) as total from(
	select GeographyKey from DimCustomer where GeographyKey not in (select GeographyKey from DimReseller)
) as task1
group by GeographyKey
order by total DESC