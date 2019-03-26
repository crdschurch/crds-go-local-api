USE MinistryPlatform
GO

IF NOT EXISTS (SELECT * FROM cr_Project_Statuses WHERE Description = 'Closed for Signups')
  BEGIN
   INSERT INTO cr_Project_Statuses (Description, Domain_ID)
   VALUES ('Closed for Signups', 1)
  END

IF NOT EXISTS (SELECT * FROM cr_Project_Statuses WHERE Description = 'Paused')
  BEGIN
    INSERT INTO cr_Project_Statuses (Description, Domain_ID)
    VALUES ('Paused', 1);
  END