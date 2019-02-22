USE MinistryPlatform
GO

IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'cr_Go_Local_Equipment'))
BEGIN
	CREATE TABLE cr_Go_Local_Equipment (
		Go_Local_Kids_ID [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		Group_Participant_ID [int] NOT NULL,
		Equipment_Description nvarchar(150) NOT NULL,
		Domain_ID [int] NOT NULL
	);
END

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Go_Local_Equipment_Group_Participants]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Go_Local_Equipment]'))
BEGIN
	ALTER TABLE [dbo].[cr_Go_Local_Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Go_Local_Equipment_Group_Participants] FOREIGN KEY([Group_Participant_ID])
	REFERENCES [dbo].[Group_Participants] ([Group_Participant_ID])
END

ALTER TABLE [dbo].[cr_Go_Local_Equipment] CHECK CONSTRAINT [FK_Go_Local_Equipment_Group_Participants]
GO

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Go_Local_Equipment_Domains]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Go_Local_Equipment]'))
BEGIN
	ALTER TABLE [dbo].[cr_Go_Local_Equipment]  WITH CHECK ADD  CONSTRAINT [FK_Go_Local_Equipment_Domains] FOREIGN KEY([Domain_ID])
	REFERENCES [dbo].[dp_Domains] ([Domain_ID])
END

ALTER TABLE [dbo].[cr_Go_Local_Equipment] CHECK CONSTRAINT [FK_Go_Local_Equipment_Domains]
GO
