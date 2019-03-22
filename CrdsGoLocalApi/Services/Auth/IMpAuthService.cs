using Microsoft.AspNetCore.Http;

namespace CrdsGoLocalApi.Services.Auth
{
  public interface IMpAuthService
  {
    /// <summary>
    /// Check if a user's authorization token is expired or expiring soon and try to refresh it using their refresh token.
    /// Also updates the response headers so that the client can update to match. 
    /// </summary>
    /// <param name="context">The HttpContext that </param>
    /// <returns>An HttpContext with the Authorization token refreshed if needed.</returns>
    HttpContext RefreshTokenIfNeeded(HttpContext context);
  }
}