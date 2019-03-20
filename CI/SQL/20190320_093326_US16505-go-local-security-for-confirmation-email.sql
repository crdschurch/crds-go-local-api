USE MinistryPlatform
GO 

DECLARE @GoLocalRoleId int = 211
DECLARE @GroupPageId int = 322

IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @GroupPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@GroupPageId
           ,1)
END