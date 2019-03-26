using System.Collections.Generic;
using System.Linq;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.GroupData;
using CrdsGoLocalApi.Services.Email;
using Crossroads.Web.Common.MinistryPlatform;
using Crossroads.Web.Common.Models;

namespace CrdsGoLocalApi.Repositories.Email
{
  public class EmailRepository : IEmailRepository
  {
    private readonly IMpEmailSender _emailSender;
    private readonly IEmailService _emailService;
    private readonly IGroupDataRepository _groupRepository;

    public EmailRepository(IGroupDataRepository groupData, IMpEmailSender emailSender, IEmailService emailService)
    {
      _emailSender = emailSender;
      _emailService = emailService;
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
          {"Project_Name", projectData.ProjectName },
          {"Address", $"{projectData.Address1} {projectData.Address2} {projectData.AddressCity}, {projectData.AddressState} {projectData.AddressZip}" },
          {"Start_Date", projectData.StartDate },
          {"Project_Type_Description", projectData.ProjectType },
          {"Kids_2_7", volunteerData.KidsTwoToSevenCount },
          {"Kids_8_12", volunteerData.KidsEightToTwelveCount },
          {"Guest_List", _emailService.CreateStyledAttendeeList(volunteerData) }
        }
      };
      var sent = _emailSender.SendEmail(email, false).Result;
      return sent;
    }
  }
}
