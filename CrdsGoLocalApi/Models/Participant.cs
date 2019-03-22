using System;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "Participants")]
  public class Participant
  {
    [JsonProperty(PropertyName = "Contact_ID")]
    public int ContactId { get; set; }

    [JsonProperty(PropertyName = "Participant_Type_ID")]
    public int ParticipantTypeId { get; set; }

    [JsonProperty(PropertyName = "Participant_ID")]
    public int ParticipantId { get; set; }

    [JsonProperty(PropertyName = "Participant_Start_Date")]
    public DateTime ParticipantStartDate { get; set; }
  }
}