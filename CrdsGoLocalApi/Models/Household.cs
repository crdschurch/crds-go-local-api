using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Households")]
  public class Household
  {
    [JsonProperty(PropertyName = "Household_ID")]
    public int HouseholdId { get; set; }

    [JsonProperty(PropertyName = "Household_Name")]
    public string HouseholdName { get; set; }
  }
}
