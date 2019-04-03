using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.ContactData
{
  public interface IContactDataRepository
  {
    int CreateContact(Contact contactData);
    Contact GetContact(int contactId);
    int UpdateContact(Contact contactData);
  }
}