using CrdsGoLocalApi.Services;
using CrdsGoLocalApi.Services.Services;
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

      services.AddSwaggerGen(c => {
        c.SwaggerDoc("v1", new Info {Title = "GO Local API", Version = "v1"});
      });

      services.AddSingleton<ISettingsService, SettingsService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseHsts();
      }

      app.UseSwagger();
      if (env.IsDevelopment())
      {
        app.UseSwaggerUI(c => {
          c.SwaggerEndpoint("/swagger/v1/swagger.json", "GO Local API v1");
        });
      }
      else
      {
        app.UseSwaggerUI(c => {
          c.SwaggerEndpoint("/golocal/swagger/v1/swagger.json", "GO Local API v1");
        });
      }

      app.UseHttpsRedirection();
      app.UseMvc();
    }
  }
}