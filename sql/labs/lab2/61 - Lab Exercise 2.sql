USE MarketDev;
GO

CREATE INDEX IX_WebLog_Perf_20100830_B
  ON Marketing.WebLog (ServerID, SessionStart)
  INCLUDE (SessionID, UserName);
GO

DECLARE @StartTime datetime2 = '2010-08-30 16:27';


SELECT TOP(5000) wl.SessionID, wl.ServerID, wl.UserName 
FROM Marketing.WebLog AS wl
WHERE wl.SessionStart >= @StartTime
ORDER BY wl.SessionStart, wl.ServerID;
GO