using System.Collections.Generic;
using System.Linq;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.ProjectData;

namespace CrdsGoLocalApi.Services.Project
{
  public class ProjectService : IProjectService
  {
    private readonly IProjectDataRepository _projectDataRepository;

    public ProjectService(IProjectDataRepository projectData)
    {
      _projectDataRepository = projectData;
    }

    public List<ProjectDTO> GetAllProjects()
    {
      var projects = _projectDataRepository.GetProjectList();
      var groupIds = projects.Select(p => p.GroupId.GetValueOrDefault()).ToList();
      var volunteerCounts = _projectDataRepository.GetGroupParticipantCounts(groupIds);
      var projectLeaders = _projectDataRepository.GetProjectLeaders(groupIds);

      var projectList = projects.Select(p => new ProjectDTO
      {
        Id = p.ProjectId,
        OrganizationName = p.OrgName,
        ProjectName = p.ProjectName,
        MinimumAge = (p.ProjectTypeMinAge >= (p.ProjectAgeException ?? 0)) ? p.ProjectTypeMinAge : p.ProjectAgeException.Value,
        Site = p.CrdsSite,
        ProjectTypeName = p.ProjectType,
        VolunteersNeeded = p.MinVols - (volunteerCounts.FirstOrDefault(v => v.GroupId == p.GroupId)?.ParticipantCount ?? 0),
        SpotsLeft = p.MaxVols - (volunteerCounts.FirstOrDefault(v => v.GroupId == p.GroupId)?.ParticipantCount ?? 0),
        CaptainName = string.Join(" & ",projectLeaders.Where(l => l.GroupId == p.GroupId).Select(l => l.GroupLeader)),
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
