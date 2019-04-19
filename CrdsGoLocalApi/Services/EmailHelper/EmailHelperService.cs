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

    public string FormatProjectVolunteerList(List<GroupMember> volunteers)
    {
      string projVolunteerTableHtml = $@"
        <table class = 'bodyContent' style = 'width: 100%'>
           {GetHeaderRow()}
           {GetVolunteerInfoRows(volunteers)}
        </table>";

      return projVolunteerTableHtml;
    }

    public string GetVolunteerInfoRows(List<GroupMember> volunteers) {
      string volInfoRows = "";

      foreach (GroupMember vol in volunteers) {
        volInfoRows += GetIndividualVolunteerInfoRow(vol);
      }

      return volInfoRows;
    }

    private string GetHeaderRow() {
      return @"<tr>
                <th>Name</th>
                <th>Email</th>
                <th>Phone</th>
                <th>Kids Age 2-7</th>
                <th>Kids Age 8-12</th>
              </tr>";
    }

    private string GetIndividualVolunteerInfoRow(GroupMember vol) {
      return $@"<tr>
          <th>{vol.FirstName} {vol.LastName}</th>
          <th>{vol.EmailAddress}</th>
          <th>{vol.MobilePhone}</th>
          <th>{vol.KidsAttending?.TwoToSeven ?? 0}</th>
          <th>{vol.KidsAttending?.EightToTwelve ?? 0}</th>
        </tr>";
    }
  }
}
