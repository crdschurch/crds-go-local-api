using CrdsGoLocalApi.Repositories.ContactData;
using CrdsGoLocalApi.Repositories.HouseholdData;
using CrdsGoLocalApi.Repositories.ParticipantData;
using CrdsGoLocalApi.Repositories.ProjectData;
using CrdsGoLocalApi.Services.Cache;
using CrdsGoLocalApi.Services.Project;
using CrdsGoLocalApi.Services.Settings;
using CrdsGoLocalApi.Services.Settings.Services;
using CrdsGoLocalApi.Services.Signup;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

namespace CrdsGoLocalApi
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
      services.AddCors();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "GO Local API", Version = "v1" });
      });

      //Dependency Injection
      CrossroadsWebCommonConfig.Register(services);
      services.AddSingleton<ICacheService, CacheService>();
      services.AddSingleton<IContactDataRepository, ContactDataRepository>();
      services.AddSingleton<IHouseholdDataRepository, HouseholdDataRepository>();
      services.AddSingleton<IParticipantDataRepository, ParticipantDataRepository>();
      services.AddSingleton<IProjectDataRepository, ProjectDataRepository>();
      services.AddSingleton<IProjectService, ProjectService>();
      services.AddSingleton<ISettingsService, SettingsService>();
      services.AddSingleton<ISignupService, SignupService>();
      services.AddSingleton<ITokenService, TokenService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseCors(cor =>
        {
          cor.AllowAnyHeader();
          cor.AllowAnyMethod();
          cor.AllowCredentials();
          cor.AllowAnyOrigin();
        });
      }
      else
      {
        app.UseHsts();
        app.UseCors(cor =>
        {
          cor.SetIsOriginAllowedToAllowWildcardSubdomains();
          cor.AllowAnyHeader();
          cor.AllowAnyMethod();
          cor.AllowCredentials();
          cor.WithOrigins(new string[]
            { "http://localhost:5050",
              "http://localhost:4200",
              "http://local.crossroads.net:5050",
              "http://local.crossroads.net:4200",
              "https://*.netlify.com",
              "https://www.golocal-int.crossroads.net",
              "https://www.golocal-demo.crossroads.net",
              "https://www.golocal.crossroads.net",
              "https://golocal-int.crossroads.net",
              "https://golocal-demo.crossroads.net",
              "https://golocal.crossroads.net",
              "https://crossroads.net",
              "https://www.crossroads.net"
          });
        });
      }

      if (env.IsDevelopment())
      {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "GO Local API v1");
        });
      }
      else
      {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
          c.SwaggerEndpoint("/golocal/swagger/v1/swagger.json", "GO Local API v1");
        });
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}