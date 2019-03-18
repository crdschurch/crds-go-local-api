using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Services.Email
{
  public interface IEmailRepository
  {
    bool SendConfirmationEmail(MpProject projectData, int toContact);
  }
}