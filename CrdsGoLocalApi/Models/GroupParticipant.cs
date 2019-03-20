using System;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Group_Participants")]
  public class GroupParticipant
  {
    [JsonProperty("Group_Participant_ID")]
    public int GroupParticipantId { get; set; }

    [JsonProperty("Participant_ID")]
    public int ParticipantId { get; set; }

    [JsonProperty("Group_ID")]
    public int GroupId { get; set; }

    [JsonProperty("Group_Role_ID")]
    public int GroupRoleId { get; set; }

    [JsonProperty("Start_Date")]
    public DateTime? StartDate { get; set; }
    
    [JsonProperty("Enrolled_By")]
    public int? EnrolledBy { get; set; }
  }
}
