using System.Collections.Generic;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Models
{
    public class FamilyDTO
    {
        [JsonProperty(PropertyName = "mainVolunteer")]
        public ContactDTO MainVolunteer { get; set; }
        
        [JsonProperty(PropertyName = "familyMembers")]
        public List<ContactDTO> FamilyMembers { get; set; }
    }
}