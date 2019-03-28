using System;
using System.Reflection;
using Crossroads.Web.Common.Security;
using Crossroads.Web.Common.Services;
using log4net;
using Microsoft.AspNetCore.Http;

namespace CrdsGoLocalApi.Services.Auth
{
  public class MpAuthService : IMpAuthService
  {
    private readonly IAuthTokenExpiryService _authTokenExpiryService;
    protected readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
    private readonly IAuthenticationRepository _authenticationRepository;

    public const string AuthorizationTokenHeaderName = "Authorization";
    public const string RefreshTokenHeaderName = "RefreshToken";

    public MpAuthService(IAuthTokenExpiryService authTokenExpiryService, IAuthenticationRepository authenticationRepository)
    {
      _authTokenExpiryService = authTokenExpiryService;
      _authenticationRepository = authenticationRepository;
    }

    /// <summary>
    /// Check if a user's authorization token is expired or expiring soon and try to refresh it using their refresh token.
    /// Also updates the response headers so that the client can update to match. 
    /// </summary>
    /// <param name="context">The HttpContext that </param>
    /// <returns>An HttpContext with the Authorization token refreshed if needed.</returns>
    public HttpContext RefreshTokenIfNeeded(HttpContext context)
    {
      try
      {
        bool authTokenCloseToExpiry = _authTokenExpiryService.IsAuthTokenCloseToExpiry(context.Request.Headers);

        bool isRefreshTokenPresent = context.Request.Headers.ContainsKey(RefreshTokenHeaderName);

        if (authTokenCloseToExpiry && isRefreshTokenPresent)
        {
          var authData = _authenticationRepository.RefreshToken(context.Request.Headers[RefreshTokenHeaderName]);
          if (authData != null)
          {
            var authorized = authData.AccessToken;
            var refreshToken = authData.RefreshToken;

            context.Request.Headers[AuthorizationTokenHeaderName] = authorized;
            context.Request.Headers[RefreshTokenHeaderName] = refreshToken;

            context.Response.Headers.Add("Access-Control-Expose-Headers", new[] { AuthorizationTokenHeaderName, RefreshTokenHeaderName });
            context.Response.Headers.Add(AuthorizationTokenHeaderName, authorized);
            context.Response.Headers.Add(RefreshTokenHeaderName, refreshToken);
          }
        }
      }
      catch (InvalidOperationException e)
      {
        Logger.Error(e.Message, e);
      }

      return context;
    }
  }
}
