USE [MinistryPlatform]
GO

--SELECT * INTO temp_cr_Projects
--FROM cr_Projects

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Project_Types]
GO

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Project_Statuses]
GO

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Organizations]
GO

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Locations]
GO

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Initiatives]
GO

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Domains]
GO

ALTER TABLE [dbo].[cr_Projects] DROP CONSTRAINT [FK_Projects_Addresses]
GO

ALTER TABLE [dbo].[cr_Group_Connectors] DROP CONSTRAINT [FK_GroupConnector_Project]
GO

/****** Object:  Table [dbo].[cr_Projects]    Script Date: 2/25/2019 12:33:58 PM ******/
DROP TABLE [dbo].[cr_Projects]
GO

/****** Object:  Table [dbo].[cr_Projects]    Script Date: 2/25/2019 12:33:58 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[cr_Projects](
	[Project_ID] [int] IDENTITY(1,1) NOT NULL,
	[Initiative_ID] [int] NOT NULL,
	[Project_Status_ID] [int] NOT NULL,
	[Location_ID] [int] NOT NULL,
	[Organization_ID] [int] NOT NULL,
	[Project_Name] [nvarchar](100) NOT NULL,
	[Address_ID] [int] NULL,
	[Project_Type_ID] [int] NOT NULL,
	[Project_Description] [nvarchar](500) NULL,
	[Start_Date] [datetime] NULL,
	[End_Date] [datetime] NULL,
	[_Volunteer_Count]  AS ([dbo].[crds_GoVolunteerProjectMemberCount]([Project_ID])),
	[Minimum_Volunteers] [int] NOT NULL,
	[Maximum_Volunteers] [int] NOT NULL,
	[Minimum_Age_Exception] [int] NULL,
	[Project_Parking_Location] [nvarchar](500) NULL,
	[Note_To_Volunteers_1] [nvarchar](500) NULL,
	[Note_To_Volunteers_2] [nvarchar](500) NULL,
	[Group_ID] [int] NULL,
	[Domain_ID] [int] NOT NULL

 CONSTRAINT [PK_Projects] PRIMARY KEY CLUSTERED 
(
	[Project_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Addresses] FOREIGN KEY([Address_ID])
REFERENCES [dbo].[Addresses] ([Address_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Addresses]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Domains] FOREIGN KEY([Domain_ID])
REFERENCES [dbo].[dp_Domains] ([Domain_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Domains]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Initiatives] FOREIGN KEY([Initiative_ID])
REFERENCES [dbo].[cr_Initiatives] ([Initiative_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Initiatives]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Locations] FOREIGN KEY([Location_ID])
REFERENCES [dbo].[Locations] ([Location_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Locations]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Organizations] FOREIGN KEY([Organization_ID])
REFERENCES [dbo].[cr_Organizations] ([Organization_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Organizations]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Project_Statuses] FOREIGN KEY([Project_Status_ID])
REFERENCES [dbo].[cr_Project_Statuses] ([Project_Status_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Project_Statuses]
GO

ALTER TABLE [dbo].[cr_Projects]  WITH CHECK ADD  CONSTRAINT [FK_Projects_Project_Types] FOREIGN KEY([Project_Type_ID])
REFERENCES [dbo].[cr_Project_Types] ([Project_Type_ID])
GO

ALTER TABLE [dbo].[cr_Projects] CHECK CONSTRAINT [FK_Projects_Project_Types]
GO

SET IDENTITY_INSERT cr_Projects ON
INSERT INTO cr_Projects ([Project_ID],
	[Project_Name],
	[Project_Status_ID],
	[Location_ID],
	[Project_Type_ID],
	[Organization_ID],
	[Initiative_ID],
	[Minimum_Volunteers],
	[Maximum_Volunteers],
	[Domain_ID],
	[Note_To_Volunteers_1],
	[Note_To_Volunteers_2],
	[Project_Parking_Location],
	[Address_ID])
SELECT [Project_ID],
	[Project_Name],
	[Project_Status_ID],
	[Location_ID],
	[Project_Type_ID],
	[Organization_ID],
	[Initiative_ID],
	[Minimum_Volunteers],
	[Maximum_Volunteers],
	[Domain_ID],
	[Note_To_Volunteers_1],
	[Note_To_Volunteers_2],
	[Project_Parking_Location],
	[Address_ID]
FROM temp_cr_Projects
SET IDENTITY_INSERT cr_Projects OFF
GO

ALTER TABLE [dbo].[cr_Group_Connectors]  WITH CHECK ADD  CONSTRAINT [FK_GroupConnector_Project] FOREIGN KEY([Project_ID])
REFERENCES [dbo].[cr_Projects] ([Project_ID])
GO

ALTER TABLE [dbo].[cr_Group_Connectors] CHECK CONSTRAINT [FK_GroupConnector_Project]
GO

--DROP TABLE [dbo].[temp_cr_Projects]
--GO
