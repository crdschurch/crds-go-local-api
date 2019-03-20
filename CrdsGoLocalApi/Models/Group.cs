using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Groups")]
  public class Group
  {
    [JsonProperty(PropertyName = "Group_ID")]
    public int GroupId { get; set; }

    [JsonProperty(PropertyName = "Primary_Contact")]
    public int PrimaryContactId { get; set; }
  }
}
