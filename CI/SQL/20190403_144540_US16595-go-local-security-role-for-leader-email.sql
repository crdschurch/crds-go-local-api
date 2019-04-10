USE [MinistryPlatform]
GO

DECLARE @GoLocalEmailRoleId int = 212 -- Issued by ID Maintenance db. 

IF NOT EXISTS (SELECT 1 FROM dp_Roles WHERE Role_ID = @GoLocalEmailRoleId)
BEGIN
	SET IDENTITY_INSERT [dbo].[dp_Roles] ON
	INSERT INTO [dbo].[dp_Roles]
           ([Role_ID]
		   ,[Role_Name]
           ,[Description]
           ,[Domain_ID])
     VALUES
           (@GoLocalEmailRoleId
		   ,'GO Local Email - CRDS'
           ,'This role is used to control the ability to send project leader and reminder emails for GO Local'
           ,1)
	SET IDENTITY_INSERT [dbo].[dp_Roles] OFF
END