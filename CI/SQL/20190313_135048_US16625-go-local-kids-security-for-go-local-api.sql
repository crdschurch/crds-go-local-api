USE MinistryPlatform
GO

DECLARE @GoLocalKidsPageId int = 649 --Assigned by Identity Maintenance DB
IF NOT EXISTS (SELECT 1 FROM dp_Pages WHERE Page_ID = @GoLocalKidsPageId)
BEGIN
	SET IDENTITY_INSERT [dbo].[dp_Pages] ON
	INSERT INTO [dbo].[dp_Pages]
           ([Page_ID]
		   ,[Display_Name]
           ,[Singular_Name]
           ,[Description]
           ,[View_Order]
           ,[Table_Name]
           ,[Primary_Key]
           ,[Display_Search]
           ,[Default_Field_List]
           ,[Selected_Record_Expression]
           ,[Display_Copy]
           ,[Suppress_New_Button])
     VALUES
           (@GoLocalKidsPageId
		   ,'GO Local Kids'
           ,'GO Local Kids'
           ,'How many kids of each age range a person is bringing along to GO Local'
           ,99
           ,'cr_Go_Local_Kids'
           ,'Go_Local_Kids_ID'
           ,1
           ,'Group_Participant_ID, Two_to_Seven_Count, Eight_to_Twelve_Count'
           ,'Go_Local_Kids_ID'
           ,1
           ,0)
	SET IDENTITY_INSERT [dbo].[dp_Pages] OFF
END

DECLARE @GoLocalRoleId int = 211
IF NOT EXISTS (SELECT 1 FROM dp_Role_Pages WHERE Role_ID = @GoLocalRoleId AND Page_ID = @GoLocalKidsPageId)
BEGIN 
	INSERT INTO [dbo].[dp_Role_Pages]
           ([Role_ID]
           ,[Page_ID]
           ,[Access_Level])
     VALUES
           (@GoLocalRoleId
           ,@GoLocalKidsPageId
           ,1)
END