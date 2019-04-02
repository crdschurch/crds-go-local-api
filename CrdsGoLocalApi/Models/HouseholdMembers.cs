using System;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Contacts")]
  public class HouseholdMembers
  {
    [JsonProperty(PropertyName = "Contact_ID")]
    public int ContactId { get; set; }

    [JsonProperty(PropertyName = "First_Name")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "Last_Name")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "Date_of_Birth")]
    public DateTime DateOfBirth { get; set; }

    [JsonProperty(PropertyName = "Household_Position_ID")]
    public int HouseholdPosition { get; set; }
  }
}
