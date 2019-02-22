using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CrdsGoLocalApi.Services
{
  namespace Services
  {
    public class SettingsService : ISettingsService
    {
      private static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

      private Dictionary<string, string> appSettings;

      public SettingsService()
      {
        appSettings = new Dictionary<string, string>();
        var envVarSettings = GetSettingsFromEnvironmentVariables();
        AddSettings(envVarSettings, "Environment Variables");
      }

      public string GetValue(string key)
      {

        if (appSettings.TryGetValue(key, out string value))
        {
          return value;
        }
        else
        {
          return null;
        }
      }

      private void AddSettings(Dictionary<string, string> settings, string source)
      {
        foreach (var setting in settings)
        {
          var success = appSettings.TryAdd(setting.Key, setting.Value);
        }
      }

      private Dictionary<string, string> GetSettingsFromEnvironmentVariables()
      {
        var envSettings = new Dictionary<string, string>();

        try
        {
          var envVars = Environment.GetEnvironmentVariables();

          foreach (DictionaryEntry envVar in envVars)
          {
            envSettings.Add(envVar.Key.ToString(), envVar.Value.ToString());
          }

        }
        catch (Exception ex)
        {
          var foo = ex;
        }

        return envSettings;
      }

    }
  }
}
