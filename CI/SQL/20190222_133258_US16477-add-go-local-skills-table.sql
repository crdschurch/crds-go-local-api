USE MinistryPlatform
GO

IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'cr_Go_Local_Skills'))
BEGIN
	CREATE TABLE cr_Go_Local_Skills (
		Go_Local_Skills_ID [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		Skill_Description nvarchar(150),
		Domain_ID [int] NOT NULL
	);
END

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Go_Local_Skills_Domains]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Go_Local_Skills]'))
BEGIN
	ALTER TABLE [dbo].[cr_Go_Local_Skills]  WITH CHECK ADD  CONSTRAINT [FK_Go_Local_Skills_Domains] FOREIGN KEY([Domain_ID])
	REFERENCES [dbo].[dp_Domains] ([Domain_ID])
END

ALTER TABLE [dbo].[cr_Go_Local_Skills] CHECK CONSTRAINT [FK_Go_Local_Skills_Domains]
GO
