using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrdsGoLocalApi.Services
{
  public interface ISettingsService
  {
    string GetValue(string key);
  }
}
