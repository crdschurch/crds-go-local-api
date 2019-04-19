using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.EmailHelper
{
  public interface IEmailHelperService
  {
    string FormatProjectVolunteerList(List<GroupMember> volunteers);
    string CreateStyledAttendeeList(VolunteerDTO volunteerData);
  }
}