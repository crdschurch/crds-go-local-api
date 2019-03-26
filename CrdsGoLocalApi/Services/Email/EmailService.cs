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
      List<GuestContact> guestsWithLeaderIncluded = GetNewGuestListWithLeaderIncluded(volunteerData);
      List<string> attendeeNames = guestsWithLeaderIncluded.Select(g => g.FirstName + " " + g.LastName).ToList(); 

      string styledGuestList = 
        "<div style=\"margin-left: 40px\">"
        + string.Join("<br>", attendeeNames)
        + "</div>";

      return styledGuestList;
    }

    public List<GuestContact> GetNewGuestListWithLeaderIncluded(VolunteerDTO volunteerData)
    {
      GuestContact leaderAsGuest = new GuestContact(volunteerData.FirstName, volunteerData.LastName);
   
      List<GuestContact> allGuestsAndLeader = volunteerData.Guests;
      allGuestsAndLeader.Add(leaderAsGuest);

      return allGuestsAndLeader;
    }
  }
}
