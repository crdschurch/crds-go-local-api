using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  public class VolunteerDTO
  {
    [JsonProperty(PropertyName = "contactId")]
    public int? ContactId { get; set; }

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

    [JsonProperty(PropertyName = "countOfKidsBetweenTwoAndSeven")]
    public int KidsTwoToSevenCount { get; set; }

    [JsonProperty(PropertyName = "countOfKidsBetweenEightAndTwelve")]
    public int KidsEightToTwelveCount { get; set; }

    [JsonProperty(PropertyName = "guests")]
    public List<GuestContact> Guests { get; set; }
  }
}
