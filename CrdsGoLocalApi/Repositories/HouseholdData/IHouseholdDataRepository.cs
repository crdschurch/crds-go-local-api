using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.HouseholdData
{
  public interface IHouseholdDataRepository
  {
    int CreateHousehold(Household householdData);
  }
}