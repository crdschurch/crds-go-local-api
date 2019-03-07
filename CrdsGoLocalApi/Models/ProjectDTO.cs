using System;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
  public class ProjectDTO
  {
    [JsonProperty(PropertyName = "id")]
    public int Id { get; set; }

    [JsonProperty(PropertyName = "orgName")]
    public string OrganizationName { get; set; }
    
    [JsonProperty(PropertyName = "name")]
    public string ProjectName { get; set; }

    [JsonProperty(PropertyName = "minAge")]
    public int MinimumAge { get; set; }

    [JsonProperty(PropertyName = "crdsSite")]
    public string Site { get; set; }

    [JsonProperty(PropertyName = "type")]
    public string ProjectTypeName { get; set; }

    [JsonProperty(PropertyName = "numberNeeded")]
    public int VolunteersNeeded { get; set; }

    [JsonProperty(PropertyName = "spots")]
    public int SpotsLeft { get; set; }

    [JsonProperty(PropertyName = "captainName")]
    public string CaptainName { get; set; }
    
    [JsonProperty(PropertyName = "minVols")]
    public int MinVols { get; set; }

    [JsonProperty(PropertyName = "maxVols")]
    public int MaxVols { get; set; }

    [JsonProperty(PropertyName = "address")]
    public string Address { get; set; }

    [JsonProperty(PropertyName = "lat")]
    public double Latitude { get; set; }

    [JsonProperty(PropertyName = "long")]
    public double Longitude { get; set; }

    [JsonProperty(PropertyName = "startDate")]
    public DateTime StartDate { get; set; }

    [JsonProperty(PropertyName = "endDate")]
    public DateTime EndDate { get; set; }

    [JsonProperty(PropertyName = "projectScope")]
    public string ProjectDescription { get; set; }

    [JsonProperty(PropertyName = "statusId")]
    public int ProjectStatusId { get; set; }
  }
}
