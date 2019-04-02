using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Email
{
  public interface IEmailService
  {
    string CreateStyledAttendeeList(VolunteerDTO volunteerData);
  }
}