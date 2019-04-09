using System.Collections.Generic;
using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.GroupData
{
  public interface IGroupDataRepository
  {
    Group GetGroup(int groupId);
    List<GroupMembers> GetGroupMembers(int groupId);
  }
}