USE MinistryPlatform
GO

IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'cr_Group_Participants_Go_Local_Skills'))
BEGIN
	CREATE TABLE cr_Group_Participants_Go_Local_Skills (
		Group_Participants_Go_Local_Skills_ID [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		Group_Participant_ID [int] NOT NULL,
		Go_Local_Skills_ID [int] NOT NULL,
		Domain_ID [int] NOT NULL
	);
END

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Group_Participants_Go_Local_Skills_Group_Participants]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Group_Participants_Go_Local_Skills]'))
BEGIN
	ALTER TABLE [dbo].[cr_Group_Participants_Go_Local_Skills]  WITH CHECK ADD  CONSTRAINT [FK_Group_Participants_Go_Local_Skills_Group_Participants] FOREIGN KEY([Group_Participant_ID])
	REFERENCES [dbo].[Group_Participants] ([Group_Participant_ID])
END

ALTER TABLE [dbo].[cr_Group_Participants_Go_Local_Skills] CHECK CONSTRAINT [FK_Group_Participants_Go_Local_Skills_Group_Participants]
GO

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Group_Participants_Go_Local_Skills_Go_Local_Skills]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Group_Participants_Go_Local_Skills]'))
BEGIN
	ALTER TABLE [dbo].[cr_Group_Participants_Go_Local_Skills]  WITH CHECK ADD  CONSTRAINT [FK_Group_Participants_Go_Local_Skills_Go_Local_Skills] FOREIGN KEY([Go_Local_Skills_ID])
	REFERENCES [dbo].[cr_Go_Local_Skills] ([Go_Local_Skills_ID])
END

ALTER TABLE [dbo].[cr_Group_Participants_Go_Local_Skills] CHECK CONSTRAINT [FK_Group_Participants_Go_Local_Skills_Go_Local_Skills]
GO

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Group_Participants_Go_Local_Skills_Domains]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Group_Participants_Go_Local_Skills]'))
BEGIN
	ALTER TABLE [dbo].[cr_Group_Participants_Go_Local_Skills]  WITH CHECK ADD  CONSTRAINT [FK_Group_Participants_Go_Local_Skills_Domains] FOREIGN KEY([Domain_ID])
	REFERENCES [dbo].[dp_Domains] ([Domain_ID])
END

ALTER TABLE [dbo].[cr_Group_Participants_Go_Local_Skills] CHECK CONSTRAINT [FK_Group_Participants_Go_Local_Skills_Domains]
GO
