﻿using System;
using System.Collections.Generic;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Repositories.ProjectData
{
  public class ProjectDataRepository : IProjectDataRepository
  {
    private readonly ITokenService _tokenService;
    private readonly IMinistryPlatformRestRequestBuilderFactory _ministryPlatformBuilder;

    public ProjectDataRepository(ITokenService tokenService, IMinistryPlatformRestRequestBuilderFactory ministryPlatformRestRequestBuilderFactory)
    {
      _tokenService = tokenService;
      _ministryPlatformBuilder = ministryPlatformRestRequestBuilderFactory;
    }

    public List<MpProject> GetProjectList()
    {
      var apiToken = _tokenService.GetClientToken();
      var now = DateTime.Now;
      var projects = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .AddSelectColumn("Project_ID")
        .AddSelectColumn("Project_Name")
        .AddSelectColumn("Project_Description")
        .AddSelectColumn("Project_Status_ID_Table.Project_Status_ID")
        .AddSelectColumn("Organization_ID_Table.Name AS Organization_Name")
        .AddSelectColumn("Project_Type_ID_Table.Description AS Project_Type_Description")
        .AddSelectColumn("Project_Type_ID_Table.Minimum_Age AS Project_Type_Min_Age")
        .AddSelectColumn("Minimum_Age_Exception")
        .AddSelectColumn("Location_ID_Table.Location_Name")
        .AddSelectColumn("Minimum_Volunteers")
        .AddSelectColumn("Maximum_Volunteers")
        .AddSelectColumn("Address_ID_Table.Address_Line_1")
        .AddSelectColumn("Address_ID_Table.Address_Line_2")
        .AddSelectColumn("Address_ID_Table.City AS Address_City")
        .AddSelectColumn("Address_ID_Table.[State/Region] AS Address_State")
        .AddSelectColumn("Address_ID_Table.Postal_Code AS Address_Zip")
        .AddSelectColumn("Address_ID_Table.Latitude AS Address_Lat")
        .AddSelectColumn("Address_ID_Table.Longitude AS Address_Long")
        .AddSelectColumn("cr_Projects.Start_Date")
        .AddSelectColumn("cr_Projects.End_Date")
        .AddSelectColumn("Group_ID")
        .RestrictResultCount(0)
        .WithFilter($"Initiative_ID_Table.Volunteer_Signup_Start_Date <= '{now}' AND Initiative_ID_Table.Volunteer_Signup_End_Date >= '{now}' AND cr_Projects.Project_Status_ID <> 2")
        .Build()
        .Search<MpProject>("cr_Projects");
      return projects;
    }

    public List<GroupCount> GetGroupParticipantCounts(List<int> groupIds)
    {
      var apiToken = _tokenService.GetClientToken();
      var idList = string.Join(", ", groupIds);
      var gpCounts = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .GroupBy("Group_ID")
        .AddSelectColumn("Group_ID")
        .AddSelectColumn("COUNT(*) AS Participant_Count")
        .WithFilter($"Group_ID IN ({idList})")
        .RestrictResultCount(0)
        .Build()
        .SearchViaPost<GroupCount>("Group_Participants");
      return gpCounts;
    }

    public List<ProjectLeaders> GetProjectLeaders(List<int> groupIds)
    {
      var apiToken = _tokenService.GetClientToken();
      var idList = string.Join(", ", groupIds);
      var leaders = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .AddSelectColumn("Group_ID")
        .AddSelectColumn("Participant_ID_Table_Contact_ID_Table.Nickname + ' ' + Participant_ID_Table_Contact_ID_Table.Last_Name AS 'Leader_Name'")
        .WithFilter($"Group_ID IN ({idList}) AND Group_Role_ID_Table.[Group_Role_ID] = 22")
        .RestrictResultCount(0)
        .Build()
        .SearchViaPost<ProjectLeaders>("Group_Participants");
      return leaders;
    }
  }
}