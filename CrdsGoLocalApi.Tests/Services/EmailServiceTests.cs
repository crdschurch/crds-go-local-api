using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Email;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CrdsGoLocalApi.Tests.Services
{
  public class EmailServiceTests
  {
    private readonly EmailService _fixture;

    public EmailServiceTests()
    {
      _fixture = new EmailService();
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
        "Angie Wobey<br>Mandy Bagelberry<br>Leeroy Jenkins" +
        "</div>";

      Assert.Equal(expected, actual);
    }
  }
}
