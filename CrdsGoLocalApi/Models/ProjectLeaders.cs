using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  public class ProjectLeaders
  {
    [JsonProperty(PropertyName = "Group_ID")]
    public int GroupId { get; set; }

    [JsonProperty(PropertyName = "Leader_Name")]
    public string GroupLeader { get; set; }
  }
}
