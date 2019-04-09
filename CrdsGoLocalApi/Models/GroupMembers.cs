using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Group_Participants")]
  public class GroupMembers
  {
    [JsonProperty(PropertyName = "Group_Participant_ID")]
    public int GroupParticipantId { get; set; }

    [JsonProperty(PropertyName = "Contact_ID")]
    public int ContactId { get; set; }

    [JsonProperty(PropertyName = "Group_Role_ID")]
    public int RoleId { get; set; }

    [JsonProperty(PropertyName = "First_Name")]
    public string FirstName { get; set; }

    [JsonProperty(PropertyName = "Last_Name")]
    public string LastName { get; set; }

    [JsonProperty(PropertyName = "Email_Address")]
    public string EmailAddress { get; set; }

    [JsonProperty(PropertyName = "Mobile_Phone")]
    public string MobilePhone { get; set; }

    public GoLocalKids KidsAttending { get; set; }
  }
}
