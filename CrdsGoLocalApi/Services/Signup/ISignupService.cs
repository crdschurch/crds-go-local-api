using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Signup
{
  public interface ISignupService
  {
    bool SignupUser(VolunteerDTO signupData);
    Contact GetContactData(int contactId);
  }
}