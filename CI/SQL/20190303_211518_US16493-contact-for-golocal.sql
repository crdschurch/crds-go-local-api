USE [MinistryPlatform]
GO

DECLARE @GOLocalContactID INT = 61 --Assigned by Identity Maintenace

IF NOT EXISTS(SELECT 1 FROM Contacts WHERE [Contact_ID] = @GOLocalContactID)
BEGIN
	SET IDENTITY_INSERT Contacts ON
	INSERT INTO [dbo].[Contacts]
           ([Contact_ID]
		   ,[Company]
           ,[Display_Name]
           ,[Contact_Status_ID]
           ,[Bulk_Email_Opt_Out]
           ,[Bulk_SMS_Opt_Out]
           ,[Email_Unlisted]
           ,[Mobile_Phone_Unlisted]
           ,[Do_Not_Text]
           ,[Remove_From_Directory]
           ,[Domain_ID])
     VALUES
           (@GOLocalContactID
		   ,0
           ,'CRDS GO Local'
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1
           ,1)
	SET IDENTITY_INSERT Contacts OFF
END