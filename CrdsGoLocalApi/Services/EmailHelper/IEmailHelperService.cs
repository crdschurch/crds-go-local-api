using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.EmailHelper
{
  public interface IEmailHelperService
  {
    string FormatProjectVolunteerList(List<GroupMembers> volunteers);
    string CreateStyledAttendeeList(VolunteerDTO volunteerData);
  }
}