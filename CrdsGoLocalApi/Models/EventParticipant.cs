using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Event_Participants")]
  public class EventParticipant
  {
    [JsonProperty(PropertyName = "Event_Participant_ID")]
    public int EventParticipantId { get; set; }

    [JsonProperty(PropertyName = "Event_ID")]
    public int EventId { get; set; }

    [JsonProperty(PropertyName = "Participant_ID")]
    public int ParticipantId { get; set; }

    [JsonProperty(PropertyName = "Participation_Status_ID")]
    public int ParticipantStatus { get; set; }

    [JsonProperty(PropertyName = "Group_Participant_ID")]
    public int? GroupParticipantId { get; set; }
  }
}
