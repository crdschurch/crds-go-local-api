USE MinistryPlatform
GO

IF NOT (EXISTS (SELECT * 
                 FROM INFORMATION_SCHEMA.TABLES 
                 WHERE TABLE_SCHEMA = 'dbo' 
                 AND  TABLE_NAME = 'cr_Go_Local_Kids'))
BEGIN
	CREATE TABLE cr_Go_Local_Kids (
		Go_Local_Kids_ID [int] IDENTITY(1,1) NOT NULL PRIMARY KEY,
		Group_Participant_ID [int] NOT NULL,
		Two_to_Seven_Count [int],
		Eight_to_Twelve_Count [int],
		Domain_ID [int] NOT NULL
	);
END

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Go_Local_Kids_Group_Participants]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Go_Local_Kids]'))
BEGIN
	ALTER TABLE [dbo].[cr_Go_Local_Kids]  WITH CHECK ADD  CONSTRAINT [FK_Go_Local_Kids_Group_Participants] FOREIGN KEY([Group_Participant_ID])
	REFERENCES [dbo].[Group_Participants] ([Group_Participant_ID])
END

ALTER TABLE [dbo].[cr_Go_Local_Kids] CHECK CONSTRAINT [FK_Go_Local_Kids_Group_Participants]
GO

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Go_Local_Kids_Domains]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Go_Local_Kids]'))
BEGIN
	ALTER TABLE [dbo].[cr_Go_Local_Kids]  WITH CHECK ADD  CONSTRAINT [FK_Go_Local_Kids_Domains] FOREIGN KEY([Domain_ID])
	REFERENCES [dbo].[dp_Domains] ([Domain_ID])
END

ALTER TABLE [dbo].[cr_Go_Local_Kids] CHECK CONSTRAINT [FK_Go_Local_Kids_Domains]
GO
