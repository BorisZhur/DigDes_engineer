
create PROCEDURE proced1
    @date1 datetime,
	@date2 datetime,
	@k INT OUTPUT
AS
    select * from DimEmployee where (BirthDate>=@date1)and(BirthDate<=@date2)and(MaritalStatus='S')
    select @k = count(*) from DimEmployee where (BirthDate>=@date1)and(BirthDate<=@date2)and(MaritalStatus='S')

go

USE AdventureWorksDW2017;
declare @kk INT
declare @data_1 datetime
declare @data_2 datetime
select @data_1 = convert(datetime,'28.10.1965',105)
select @data_2 = convert(datetime,'28.10.1989',105)
exec proced1 @data_1,@data_2, @kk OUTPUT
print @kk