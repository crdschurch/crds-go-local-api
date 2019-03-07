using System;
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

    [JsonProperty(PropertyName = "Project_Status_ID")]
    public int ProjectStatusId { get; set; }

    [JsonProperty(PropertyName = "Organization_Name")]
    public string OrgName { get; set; }

    [JsonProperty(PropertyName = "Project_Type_Description")]
    public string ProjectType { get; set; }

    [JsonProperty(PropertyName = "Project_Type_Min_Age")]
    public int ProjectTypeMinAge { get; set; }

    [JsonProperty(PropertyName = "Minimum_Age_Exception")]
    public int? ProjectAgeException { get; set; }

    [JsonProperty(PropertyName = "Location_Name")]
    public string CrdsSite { get; set; }

    [JsonProperty(PropertyName = "Minimum_Volunteers")]
    public int MinVols { get; set; }

    [JsonProperty(PropertyName = "Maximum_Volunteers")]
    public int MaxVols { get; set; }

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

    [JsonProperty(PropertyName = "Address_Lat")]
    public double? AddressLat { get; set; }

    [JsonProperty(PropertyName = "Address_Long")]
    public double? AddressLong { get; set; }

    [JsonProperty(PropertyName = "Start_Date")]
    public DateTime? StartDate { get; set; }

    [JsonProperty(PropertyName = "End_Date")]
    public DateTime? EndDate { get; set; }

    [JsonProperty(PropertyName = "Group_ID")]
    public int? GroupId { get; set; }
  }
}
