
create PROCEDURE proced1
    @date1 datetime,
	@date2 datetime,
	@k INT OUTPUT
AS
    select * from HumanResources.Employee where (BirthDate>=@date1)and(BirthDate<=@date2)and(MaritalStatus='S')and(Gender='M')
    select @k = count(*) from HumanResources.Employee where (BirthDate>=@date1)and(BirthDate<=@date2)and(MaritalStatus='S')and(Gender='M')

go

USE AdventureWorks2017;
declare @kk INT
declare @data_1 datetime
declare @data_2 datetime
select @data_1 = convert(datetime,'28.10.1975',105)
select @data_2 = convert(datetime,'28.10.1989',105)
exec proced1 @data_1,@data_2, @kk OUTPUT
print @kk

drop procedure proced1