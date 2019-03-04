using System;
using System.Collections;
using System.Collections.Generic;

namespace CrdsGoLocalApi.Services.Settings
{
  namespace Services
  {
    public class SettingsService : ISettingsService
    {
      private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

      private Dictionary<string, string> appSettings;

      public SettingsService()
      {
        appSettings = new Dictionary<string, string>();
        var envVarSettings = GetSettingsFromEnvironmentVariables();
        AddSettings(envVarSettings);
      }

      public string GetValue(string key)
      {
        if (appSettings.TryGetValue(key, out string value))
        {
          return value;
        }
        return null;
      }

      private void AddSettings(Dictionary<string, string> settings)
      {
        foreach (var setting in settings)
        {
          appSettings.TryAdd(setting.Key, setting.Value);
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
          Logger.Error(ex, "Error Getting Environment Variables");
        }

        return envSettings;
      }

    }
  }
}
