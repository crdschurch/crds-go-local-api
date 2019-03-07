USE [MinistryPlatform]
GO

DECLARE @GoLocalRoleId int = 211 -- Issued by ID Maintenance db. 

IF NOT EXISTS (SELECT 1 FROM dp_Roles WHERE Role_ID = @GoLocalRoleId)
BEGIN
	SET IDENTITY_INSERT [dbo].[dp_Roles] ON
	INSERT INTO [dbo].[dp_Roles]
           ([Role_ID]
		   ,[Role_Name]
           ,[Description]
           ,[Domain_ID])
     VALUES
           (@GoLocalRoleId
		   ,'GO Local API - CRDS'
           ,'This role is used by the Go Local API. This is not intended for human consumption.'
           ,1)
	SET IDENTITY_INSERT [dbo].[dp_Roles] OFF
END

DECLARE @ProjectPageId int = 14
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @ProjectPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@ProjectPageId
           ,0)
END

DECLARE @ProjectTypePageId int = 12
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @ProjectTypePageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@ProjectTypePageId
           ,0)
END

DECLARE @OrganizationPageId int = 10
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @OrganizationPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@OrganizationPageId
           ,0)
END

DECLARE @LocationsPageId int = 337
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @LocationsPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@LocationsPageId
           ,0)
END

DECLARE @AddressPageId int = 271
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @AddressPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@AddressPageId
           ,0)
END

DECLARE @InitiativePageId int = 327
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @InitiativePageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@InitiativePageId
           ,0)
END

DECLARE @GroupParticipantsPageId int = 316
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @GroupParticipantsPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@GroupParticipantsPageId
           ,0)
END

DECLARE @GoLocalUserId int = 1005
IF NOT EXISTS (SELECT 1 FROM dp_User_Roles WHERE Role_ID = @GoLocalRoleId AND User_ID = @GoLocalUserId)
BEGIN
	INSERT INTO [dbo].[dp_User_Roles]
           ([User_ID]
           ,[Role_ID]
           ,[Domain_ID])
     VALUES
           (@GoLocalUserId
           ,@GoLocalRoleId
           ,1)
END