
---- query recupera data dos backups realizados

SELECT 
CONVERT(CHAR(100), SERVERPROPERTY('Servername')) AS Server, 
msdb.dbo.backupset.database_name, 
msdb.dbo.backupset.backup_start_date, 
msdb.dbo.backupset.backup_finish_date, 
msdb.dbo.backupset.expiration_date, 
CASE msdb..backupset.type 
WHEN 'D' THEN 'Database' 
WHEN 'L' THEN 'Log' 
END AS backup_type, 
msdb.dbo.backupset.backup_size, 
msdb.dbo.backupmediafamily.logical_device_name, 
msdb.dbo.backupmediafamily.physical_device_name, 
msdb.dbo.backupset.name AS backupset_name, 
msdb.dbo.backupset.description 
FROM msdb.dbo.backupmediafamily 
INNER JOIN msdb.dbo.backupset ON msdb.dbo.backupmediafamily.media_set_id = msdb.dbo.backupset.media_set_id 
WHERE (CONVERT(datetime, msdb.dbo.backupset.backup_start_date, 102) >= GETDATE() - 7) 
and msdb..backupset.type = 'D'
ORDER BY 
msdb.dbo.backupset.database_name, 
msdb.dbo.backupset.backup_finish_date desc

---- query verifica ultimo insert na tabela

SELECT OBJECT_NAME(OBJECT_ID) AS TableName,
 last_user_update,*
FROM sys.dm_db_index_usage_stats
WHERE database_id = DB_ID( 'dadosprocesso')
AND OBJECT_ID=OBJECT_ID('ProcessamentoCaptura')

---- pesquisar quem esta on line no banco

sp_who

---- pesquisar status do banco de dados

select databasepropertyex ('dadosprocesso', 'status') AS DBSTATUS 

----

CREATE DATABASE [myDB] GO
-- Take the Database Offline
ALTER DATABASE [myDB] SET OFFLINE WITH
ROLLBACK IMMEDIATE
GO
-- Take the Database Online
ALTER DATABASE ForTest SET ONLINE
GO
-- Clean up
DROP DATABASE [myDB] GO

ALTER DATABASE ForTest SET ONLINE
GO

DROP DATABASE ForTest 

SELECT IS_SRVROLEMEMBER('sysadmin') as I_am_SA, * FROM sys.databases WHERE name = 'ForTest'
