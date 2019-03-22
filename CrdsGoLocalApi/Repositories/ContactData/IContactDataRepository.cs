using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.ContactData
{
  public interface IContactDataRepository
  {
    int CreateContact(Contact contactData);
  }
}