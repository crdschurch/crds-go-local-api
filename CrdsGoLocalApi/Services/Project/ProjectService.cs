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
        .Build()
        .Search<MpProject>();
      var projectList = projects.Select(p => new ProjectDTO {
        Id = p.ProjectId,
        ProjectName = p.ProjectName,
        ProjectDescription = p.ProjectDescription
      }).ToList();
      return projectList;
    }
  }
}
