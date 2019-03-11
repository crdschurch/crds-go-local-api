using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Repositories.ParticipantData
{
  public class ParticipantDataRepository : IParticipantDataRepository
  {
    private readonly ITokenService _tokenService;
    private readonly IMinistryPlatformRestRequestBuilderFactory _ministryPlatformBuilder;

    public ParticipantDataRepository(ITokenService tokenService, IMinistryPlatformRestRequestBuilderFactory ministryPlatformRestRequestBuilderFactory)
    {
      _tokenService = tokenService;
      _ministryPlatformBuilder = ministryPlatformRestRequestBuilderFactory;
    }

    public int CreateParticipant(Participant participantData)
    {
      var apiToken = _tokenService.GetClientToken();
      participantData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Create<Participant>(participantData);
      return participantData.ParticipantId;
    }
  }
}
