using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "cr_Go_Local_Kids")]
  public class GoLocalKids
  {
    [JsonProperty(PropertyName = "Go_Local_Kids_ID")]
    public int GoLocalKidsId { get; set; }

    [JsonProperty(PropertyName = "Group_Participant_ID")]
    public int GroupParticipantId { get; set; }

    [JsonProperty(PropertyName = "Two_to_Seven_Count")]
    public int TwoToSeven { get; set; }

    [JsonProperty(PropertyName = "Eight_to_Twelve_Count")]
    public int EightToTwelve { get; set; }
  }
}
