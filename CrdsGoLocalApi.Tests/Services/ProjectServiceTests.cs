using System;
using System.Collections.Generic;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.ProjectData;
using CrdsGoLocalApi.Services.Project;
using CrdsGoLocalApi.Tests.Helpers;
using Moq;
using Xunit;

namespace CrdsGoLocalApi.Tests.Services
{
  public class ProjectServiceTests: IDisposable
  {
    private readonly Mock<IProjectDataRepository> _projectDataRepository;
    private readonly ProjectService _fixture;

    public ProjectServiceTests()
    {
      _projectDataRepository = new Mock<IProjectDataRepository>();
      _fixture = new ProjectService(_projectDataRepository.Object);
    }

    public void Dispose()
    {
      _projectDataRepository.VerifyAll();
    }

    [Fact]
    public void ShouldGetProjects()
    {
      _projectDataRepository.Setup(m => m.GetProjectList())
        .Returns(ProjectDataHelpers.MockProjects());
      _projectDataRepository.Setup(m => m.GetGroupParticipantCounts(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectVolCounts());
      _projectDataRepository.Setup(m => m.GetProjectLeaders(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectLeaders());

      var result = _fixture.GetAllProjects();

      Assert.IsType<List<ProjectDTO>>(result);
      Assert.Equal(2, result.Count);
    }
  }
}
