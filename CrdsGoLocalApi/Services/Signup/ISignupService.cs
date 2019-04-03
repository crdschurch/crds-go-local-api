using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Signup
{
  public interface ISignupService
  {
    bool SignupUser(VolunteerDTO signupData);
    ContactDTO GetContactData(int contactId);
  }
}