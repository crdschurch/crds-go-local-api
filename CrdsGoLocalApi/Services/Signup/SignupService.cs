using System;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Signup
{
  public class SignupService : ISignupService
  {
    public bool SignupUser(VolunteerDTO signupData)
    {
      var houseHoldId = CreateHousehold(signupData.LastName);
      var contactId = CreateContact(signupData.FirstName, 
        signupData.LastName, 
        signupData.Email, 
        signupData.BirthDate,
        houseHoldId);

      return true;
    }

    public int CreateHousehold(string householdName)
    {
      var household = new Household{ HouseholdName = householdName };

      // TODO: Create Household Record

      return household.HouseholdId;
    }

    public int CreateContact(string firstName, string lastName, string email, DateTime birthday, int householdId)
    {
      var contact = new Contact
      {
        FirstName = firstName,
        Nickname = firstName,
        LastName = lastName,
        EmailAddress = email,
        DateOfBirth = birthday,
        HouseholdId = householdId
      };

      // TODO: Create Contact Record

      return contact.ContactId;
    }
  }
}
