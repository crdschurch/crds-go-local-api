using System.Collections.Generic;
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
        .AddSelectColumn("Group_ID")
        .AddSelectColumn("Primary_Contact_Table.[Contact_ID] AS [Primary_Contact]")
        .AddSelectColumn("Primary_Contact_Table.[First_Name] AS [Primary_Contact_First_Name]")
        .AddSelectColumn("Primary_Contact_Table.[Last_Name] AS [Primary_Contact_Last_Name]")
        .Build()
        .Get<Group>(groupId);
      return group;
    }

    public List<GroupMembers> GetGroupMembers(int groupId)
    {
      var apiToken = _tokenService.GetClientToken();
      var members = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .AddSelectColumn("Group_Participant_ID")
        .AddSelectColumn("Group_Role_ID_Table.[Group_Role_ID] AS [Group_Role_ID]")
        .AddSelectColumn("Participant_ID_Table_Contact_ID_Table.[Contact_ID] AS [Contact_ID]")
        .AddSelectColumn("Participant_ID_Table_Contact_ID_Table.[First_Name] AS [First_Name]")
        .AddSelectColumn("Participant_ID_Table_Contact_ID_Table.[Last_Name] AS [Last_Name]")
        .AddSelectColumn("Participant_ID_Table_Contact_ID_Table.[Email_Address] AS [Email_Address]")
        .AddSelectColumn("Participant_ID_Table_Contact_ID_Table.[Mobile_Phone] AS [Mobile_Phone]")
        .WithFilter($"Group_ID = {groupId} AND (End_Date IS NULL OR End_Date > GETDATE())")
        .Build()
        .Search<GroupMembers>();
      return members;
    }

    public List<GoLocalKids> GetGoLocalKidsForProject(int groupId)
    {
      var apiToken = _tokenService.GetClientToken();
      var kiddos = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .WithFilter($"Group_Participant_ID_Table.Group_ID = {groupId}")
        .Build()
        .Search<GoLocalKids>();
      return kiddos;
    }
  }
}
