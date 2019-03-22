using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.ProjectData
{
  public interface IProjectDataRepository
  {
    List<MpProject> GetProjectList();
    List<GroupCount> GetGroupParticipantCounts(List<int> groupIds);
    List<ProjectLeaders> GetProjectLeaders(List<int> groupIds);
    MpProject GetProject(int projectId);
  }
}