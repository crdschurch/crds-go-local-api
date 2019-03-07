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

    [Fact]
    public void ShouldGetCoLeaders()
    {
      _projectDataRepository.Setup(m => m.GetProjectList())
        .Returns(ProjectDataHelpers.MockProjects());
      _projectDataRepository.Setup(m => m.GetGroupParticipantCounts(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectVolCounts());
      _projectDataRepository.Setup(m => m.GetProjectLeaders(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectLeaders());

      var result = _fixture.GetAllProjects();

      Assert.Equal("Leader One & Leader Two", result[0].CaptainName);
      Assert.Equal("Tester McTesterson", result[1].CaptainName);
    }

    [Fact]
    public void ShouldCalculateSpotsAndVolunteers()
    {
      _projectDataRepository.Setup(m => m.GetProjectList())
        .Returns(ProjectDataHelpers.MockProjects());
      _projectDataRepository.Setup(m => m.GetGroupParticipantCounts(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectVolCounts());
      _projectDataRepository.Setup(m => m.GetProjectLeaders(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectLeaders());

      var result = _fixture.GetAllProjects();

      Assert.Equal(5, result[0].VolunteersNeeded);
      Assert.Equal(15, result[0].SpotsLeft);
    }

    [Fact]
    public void ShouldCalculateMinimumAge()
    {
      _projectDataRepository.Setup(m => m.GetProjectList())
        .Returns(ProjectDataHelpers.MockProjects());
      _projectDataRepository.Setup(m => m.GetGroupParticipantCounts(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectVolCounts());
      _projectDataRepository.Setup(m => m.GetProjectLeaders(It.IsAny<List<int>>()))
        .Returns(ProjectDataHelpers.MockProjectLeaders());

      var result = _fixture.GetAllProjects();

      Assert.Equal(18, result[0].MinimumAge);
    }
  }
}
