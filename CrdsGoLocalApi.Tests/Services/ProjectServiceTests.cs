using System;
using System.Collections.Generic;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Project;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;
using Moq;
using Xunit;

namespace CrdsGoLocalApi.Tests.Services
{
  public class ProjectServiceTests: IDisposable
  {
    private readonly Mock<ITokenService> _tokenService;
    private readonly Mock<IMinistryPlatformRestRequestBuilderFactory> _mpRequestBuilder;
    private readonly Mock<IMinistryPlatformRestRequestBuilder> _restRequest;
    private readonly Mock<IMinistryPlatformRestRequest> _request;
    private readonly ProjectService _fixture;
    private readonly string apiToken = "myValidToken";

    public ProjectServiceTests()
    {
      _tokenService = new Mock<ITokenService>();
      _mpRequestBuilder = new Mock<IMinistryPlatformRestRequestBuilderFactory>();
      _restRequest = new Mock<IMinistryPlatformRestRequestBuilder>();
      _request = new Mock<IMinistryPlatformRestRequest>();
      _fixture = new ProjectService(_tokenService.Object, _mpRequestBuilder.Object);
    }

    public void Dispose()
    {
      _tokenService.VerifyAll();
      _mpRequestBuilder.VerifyAll();
      _restRequest.VerifyAll();
      _request.VerifyAll();
    }

    [Fact]
    public void ShouldGetProjects()
    {
      _tokenService.Setup(t => t.GetClientToken()).Returns(apiToken);
      _mpRequestBuilder.Setup(m => m.NewRequestBuilder()).Returns(_restRequest.Object);
      _restRequest.Setup(r => r.WithAuthenticationToken(apiToken)).Returns(_restRequest.Object);
      _restRequest.Setup(r => r.Build()).Returns(_request.Object);
      _request.Setup(r => r.Search<MpProject>()).Returns(MockProjects());

      var result = _fixture.GetAllProjects();

      Assert.IsType<List<ProjectDTO>>(result);
      Assert.Equal(2, result.Count);
    }

    private List<MpProject> MockProjects()
    {
      return new List<MpProject>
      {
        new MpProject
        {
          ProjectId = 1
        },
        new MpProject
        {
          ProjectId = 2
        }

      };
    }
  }
}
