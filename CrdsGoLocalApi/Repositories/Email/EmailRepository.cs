using System.Collections.Generic;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.GroupData;
using CrdsGoLocalApi.Services.EmailHelper;
using Crossroads.Web.Common.MinistryPlatform;
using Crossroads.Web.Common.Models;

namespace CrdsGoLocalApi.Repositories.Email
{
  public class EmailRepository : IEmailRepository
  {
    private readonly IEmailHelperService _emailHelperService;
    private readonly IMpEmailSender _emailSender;
    private readonly IGroupDataRepository _groupRepository;

    public EmailRepository(IEmailHelperService emailHelpers, IGroupDataRepository groupData, IMpEmailSender emailSender)
    {
      _emailHelperService = emailHelpers;
      _emailSender = emailSender;
      _groupRepository = groupData;
    }
    public bool SendConfirmationEmail(MpProject projectData, VolunteerDTO volunteerData, int toContactId)
    {
      var group = _groupRepository.GetGroup(projectData.GroupId.Value);
      var email = new EmailCommunication
      {
        ToContactId = new List<int> { toContactId },
        FromContactId = group.PrimaryContactId,
        SenderContactId = group.PrimaryContactId,
        TemplateId = MpConstants.ConfirmationEmailTemplate,
        MergeData = new Dictionary<string, object>
        {
          {"Project_Name", $"{projectData.OrgName} - {projectData.ProjectName}" },
          {"Address", $"{projectData.Address1} {projectData.Address2} {projectData.AddressCity}, {projectData.AddressState} {projectData.AddressZip}" },
          {"Start_Date", projectData.StartDate },
          {"Project_Type_Description", projectData.ProjectType },
          {"Kids_2_7", volunteerData.KidsTwoToSevenCount },
          {"Kids_8_12", volunteerData.KidsEightToTwelveCount },
          {"Guest_List", _emailHelperService.CreateStyledAttendeeList(volunteerData) }
        }
      };
      var sent = _emailSender.SendEmail(email, false).Result;
      return sent;
    }

    public bool SendProjectLeaderEmail(ProjectLeaderEmailData emailData)
    {
      var email = new EmailCommunication{
        ToContactId = new List<int> { emailData.ProjectLeaderContactId },
        FromContactId = emailData.ProjectGroupContactId,
        SenderContactId = emailData.ProjectGroupContactId,
        TemplateId = MpConstants.ProjectLeaderEmailTemplate,
        MergeData = new Dictionary<string, object>
        {
          {"Project_Name", emailData.ProjectName },
          {"Organization", emailData.Organization },
          {"Project_Leader", $"{emailData.ProjectLeaderFirstName} {emailData.ProjectLeaderLastName}" },
          {"Volunteer_List", _emailHelperService.FormatProjectVolunteerList(emailData.Volunteers) },
          {"Project_Group_Contact_First_Name", emailData.ProjectGroupContactFirstName },
          {"Project_Group_Contact_Last_Name", emailData.ProjectGroupContactLastName }
        }
      };
      var sent = _emailSender.SendEmail(email, false).Result;
      return sent;
    }

    public bool SendVolunteerReminderEmail(VolunteerReminderEmailData emailData)
    {
      var email = new EmailCommunication{
        ToContactId = new List<int>() { emailData.ContactIdOfVolEmailIsBeingSentTo },
        FromContactId = emailData.ProjectGroupContactId,
        SenderContactId = emailData.ProjectGroupContactId,
        TemplateId = MpConstants.ProjectVolunteerReminderTemplateId,
        MergeData = new Dictionary<string, object>
        {
          {"Project_Name", emailData.ProjectName },
          {"Organization", emailData.Organization },
          {"Project_Description", emailData.ProjectDescription },
          {"Project_Address", emailData.ProjectAddress},
          {"Project_Parking_Location", emailData.ProjectParkingLocation },
          {"Project_Leader_Names", emailData.ProjectLeaderNames },
          {"Project_Date", emailData.ProjectStart.HasValue ? emailData.ProjectStart.Value.ToString("MM/dd/yy") : "" },
          {"Project_Start_Time", emailData.ProjectStart.HasValue ? emailData.ProjectStart.Value.ToShortTimeString() : ""},
          {"Project_End_Time", emailData.ProjectEnd.HasValue ? emailData.ProjectEnd.Value.ToShortTimeString() : ""}
        }
      };
      var sent = _emailSender.SendEmail(email, false).Result;
      return sent;
    }
  }
}
