using System;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  public class VolunteerDTO
  {
    [JsonProperty(PropertyName = "firstName")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "lastName")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    [JsonProperty(PropertyName = "mobilePhoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty(PropertyName = "dob")]
    public DateTime BirthDate { get; set; }

    [JsonProperty(PropertyName = "projectId")]
    public int ProjectId { get; set; }

    [JsonProperty(PropertyName = "")]
    public int KidsTwoToSevenCount { get; set; }

    [JsonProperty(PropertyName = "")]
    public int KidsEightToTwelveCount { get; set; }
  }
}
