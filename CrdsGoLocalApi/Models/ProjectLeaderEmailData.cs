using System.Collections.Generic;

namespace CrdsGoLocalApi.Models
{
  public class ProjectLeaderEmailData
  {
    public int ProjectLeaderContactId { get; set; }
    public string ProjectLeaderFirstName { get; set; }
    public string ProjectLeaderLastName { get; set; }
    public string Organization { get; set; }
    public string ProjectName { get; set; }
    public string ProjectGroupContactFirstName { get; set; }
    public string ProjectGroupContactLastName { get; set; }
    public int ProjectGroupContactId { get; set; }
    public List<GroupMembers> Volunteers { get; set; }
  }
}
