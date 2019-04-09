using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.EmailHelper
{
  public interface IEmailHelperService
  {
    string CreateStyledAttendeeList(VolunteerDTO volunteerData);
  }
}