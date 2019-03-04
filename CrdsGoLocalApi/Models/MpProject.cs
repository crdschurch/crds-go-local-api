using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "cr_Projects")]
  public class MpProject
  {
    [JsonProperty(PropertyName = "Project_ID")]
    public int ProjectId { get; set; }

    [JsonProperty(PropertyName = "Project_Name")]
    public string ProjectName { get; set; }

    [JsonProperty(PropertyName = "Project_Description")]
    public string ProjectDescription { get; set; }
  }
}
