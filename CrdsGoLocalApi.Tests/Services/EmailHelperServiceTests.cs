using CrdsGoLocalApi.Models;
using System.Collections.Generic;
using CrdsGoLocalApi.Services.EmailHelper;
using Xunit;

namespace CrdsGoLocalApi.Tests.Services
{
  public class EmailHelperServiceTests
  {
    private readonly EmailHelperService _fixture;

    public EmailHelperServiceTests()
    {
      _fixture = new EmailHelperService();
    }

    [Fact]
    public void ShouldCreateGuestListWithOnlyLeader()
    {
      VolunteerDTO volunteerData = new VolunteerDTO();
      volunteerData.FirstName = "Leeroy";
      volunteerData.LastName = "Jenkins";
      volunteerData.Guests = new List<GuestContact>();

      string actual = _fixture.CreateStyledAttendeeList(volunteerData);
      string expected =  "<div style=\"margin-left: 40px\">Leeroy Jenkins</div>";

      Assert.Equal(expected, actual);
    }

    [Fact]
    public void ShouldCreateGuestListWithLeaderAndSomePeeps()
    {
      VolunteerDTO volunteerData = new VolunteerDTO();
      volunteerData.FirstName = "Leeroy";
      volunteerData.LastName = "Jenkins";
      volunteerData.Guests = new List<GuestContact>();
      volunteerData.Guests.Add(new GuestContact { FirstName = "Angie", LastName = "Wobey" });
      volunteerData.Guests.Add(new GuestContact { FirstName = "Mandy", LastName = "Bagelberry"  });

      string actual = _fixture.CreateStyledAttendeeList(volunteerData);
      string expected =  
        "<div style=\"margin-left: 40px\">" +
        "Leeroy Jenkins<br>Angie Wobey<br>Mandy Bagelberry" +
        "</div>";

      Assert.Equal(expected, actual);
    }
  }
}
