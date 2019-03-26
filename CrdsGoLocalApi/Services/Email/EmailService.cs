using System;
using System.Linq;
using CrdsGoLocalApi.Models;
using System.Collections.Generic;

namespace CrdsGoLocalApi.Services.Email
{
  public class EmailService : IEmailService
  {
    public EmailService() {}

    public string CreateStyledGuestList(VolunteerDTO volunteerData)
    {
      List<string> attendeeNames = volunteerData.Guests.Select(g => g.FirstName + " " + g.LastName).ToList();
      attendeeNames.Add($"{volunteerData.FirstName} {volunteerData.LastName}");

      string styledGuestList = 
        "<div style=\"margin-left: 40px\">"
        + string.Join("<br>", attendeeNames)
        + "</div>";

      return styledGuestList;
    }
  }
}
