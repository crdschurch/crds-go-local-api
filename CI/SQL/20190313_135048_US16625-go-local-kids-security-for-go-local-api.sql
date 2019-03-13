USE MinistryPlatform
GO

DECLARE @GoLocalRoleId int = 211
DECLARE @GoLocalKidsSubPageId int = 620
IF NOT EXISTS (SELECT 1 FROM dp_Role_Sub_Pages WHERE Role_ID = @GoLocalRoleId AND Sub_Page_ID = @GoLocalKidsSubPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Sub_Pages]
           ([Role_ID]
           ,[Sub_Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@GoLocalKidsSubPageId
           ,1)
END