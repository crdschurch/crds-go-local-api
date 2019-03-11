USE MinistryPlatform
GO

DECLARE @GoLocalRoleId int = 211

DECLARE @HouseholdPageId int = 327
UPDATE dp_Role_Pages
SET Access_Level = 1
WHERE Role_ID = @GoLocalRoleId AND Page_ID = @HouseholdPageId