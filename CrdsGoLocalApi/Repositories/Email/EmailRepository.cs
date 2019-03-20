using System.Collections.Generic;
using System.Linq;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.GroupData;
using Crossroads.Web.Common.MinistryPlatform;
using Crossroads.Web.Common.Models;

namespace CrdsGoLocalApi.Repositories.Email
{
  public class EmailRepository : IEmailRepository
  {
    private readonly IGroupDataRepository _groupRepository;
    private readonly IMpEmailSender _emailSender;

    public EmailRepository(IGroupDataRepository groupData, IMpEmailSender emailSender)
    {
      _emailSender = emailSender;
      _groupRepository = groupData;
    }
    public bool SendConfirmationEmail(MpProject projectData, VolunteerDTO volunteerData, int toContact)
    {
      var group = _groupRepository.GetGroup(projectData.GroupId.Value);
      var email = new EmailCommunication
      {
        ToContactId = new List<int>{ toContact },
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
          {"Guest_List", "<div style=\"margin-left: 40px\">" + string.Join("<br>", volunteerData.Guests.Select(g => g.FirstName + " " + g.LastName)) + "</div>" }
        }
      };
      var sent = _emailSender.SendEmail(email, false).Result;
      return sent;
    }
  }
}
