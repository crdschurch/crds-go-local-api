using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Repositories.GroupData
{
  public class GroupDataRepository : IGroupDataRepository
  {
    private readonly ITokenService _tokenService;
    private readonly IMinistryPlatformRestRequestBuilderFactory _ministryPlatformBuilder;

    public GroupDataRepository(ITokenService tokenService, IMinistryPlatformRestRequestBuilderFactory ministryPlatformRestRequestBuilderFactory)
    {
      _tokenService = tokenService;
      _ministryPlatformBuilder = ministryPlatformRestRequestBuilderFactory;
    }

    public Group GetGroup(int groupId)
    {
      var apiToken = _tokenService.GetClientToken();
      var group = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Get<Group>(groupId);
      return group;
    }
  }
}
