using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrdsGoLocalApi.Models
{
  public class VolunteerReminderEmailData
  {
    public int ProjectLeaderContactId { get; set; }
    public string ProjectLeaderNames { get; set; }
    public string Organization { get; set; }
    public string ProjectName { get; set; }
    public string ProjectDescription { get; set; }
    public string ProjectAddress {get; set; }
    public string ProjectParkingLocation { get; set; }
    public string ProjectGroupContactFirstName { get; set; }
    public string ProjectGroupContactLastName { get; set; }
    public int ProjectGroupContactId { get; set; }
    public List<GroupMember> Volunteers { get; set; }
  }
}
