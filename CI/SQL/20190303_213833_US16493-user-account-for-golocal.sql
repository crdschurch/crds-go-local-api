USE [MinistryPlatform]
GO

DECLARE @GOLocalUserID INT = 1005 --Assigned by Identity Maintenace
DECLARE @GOLocalContactID INT = 61 --Assigned by Identity Maintenace

IF NOT EXISTS(SELECT 1 FROM dp_Users WHERE [User_ID] = @GOLocalUserID)
BEGIN
	SET IDENTITY_INSERT dp_Users ON
	INSERT INTO [dbo].[dp_Users]
           ([User_ID]
		   ,[User_Name]
           ,[User_Email]
           ,[Admin]
           ,[Domain_ID]
           ,[Publications_Manager]
           ,[Contact_ID]
           ,[Can_Impersonate]
           ,[Keep_For_Go_Live]
           ,[Setup_Admin]
           ,[Read_Permitted]
           ,[Create_Permitted]
           ,[Update_Permitted]
           ,[Delete_Permitted]
           ,[Login_Attempts])
     VALUES
           (@GOLocalUserID
		   ,'CRDS GO Local'
           ,'webteam+crds_golocal@crossroads.net'
           ,0
           ,1
           ,0
           ,@GOLocalContactID
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0
           ,0)
	SET IDENTITY_INSERT dp_Users OFF
END


