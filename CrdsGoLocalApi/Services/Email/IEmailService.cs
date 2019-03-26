using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Email
{
  public interface IEmailService
  {
    string CreateStyledGuestList(VolunteerDTO volunteerData);
    List<GuestContact> GetNewGuestListWithLeaderIncluded(VolunteerDTO volunteerData);
  }
}