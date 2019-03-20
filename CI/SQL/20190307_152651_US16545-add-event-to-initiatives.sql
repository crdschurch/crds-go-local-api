USE [MinistryPlatform]
GO

IF NOT EXISTS (SELECT * FROM   sys.columns WHERE  object_id = OBJECT_ID(N'[dbo].[cr_Initiatives]') AND name = 'Event_ID')
BEGIN 
	ALTER TABLE [dbo].[cr_Initiatives]
	ADD Event_ID [int]
END

IF NOT EXISTS (SELECT * 
           FROM sys.foreign_keys 
           WHERE object_id = OBJECT_ID(N'[dbo].[FK_Initiatives_Events]') 
             AND parent_object_id = OBJECT_ID(N'[dbo].[cr_Initiatives]'))
BEGIN
	ALTER TABLE [dbo].[cr_Initiatives]  WITH CHECK ADD  CONSTRAINT [FK_Initiatives_Events] FOREIGN KEY([Event_ID])
	REFERENCES [dbo].[Events] ([Event_ID])
END

ALTER TABLE [dbo].[cr_Initiatives] CHECK CONSTRAINT [FK_Initiatives_Events]
GO
