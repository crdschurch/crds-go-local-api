using System;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  public class GuestContact
  {
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "dob")]
    public DateTime BirthDate { get; set; }

    [JsonProperty(PropertyName = "householdPositionId")]
    public int? HouseholdPositionId { get; set; }
  }
}
