using System.Threading.Tasks;
using CrdsGoLocalApi.Services.Auth;
using Crossroads.Web.Common.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace CrdsGoLocalApi.Middleware
{
  public class UserAuthorizationTokenMiddleware
  {
    private readonly RequestDelegate _next;
    private readonly IMpAuthService _mpAuthService;

    public UserAuthorizationTokenMiddleware(RequestDelegate next, IMpAuthService mpAuthService)
    {
      _next = next;
      _mpAuthService = mpAuthService;
    }

    public async Task Invoke(HttpContext context)
    {
      // Clear the auth token, just in case
      UserAuthorizationTokenHolder.Clear();

      context = _mpAuthService.RefreshTokenIfNeeded(context);

      // Get the auth token from the request and set it on the holder
      var accessToken = context.Request.Headers["Authorization"];
      if (!string.IsNullOrWhiteSpace(accessToken))
      {
        UserAuthorizationTokenHolder.Set(accessToken);
      }
      await _next.Invoke(context);
      // Clear the auth token from the holder
      UserAuthorizationTokenHolder.Clear();
    }
  }

  public static class UserAuthorizationTokenMiddlewareExtensions
  {
    public static IApplicationBuilder UseUserAuthorizationTokenMiddleware(this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<UserAuthorizationTokenMiddleware>();
    }
  }
}
