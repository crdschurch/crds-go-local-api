USE MinistryPlatform
GO

--Next ints in the sequence picked manually. Not yet used in any env.
DECLARE @closedForSignUpsStatusId INT = 3;
DECLARE @pausedStatusId INT = 4;

SET IDENTITY_INSERT cr_Project_Statuses ON

IF NOT EXISTS (SELECT * FROM cr_Project_Statuses 
			   WHERE Description = 'Closed for Signups' OR Project_Status_ID = @closedForSignUpsStatusId)
  BEGIN
   INSERT INTO cr_Project_Statuses (Project_Status_ID, Description, Domain_ID)
   VALUES (@closedForSignUpsStatusId, 'Closed for Signups', 1)
  END

IF NOT EXISTS (SELECT * FROM cr_Project_Statuses 
			   WHERE Description = 'Paused' OR Project_Status_ID = @pausedStatusId)
  BEGIN
    INSERT INTO cr_Project_Statuses (Project_Status_ID, Description, Domain_ID)
    VALUES (@pausedStatusId, 'Paused', 1);
  END

SET IDENTITY_INSERT cr_Project_Statuses Off