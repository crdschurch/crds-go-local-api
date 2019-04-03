using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.HouseholdData
{
  public interface IHouseholdDataRepository
  {
    int CreateHousehold(Household householdData);
    int GetHouseholdId(int contactId);
    List<HouseholdMembers> GetHouseholdMembers(int householdId);
  }
}