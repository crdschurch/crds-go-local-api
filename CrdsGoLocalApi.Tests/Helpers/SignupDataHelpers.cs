using System;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Tests.Helpers
{
  public class SignupDataHelpers
  {
    public static VolunteerDTO MockSignupDataWithKids()
    {
      return new VolunteerDTO
      {
        FirstName = "Fred",
        LastName = "Flintstone",
        Email = "fred.flintstone@crossroads.net",
        PhoneNumber = "123-456-7890",
        BirthDate = new DateTime(1901, 01, 01),
        KidsTwoToSevenCount = 1,
        KidsEightToTwelveCount = 2,
        ProjectId = 9876,
        ContactId = 1234
      };
    }

    public static VolunteerDTO MockSignupDataNoKids()
    {
      return new VolunteerDTO
      {
        FirstName = "Fred",
        LastName = "Flintstone",
        Email = "fred.flintstone@crossroads.net",
        PhoneNumber = "123-456-7890",
        BirthDate = new DateTime(1901, 01, 01),
        ProjectId = 9876,
        ContactId = 1234
      };
    }

    public static MpProject MockProject()
    {
      return new MpProject
      {
        ProjectId = 9876,
        GroupId = 54321
      };
    }
  }
}
