using System.Linq;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Repositories.Email;
using CrdsGoLocalApi.Repositories.GroupData;
using CrdsGoLocalApi.Repositories.ProjectData;
using System.Collections.Generic;

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

    public int SendVolunteersReminderEmails(int initiativeId)
    {
      int sentEmailsCount = 0;

      List<MpProjectReminder> projects = _projectDataRepository.GetProjectReminderData(initiativeId);

      foreach (var project in projects)
      {
        sentEmailsCount += SendVolunteersEmails(project);
      }

      return sentEmailsCount;
    }

    private int SendVolunteersEmails(MpProjectReminder project)
    {
      int sentEmailsCount = 0;

      List<GroupMember> groupMembers = _groupDataRepository.GetGroupMembers(project.GroupId.Value);
      List<GroupMember> volunteers = GetVolunteersAndTheirKidInformation(project.GroupId.Value, groupMembers);
      List<GroupMember> leaders = groupMembers.Where(gm => gm.RoleId == MpConstants.GroupLeaderRoleId).ToList();

      foreach (var vol in volunteers)
      {
        var group = _groupDataRepository.GetGroup(project.GroupId.Value);
        bool wasSent = SendVolunteerReminderEmail(project, leaders, vol, group);
        if (wasSent) { sentEmailsCount++; }
      }

      return sentEmailsCount;
    }

    private bool SendVolunteerReminderEmail(MpProjectReminder project, 
                                            List<GroupMember> leaders, 
                                            GroupMember vol, 
                                            Group group)
    {
      var newEmailData = new ProjectLeaderEmailData
      {
        ProjectName = project.ProjectName,
        Organization = project.OrgName,
        ProjectGroupContactId = group.PrimaryContactId,
        ProjectGroupContactFirstName = group.PrimaryContactFirstName,
        ProjectGroupContactLastName = group.PrimaryContactLastName,
        ProjectLeaderContactId = vol.ContactId,
        ProjectLeaderFirstName = vol.FirstName,
        ProjectLeaderLastName = vol.LastName,
        //Volunteers = volunteers
      };
      var sent = _emailRepository.SendProjectLeaderEmail(newEmailData);
      return sent;
    }

    private List<GroupMember> GetVolunteersAndTheirKidInformation(int groupId, List<GroupMember> groupMembers) {
      List<GoLocalKids> groupMembersKids = _groupDataRepository.GetGoLocalKidsForProject(groupId);
      List<GroupMember> volunteers = groupMembers.Where(v => v.RoleId == MpConstants.GroupMemberRoleId).ToList();

      foreach (var vol in volunteers)
      {
        vol.KidsAttending = groupMembersKids.FirstOrDefault(k => k.GroupParticipantId == vol.GroupParticipantId);
      }

      return groupMembers;
    }
  }
}
