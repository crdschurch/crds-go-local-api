using System;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Contacts")]
  public class Contact
  {
    [JsonProperty(PropertyName = "Contact_ID")]
    public int ContactId { get; set; }

    [JsonProperty(PropertyName = "Company")]
    public bool Company { get; set; }

    [JsonProperty(PropertyName = "Email_Address")]
    public string EmailAddress { get; set; }

    [JsonProperty(PropertyName = "Mobile_Phone")]
    public string MobilePhone { get; set; }

    [JsonProperty(PropertyName = "First_Name")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "Last_Name")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "Display_Name")]
    public string DisplayName { get; set; }

    [JsonProperty(PropertyName = "Date_of_Birth")]
    public DateTime DateOfBirth { get; set; }

    [JsonProperty(PropertyName = "Household_ID")]
    public int HouseholdId { get; set; }

    [JsonProperty(PropertyName = "Contact_Status")]
    public int ContactStatusId { get; set; }

    [JsonProperty(PropertyName = "Household_Position_ID")]
    public int HouseholdPosition { get; set; }
  }
}