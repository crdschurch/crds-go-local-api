using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  public class GroupCount
  {
    [JsonProperty(PropertyName = "Group_ID")]
    public int GroupId { get; set; }

    [JsonProperty(PropertyName = "Participant_Count")]
    public int ParticipantCount { get; set; }
  }
}
