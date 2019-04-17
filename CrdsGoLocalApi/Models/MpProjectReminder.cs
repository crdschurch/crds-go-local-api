using System;
using Crossroads.Web.Common.MinistryPlatform;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  [MpRestApiTable(Name = "cr_Projects")]
  public class MpProjectReminder
  {
    [JsonProperty(PropertyName = "Project_ID")]
    public int ProjectId { get; set; }

    [JsonProperty(PropertyName = "Project_Name")]
    public string ProjectName { get; set; }

    [JsonProperty(PropertyName = "Project_Description")]
    public string ProjectDescription { get; set; }

    [JsonProperty(PropertyName = "Organization_Name")]
    public string OrgName { get; set; }

    [JsonProperty(PropertyName = "Project_Type_Description")]
    public string ProjectType { get; set; }

    [JsonProperty(PropertyName = "Address_Line_1")]
    public string Address1 { get; set; }

    [JsonProperty(PropertyName = "Address_Line_2")]
    public string Address2 { get; set; }

    [JsonProperty(PropertyName = "Address_City")]
    public string AddressCity { get; set; }

    [JsonProperty(PropertyName = "Address_State")]
    public string AddressState { get; set; }

    [JsonProperty(PropertyName = "Address_Zip")]
    public string AddressZip { get; set; }

    [JsonProperty(PropertyName = "Start_Date")]
    public DateTime? StartDate { get; set; }

    [JsonProperty(PropertyName = "End_Date")]
    public DateTime? EndDate { get; set; }

    [JsonProperty(PropertyName = "Group_ID")]
    public int? GroupId { get; set; }

    [JsonProperty(PropertyName = "Note_To_Volunteers_1")]
    public string NoteToVolunteers { get; set; }

    [JsonProperty(PropertyName = "Project_Parking_Location")]
    public string ParkingLocation { get; set; }
  }
}
