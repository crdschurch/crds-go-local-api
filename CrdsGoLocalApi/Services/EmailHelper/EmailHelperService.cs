using System.Collections.Generic;
using System.Linq;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.EmailHelper
{
  public class EmailHelperService : IEmailHelperService
  {
    public string CreateStyledAttendeeList(VolunteerDTO volunteerData)
    {
      List<string> attendeeNames = volunteerData.Guests.Select(g => $"{g.FirstName} {g.LastName}").ToList();
      attendeeNames.Insert(0, $"{volunteerData.FirstName} {volunteerData.LastName}");

      string styledAttendeeList =
        "<div style=\"margin-left: 40px\">"
        + string.Join("<br>", attendeeNames)
        + "</div>";

      return styledAttendeeList;
    }

    public string FormatProjectVolunteerList(List<GroupMembers> volunteers)
    {
      return "";
    }
  }
}
