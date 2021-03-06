/*
   6 กุมภาพันธ์ 255721:35:11
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
CREATE TABLE dbo.tblSalaryLevel
	(
	ID int NOT NULL,
	SalaryLevel decimal(19, 2) NULL,
	Salary decimal(19, 2) NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.tblSalaryLevel ADD CONSTRAINT
	PK_tblSalaryLevel PRIMARY KEY CLUSTERED 
	(
	ID
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO
ALTER TABLE dbo.tblSalaryLevel SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.tblSalaryLevel', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.tblSalaryLevel', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.tblSalaryLevel', 'Object', 'CONTROL') as Contr_Per 