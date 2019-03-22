using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Project
{
  public interface IProjectService
  {
    List<ProjectDTO> GetAllProjects();
  }
}
