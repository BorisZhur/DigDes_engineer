USE MarketDev;
GO

SELECT PostalCode, Country
FROM Marketing.PostalCode 
WHERE StateCode = 'KY'
ORDER BY StateCode, PostalCode;
GO

CREATE NONCLUSTERED INDEX IX_PostalCode_Perf_20100830_A
ON Marketing.PostalCode (StateCode)
INCLUDE (Country,PostalCode);
GO

SELECT PostalCode, Country
FROM Marketing.PostalCode 
WHERE StateCode = 'KY'
ORDER BY StateCode, PostalCode;
GO

CREATE NONCLUSTERED INDEX IX_PostalCode_Perf_20100830_B
ON Marketing.PostalCode (StateCode, PostalCode)
INCLUDE (Country);
GO

SELECT PostalCode, Country
FROM Marketing.PostalCode 
WHERE StateCode = 'KY'
ORDER BY StateCode, PostalCode;
GO