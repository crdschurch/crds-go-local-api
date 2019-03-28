using System.Collections.Generic;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json.Linq;

namespace CrdsGoLocalApi.Repositories.HouseholdData
{
  public class HouseholdDataRepository : IHouseholdDataRepository
  {
    private readonly ITokenService _tokenService;
    private readonly IMinistryPlatformRestRequestBuilderFactory _ministryPlatformBuilder;

    public HouseholdDataRepository(ITokenService tokenService, IMinistryPlatformRestRequestBuilderFactory ministryPlatformRestRequestBuilderFactory)
    {
      _tokenService = tokenService;
      _ministryPlatformBuilder = ministryPlatformRestRequestBuilderFactory;
    }

    public int CreateHousehold(Household householdData)
    {
      var apiToken = _tokenService.GetClientToken();
      householdData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Create<Household>(householdData);
      return householdData.HouseholdId;
    }

    public int GetHouseholdId(int contactId)
    {
      var apiToken = _tokenService.GetClientToken();
      var household = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .AddSelectColumn("Household_ID")
        .Build()
        .Get<JObject>("Contacts", contactId);
      return household["Household_ID"].ToObject<int>();
    }


    public List<HouseholdMembers> GetHouseholdMembers(int householdId)
    {
      var apiToken = _tokenService.GetClientToken();
      var householdMembers = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .WithFilter($"Household_ID = {householdId}")
        .Build()
        .Search<HouseholdMembers>();
      return householdMembers;
    }
  }
}
