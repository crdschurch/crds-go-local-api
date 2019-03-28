using System.Linq;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json.Linq;

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

    public int CreateEventParticipant(EventParticipant eventParticipantData)
    {
      var apiToken = _tokenService.GetClientToken();
      eventParticipantData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Create<EventParticipant>(eventParticipantData);
      return eventParticipantData.EventParticipantId;
    }

    public int CreateGroupParticipant(GroupParticipant groupParticipantData)
    {
      var apiToken = _tokenService.GetClientToken();
      groupParticipantData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Create<GroupParticipant>(groupParticipantData);
      return groupParticipantData.GroupParticipantId;
    }

    public int CreateGoLocalKids(GoLocalKids kidsData)
    {
      var apiToken = _tokenService.GetClientToken();
      kidsData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Create<GoLocalKids>(kidsData);
      return kidsData.GoLocalKidsId;
    }

    public int GetParticipantId(int contactId)
    {
      var apiToken = _tokenService.GetClientToken();
      var participant = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .AddSelectColumn("Participant_Record")
        .Build()
        .Get<JObject>("Contacts", contactId);
      return participant["Participant_Record"].ToObject<int>();
    }
  }
}
