USE [MinistryPlatform]
GO

DECLARE @GoLocalLeadRole int = 133
DECLARE @SystemAdminRole int = 107
DECLARE @GoLoalKidsSubPage int = 620

IF NOT EXISTS(SELECT 1 FROM dp_Role_Sub_Pages WHERE Role_ID = @GoLocalLeadRole and Sub_Page_ID = @GoLoalKidsSubPage)
BEGIN
	INSERT INTO [dbo].[dp_Role_Sub_Pages]
           ([Role_ID]
           ,[Sub_Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalLeadRole
           ,@GoLoalKidsSubPage
           ,1)
END

IF NOT EXISTS(SELECT 1 FROM dp_Role_Sub_Pages WHERE Role_ID = @SystemAdminRole and Sub_Page_ID = @GoLoalKidsSubPage)
BEGIN
	INSERT INTO [dbo].[dp_Role_Sub_Pages]
           ([Role_ID]
           ,[Sub_Page_ID]
           ,[Access_Level])
     VALUES
           (@SystemAdminRole
           ,@GoLoalKidsSubPage
           ,1)
END

