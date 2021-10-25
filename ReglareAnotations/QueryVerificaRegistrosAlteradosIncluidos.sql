https://www.mssqltips.com/sqlservertip/5276/generic-approach-to-identify-modified-sql-server-rows/

SET NOCOUNT ON
--Following are the parameters you need to select
DECLARE @Date VARCHAR(50) = '2017-12-26'
DECLARE @ModifiedDateColumn VARCHAR(150) = 'LastUpdatedDate'
DECLARE @CreatedDateColumn VARCHAR(150) = 'CreatedDate'
DECLARE @TableName VARCHAR(150)
DECLARE @ColumnList VARCHAR(500) = ' '
DECLARE @SqlStatment VARCHAR(max)
DECLARE @ColumnListwithVarchar VARCHAR(max)
CREATE TABLE #TblSelect (
TableName VARCHAR(150),
PrimaryKeys VARCHAR(150),
PrimaryKeyValues VARCHAR(150),
UpdatedORCreated VARCHAR(1),
ModifiedDate DATETIME
)
CREATE TABLE #TableList (
TableName VARCHAR(150),
Updated VARCHAR(1)
)
INSERT INTO #TableList (
TableName,
Updated
)
SELECT DISTINCT Tab.TABLE_NAME,
'I'
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab,
INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col
WHERE Col.Constraint_Name = Tab.Constraint_Name
AND Col.Table_Name = Tab.Table_Name
AND Constraint_Type = 'PRIMARY KEY'
WHILE (
SELECT Count(1)
FROM #TableList
WHERE Updated = 'I'
) > 0
BEGIN
SELECT TOP 1 @TableName = TableName
FROM #TableList
WHERE Updated = 'I'
SELECT @ColumnList = STRING_AGG(Col.COLUMN_NAME, ',')
FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS Tab,
INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE Col
WHERE Col.Constraint_Name = Tab.Constraint_Name
AND Col.Table_Name = Tab.Table_Name
AND Constraint_Type = 'PRIMARY KEY'
AND Col.TABLE_NAME = @TableName
PRINT @Columnlist
SELECT @ColumnListwithVarchar = @ColumnList
IF CHARINDEX(',', @ColumnList, 1) > 0
BEGIN
SET @ColumnListwithVarchar = 'CONCAT_WS('' '',' + @ColumnList + ')'
END
SET @SqlStatment = 'INSERT INTO #TblSelect (TableName,PrimaryKeys,PrimaryKeyValues,UpdatedORCreated ,ModifiedDate) SELECT '
SET @SqlStatment = @SqlStatment + ' ''' + @TableName + ''',''' + @ColumnList + ''',' + @ColumnListwithVarchar + ',''C'', ' + @CreatedDateColumn + ' FROM ' + @TableName
SET @SqlStatment = @SqlStatment + ' WHERE ' + @CreatedDateColumn + ' >= ''' + @Date + ''''
EXEC (@SqlStatment)
SET @SqlStatment = 'INSERT INTO #TblSelect (TableName,PrimaryKeys,PrimaryKeyValues,UpdatedORCreated ,ModifiedDate) SELECT '
SET @SqlStatment = @SqlStatment + ' ''' + @TableName + ''',''' + @ColumnList + ''',' + @ColumnListwithVarchar + ',''U'', ' + @ModifiedDateColumn + ' FROM ' + @TableName
SET @SqlStatment = @SqlStatment + ' WHERE ' + @ModifiedDateColumn + ' >= ''' + @Date + ''''
EXEC (@SqlStatment)
DELETE
FROM #TableList
WHERE TableName = @TableName
END
SELECT *
FROM #TblSelect
DROP TABLE #TableList
DROP TABLE #TblSelect