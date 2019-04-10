using System.Linq;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Repositories.Email;
using CrdsGoLocalApi.Repositories.GroupData;
using CrdsGoLocalApi.Repositories.ProjectData;

namespace CrdsGoLocalApi.Services.Email
{
  public class EmailService : IEmailService
  {
    private readonly IEmailRepository _emailRepository;
    private readonly IGroupDataRepository _groupDataRepository;
    private readonly IProjectDataRepository _projectDataRepository;

    public EmailService(IEmailRepository emailRepo, IGroupDataRepository groupData, IProjectDataRepository projectData)
    {
      _emailRepository = emailRepo;
      _groupDataRepository = groupData;
      _projectDataRepository = projectData;
    }

    public int SendProjectLeaderEmails(int initiativeId)
    {
      var sentEmails = 0;
      var projects = _projectDataRepository.GetProjectReminderData(initiativeId);
      foreach (var project in projects)
      {
        var groupMembers = _groupDataRepository.GetGroupMembers(project.GroupId.Value);
        var groupMembersKids = _groupDataRepository.GetGoLocalKidsForProject(project.GroupId.Value);
        var volunteers = groupMembers.Where(v => v.RoleId == MpConstants.GroupMemberRoleId).ToList();

        foreach (var vol in volunteers)
        {
          vol.KidsAttending = groupMembersKids.FirstOrDefault(k => k.GroupParticipantId == vol.GroupParticipantId);
        }

        foreach (var leader in groupMembers.Where(v => v.RoleId == MpConstants.GroupLeaderRoleId))
        {
          var group = _groupDataRepository.GetGroup(project.GroupId.Value);
          var newEmailData = new ProjectLeaderEmailData
          {
            ProjectName = project.ProjectName,
            Organization = project.OrgName,
            ProjectGroupContactId = group.PrimaryContactId,
            ProjectGroupContactFirstName = group.PrimaryContactFirstName,
            ProjectGroupContactLastName = group.PrimaryContactLastName,
            ProjectLeaderContactId = leader.ContactId,
            ProjectLeaderFirstName = leader.FirstName,
            ProjectLeaderLastName = leader.LastName,
            Volunteers = volunteers
          };
          var sent = _emailRepository.SendProjectLeaderEmail(newEmailData);
          if (sent)
          {
            sentEmails++;
          }
        }
      }
      return sentEmails;
    }
  }
}
