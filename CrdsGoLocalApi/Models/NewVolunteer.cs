using System.Collections.Generic;

namespace CrdsGoLocalApi.Models
{
  public class NewVolunteer
  {
    public int ContactId { get; set; }
    public int HouseholdId { get; set; }
    public int ParticipantId { get; set; }
    public int GroupParticipantId { get; set; }
    public List<HouseholdMembers> FamilyMembers { get; set; }
  }
}
