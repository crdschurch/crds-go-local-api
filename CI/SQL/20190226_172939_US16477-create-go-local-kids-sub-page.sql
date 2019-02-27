USE [MinistryPlatform]
GO

DECLARE @SubPageId int = 620 --ID from Identity Maintenace db. 
DECLARE @GroupParticpantPageID int = 316

IF NOT EXISTS (SELECT 1 FROM [dbo].[dp_Sub_Pages] WHERE Sub_Page_ID = @SubPageId)
BEGIN
	SET IDENTITY_INSERT [dbo].[dp_Sub_Pages] ON
	INSERT INTO [dbo].[dp_Sub_Pages]
           ([Sub_Page_ID]
		   ,[Display_Name]
           ,[Singular_Name]
           ,[Page_ID]
           ,[View_Order]
           ,[Primary_Table]
           ,[Primary_Key]
           ,[Default_Field_List]
           ,[Selected_Record_Expression]
           ,[Filter_Key]
           ,[Relation_Type_ID]
           ,[Display_Copy])
     VALUES
           (@SubPageId
		   ,'GO Local Kids'
           ,'GO Local Kids'
           ,@GroupParticpantPageID
           ,99
           ,'cr_Go_Local_Kids'
           ,'Go_Local_Kids_ID'
           ,'Group_Participant_ID_Table_Participant_ID_Table_Contact_ID_Table.Display_Name,Two_to_Seven_Count,Eight_to_Twelve_Count'
           ,'Group_Participant_ID_Table_Participant_ID_Table_Contact_ID_Table.Display_Name'
           ,'Group_Participant_ID'
           ,1
           ,0)
	SET IDENTITY_INSERT [dbo].[dp_Sub_Pages] OFF
END