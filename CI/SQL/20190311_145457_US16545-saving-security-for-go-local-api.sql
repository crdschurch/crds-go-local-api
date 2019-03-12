USE MinistryPlatform
GO

DECLARE @GoLocalRoleId int = 211

DECLARE @HouseholdPageId int = 327
UPDATE dp_Role_Pages
SET Access_Level = 1
WHERE Role_ID = @GoLocalRoleId AND Page_ID = @HouseholdPageId

DECLARE @ContactsPageId int = 292
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @ContactsPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@ContactsPageId
           ,1)
END

DECLARE @ParticipantsPageId int = 355
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @ParticipantsPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@ParticipantsPageId
           ,1)
END

DECLARE @GroupParticipantsPageId int = 316
UPDATE dp_Role_Pages
SET Access_Level = 1
WHERE Role_ID = @GoLocalRoleId AND Page_ID = @GroupParticipantsPageId

DECLARE @EventParticipantsPageId int = 305;
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @EventParticipantsPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@EventParticipantsPageId
           ,1)
END