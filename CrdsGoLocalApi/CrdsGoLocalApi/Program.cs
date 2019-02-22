using Logzio.DotNet.NLog;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using NLog;
using NLog.Config;
using NLog.Targets;
using NLog.Web;
using System;

namespace CrdsGoLocalApi
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>();

    static NLog.Logger SetUpLogging()
    {

      //TODO: Load this from a singleton of SettingsService
      var isDevelopment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == EnvironmentName.Development;

      var loggingConfig = new LoggingConfiguration();

      //Set up to log to stdout
      if (isDevelopment)
      {
        var consoleTarget = new ColoredConsoleTarget("console")
        {
          Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception:format=ToString}"
        };
        loggingConfig.AddTarget("console", consoleTarget);

        //Log everything in development
        loggingConfig.AddRuleForAllLevels(consoleTarget, "*");
      }
      else // Log to Logzio
      {
        var logzioTarget = new LogzioTarget
        {
          //TODO: Load this from a singleton of SettingsService
          Token = Environment.GetEnvironmentVariable("LOGZ_IO_KEY"),
        };
        logzioTarget.ContextProperties.Add(new TargetPropertyWithContext("host", "${machinename}"));
        logzioTarget.ContextProperties.Add(new TargetPropertyWithContext("application", Environment.GetEnvironmentVariable("APP_NAME")));
        logzioTarget.ContextProperties.Add(new TargetPropertyWithContext("environment", Environment.GetEnvironmentVariable("CRDS_ENV")));
        loggingConfig.AddTarget("logzio", logzioTarget);

        //Log only error and above for all built in logs
        loggingConfig.AddRule(NLog.LogLevel.Error, NLog.LogLevel.Fatal, logzioTarget, "*");

        //Log everything debug and above for custom logs
        loggingConfig.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, logzioTarget, "Crossroads.*");

        // Also log to console so we have the info
        var consoleTarget = new ColoredConsoleTarget("console")
        {
          Layout = @"${date:format=HH\:mm\:ss} ${level} ${message} ${exception:format=ToString}"
        };
        loggingConfig.AddTarget("console", consoleTarget);

        //Log only warn and above for all built in logs
        loggingConfig.AddRule(NLog.LogLevel.Error, NLog.LogLevel.Fatal, consoleTarget, "*");

        //Log everything debug and above for custom logs
        loggingConfig.AddRule(NLog.LogLevel.Debug, NLog.LogLevel.Fatal, consoleTarget, "Crossroads.*");

        var databaseTarget = new DatabaseTarget();
      }

      LogManager.Configuration = loggingConfig;

      return NLogBuilder.ConfigureNLog(loggingConfig).GetCurrentClassLogger();
    }
  }
}
