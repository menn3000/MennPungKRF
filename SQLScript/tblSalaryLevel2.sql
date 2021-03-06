/*
   7 กุมภาพันธ์ 25570:30:28
   User: 
   Server: (local)
   Database: STAir
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
CREATE TABLE dbo.Tmp_tblSalaryLevel
	(
	ID int NOT NULL IDENTITY (1, 1),
	SalaryLevel decimal(19, 2) NULL,
	Salary decimal(19, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.Tmp_tblSalaryLevel SET (LOCK_ESCALATION = TABLE)
GO
SET IDENTITY_INSERT dbo.Tmp_tblSalaryLevel ON
GO
IF EXISTS(SELECT * FROM dbo.tblSalaryLevel)
	 EXEC('INSERT INTO dbo.Tmp_tblSalaryLevel (ID, SalaryLevel, Salary)
		SELECT ID, SalaryLevel, Salary FROM dbo.tblSalaryLevel WITH (HOLDLOCK TABLOCKX)')
GO
SET IDENTITY_INSERT dbo.Tmp_tblSalaryLevel OFF
GO
DROP TABLE dbo.tblSalaryLevel
GO
EXECUTE sp_rename N'dbo.Tmp_tblSalaryLevel', N'tblSalaryLevel', 'OBJECT' 
GO
ALTER TABLE dbo.tblSalaryLevel ADD CONSTRAINT
	PK_tblSalaryLevel PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblSalaryLevel', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblSalaryLevel', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblSalaryLevel', 'Object', 'CONTROL') as Contr_Per 