USE [MinistryPlatform]
GO

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[cr_Organizations]') AND name = 'Address_ID')
BEGIN 
	ALTER TABLE [dbo].[cr_Organizations]
	ADD Address_ID [int]
END

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Organizations_Addresses]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Organizations]'))
BEGIN
	ALTER TABLE [dbo].[cr_Organizations]  WITH CHECK ADD  CONSTRAINT [FK_Organizations_Addresses] FOREIGN KEY([Address_ID])
	REFERENCES [dbo].[Addresses] ([Address_ID])
END

ALTER TABLE [dbo].[cr_Organizations] CHECK CONSTRAINT [FK_Organizations_Addresses]
GO
