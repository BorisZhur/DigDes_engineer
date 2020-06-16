USE AdventureWorks2017;
GO

-- Script 7.1

SELECT * FROM dbo.DatabaseLog;
GO

-- Script 7.2
SET SHOWPLAN_XML ON;
GO

SELECT * FROM dbo.DatabaseLog;
GO

SET SHOWPLAN_XML OFF;
GO

-- Script 7.3

SELECT * FROM dbo.DatabaseLog;
GO

-- Script 7.4

CREATE TABLE dbo.SomeTable
( SomeTableID INT IDENTITY(1, 1) PRIMARY KEY,
  FullName varchar(35)
);
INSERT INTO dbo.SomeTable VALUES('Hello'),('There');
SELECT * FROM dbo.SomeTable;
DROP TABLE dbo.SomeTable;
GO

-- Script 7.5

SELECT cp.objtype AS PlanType,
       OBJECT_NAME(st.objectid,st.dbid) AS ObjectName,
       cp.refcounts AS ReferenceCounts,
       cp.usecounts AS UseCounts,
       st.text AS SQLBatch,
       qp.query_plan AS QueryPlan
FROM sys.dm_exec_cached_plans AS cp
CROSS APPLY sys.dm_exec_query_plan(cp.plan_handle) AS qp
CROSS APPLY sys.dm_exec_sql_text(cp.plan_handle) AS st;
GO

