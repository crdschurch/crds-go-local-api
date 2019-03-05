using System.Collections.Generic;
using System.Linq;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Services.Project
{
  public class ProjectService : IProjectService
  {
    private readonly ITokenService _tokenService;
    private readonly IMinistryPlatformRestRequestBuilderFactory _ministryPlatformBuilder;

    public ProjectService(ITokenService tokenService, IMinistryPlatformRestRequestBuilderFactory ministryPlatformRestRequestBuilderFactory)
    {
      _tokenService = tokenService;
      _ministryPlatformBuilder = ministryPlatformRestRequestBuilderFactory;
    }

    public List<ProjectDTO> GetAllProjects()
    {
      var apiToken = _tokenService.GetClientToken();
      var projects = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .AddSelectColumn("Project_ID")
        .AddSelectColumn("Project_Name")
        .AddSelectColumn("Project_Description")
        .AddSelectColumn("Project_Status_ID_Table.Project_Status_ID")
        .AddSelectColumn("Organization_ID_Table.Name AS Organization_NAme")
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
        .RestrictResultCount(0)
        .Build()
        .Search<MpProject>("cr_Projects");
      var projectList = projects.Select(p => new ProjectDTO {
        Id = p.ProjectId,
        OrganizationName = p.OrgName,
        ProjectName = p.ProjectName,
        MinimumAge = (p.ProjectTypeMinAge >= (p.ProjectAgeException ?? 0)) ? p.ProjectTypeMinAge : p.ProjectAgeException.Value,
        Site = p.CrdsSite,
        ProjectTypeName = p.ProjectType,
        VolunteersNeeded = 0,
        CaptainName = "America",
        MinVols = p.MinVols,
        MaxVols = p.MaxVols,
        Address = $"{p.Address1} {p.Address2} {p.AddressCity}, {p.AddressState} {p.AddressZip}",
        Latitude = p.AddressLat.GetValueOrDefault(),
        Longitude = p.AddressLong.GetValueOrDefault(),
        StartDate = p.StartDate.GetValueOrDefault(),
        EndDate = p.EndDate.GetValueOrDefault(),
        ProjectDescription = p.ProjectDescription,
        ProjectStatusId = p.ProjectStatusId
      }).ToList();
      return projectList;
    }
  }
}
