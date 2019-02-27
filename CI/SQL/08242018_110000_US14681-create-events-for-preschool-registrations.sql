USE MinistryPlatform
GO

DECLARE @2_DAY_EVENT_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 2 Days Per Week';
DECLARE @3_DAY_EVENT_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 3 Days Per Week';
DECLARE @5_DAY_EVENT_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 5 Days Per Week';
DECLARE @2_DAY_EVENT_LATE_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 2 Days Per Week Plus Late Fee';
DECLARE @3_DAY_EVENT_LATE_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 3 Days Per Week Plus Late Fee';
DECLARE @5_DAY_EVENT_LATE_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 5 Days Per Week Plus Late Fee';
DECLARE @2_DAY_EVENT_PAID_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 2 Days Per Week - Paid In Full';
DECLARE @3_DAY_EVENT_PAID_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 3 Days Per Week - Paid In Full';
DECLARE @5_DAY_EVENT_PAID_TITLE NVARCHAR(100) = 'Preschool 2018-2019 Payors - Preschool 5 Days Per Week - Paid In Full';

DECLARE @2_DAY_EVENT_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschooltwodaysperweek');
DECLARE @3_DAY_EVENT_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschoolthreedaysperweek');
DECLARE @5_DAY_EVENT_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschoolfivedaysperweek');
DECLARE @2_DAY_EVENT_LATE_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschooltwodaysperweeklate');
DECLARE @3_DAY_EVENT_LATE_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschoolthreedaysperweeklate');
DECLARE @5_DAY_EVENT_LATE_REGISTRATION_FORM_ID INT =  (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschoolfivedaysperweeklate');
DECLARE @2_DAY_EVENT_PAID_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschooltwodaysperweekfull');
DECLARE @3_DAY_EVENT_PAID_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschoolthreedaysperweekfull');
DECLARE @5_DAY_EVENT_PAID_REGISTRATION_FORM_ID INT = (SELECT Form_ID FROM Forms WHERE Form_Title = 'preschoolfivedaysperweekfull');

DECLARE @KIDS_CLUB_EVENT_TYPE_ID INT = (SELECT Event_Type_ID FROM Event_Types WHERE Event_Type = 'Kids Club');
DECLARE @ANDOVER_CONGREGATION_ID INT = (SELECT Congregation_ID FROM Congregations WHERE Congregation_Name = 'Andover');
DECLARE @KIDS_CLUB_PROGRAM_ID INT = (SELECT Program_ID FROM Programs WHERE Program_Name = 'Kids Club');
DECLARE @SOMMER_ANDERSON_CONTACT_ID INT = (SELECT Contact_ID FROM Contacts WHERE Email_Address = 'sommer.anderson@crossroads.net');
DECLARE @EVENT_START_DATE DATETIME = CAST('20180822 08:00:00.000' as DATETIME);
DECLARE @EVENT_END_DATE DATETIME = CAST('20190418 13:00:00.000' as DATETIME);
DECLARE @EVENT_REGISTRATION_START_DATE DATETIME = CAST('20180821 00:00:00.000' as DATETIME);
DECLARE @EVENT_REGISTRATION_END_DATE DATETIME = CAST('20190531 23:59:59.000' as DATETIME);
DECLARE @PUBLIC_VISIBILITY_LEVEL_ID INT = (SELECT Visibility_Level_ID FROM Visibility_Levels WHERE Visibility_Level = '4 - Public');
DECLARE @REGISTRATION_IS_ACTIVE_BOOL INT = 1;

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @2_DAY_EVENT_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@2_DAY_EVENT_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@2_DAY_EVENT_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @3_DAY_EVENT_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@3_DAY_EVENT_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@3_DAY_EVENT_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @5_DAY_EVENT_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@5_DAY_EVENT_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@5_DAY_EVENT_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @2_DAY_EVENT_LATE_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@2_DAY_EVENT_LATE_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@2_DAY_EVENT_LATE_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @3_DAY_EVENT_LATE_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@3_DAY_EVENT_LATE_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@3_DAY_EVENT_LATE_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @5_DAY_EVENT_LATE_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@5_DAY_EVENT_LATE_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@5_DAY_EVENT_LATE_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @2_DAY_EVENT_PAID_TITLE )
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@2_DAY_EVENT_PAID_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@2_DAY_EVENT_PAID_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @3_DAY_EVENT_PAID_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@3_DAY_EVENT_PAID_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@3_DAY_EVENT_PAID_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END

IF NOT EXISTS(SELECT * FROM Events WHERE Event_Title = @5_DAY_EVENT_PAID_TITLE)
BEGIN  
  INSERT INTO [Events](
	[Event_Title],
	[Event_Type_ID],
	[Congregation_ID],[Location_ID],[Meeting_Instructions],[Description],
	[Program_ID],
	[Primary_Contact],[Participants_Expected],[Minutes_for_Setup],
	[Event_Start_Date],
	[Event_End_Date],[Minutes_for_Cleanup],[Cancelled],[_Approved],[Public_Website_Settings],
	[Visibility_Level_ID],[Featured_On_Calendar],[Online_Registration_Product],
	[Registration_Form],
	[Registration_Start],
	[Registration_End],
	[Registration_Active],[Register_Into_Series],[External_Registration_URL],[_Web_Approved],[Check-in_Information],[Allow_Check-in],[Ignore_Program_Groups],[Prohibit_Guests],[Early_Check-in_Period],[Late_Check-in_Period],[Notification_Settings],[Registrant_Message],[Days_Out_to_Remind],[Optional_Reminder_Message],[Participant_Reminder_Settings],[Send_Reminder],[Reminder_Sent],[Reminder_Days_Prior_ID],[Other_Event_Information],[Parent_Event_ID],[Priority_ID],[Domain_ID],
	[On_Connection_Card],[Accounting_Information],[On_Donation_Batch_Tool],[Project_Code], [__ExternalTripID],[__ExternalTripLegID],[__ExternalEventID],[__ExternalOrganizerUserID],[__ExternalGroupID],[__ExternalRoomID],[__ExternalContactUserID])
  VALUES(
	@5_DAY_EVENT_PAID_TITLE,
	@KIDS_CLUB_EVENT_TYPE_ID,
	@ANDOVER_CONGREGATION_ID,NULL,NULL,NULL,
	@KIDS_CLUB_PROGRAM_ID,
	@SOMMER_ANDERSON_CONTACT_ID,NULL,0,
	@EVENT_START_DATE,
	@EVENT_END_DATE,0,0,1,NULL,
	@PUBLIC_VISIBILITY_LEVEL_ID,0,NULL,
	@5_DAY_EVENT_PAID_REGISTRATION_FORM_ID,
	@EVENT_REGISTRATION_START_DATE,
	@EVENT_REGISTRATION_END_DATE,
	@REGISTRATION_IS_ACTIVE_BOOL,0,NULL,1,NULL,0,0,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,0,2,NULL,NULL,NULL,1,
	0,NULL,0,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL)   		 
END
