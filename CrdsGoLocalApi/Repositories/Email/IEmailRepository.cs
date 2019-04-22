using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.Email
{
  public interface IEmailRepository
  {
    bool SendConfirmationEmail(MpProject projectData, VolunteerDTO volunteerData, int toContactId);
    bool SendProjectLeaderEmail(ProjectLeaderEmailData emailData);
    bool SendVolunteerReminderEmail(VolunteerReminderEmailData emailData);
  }
}