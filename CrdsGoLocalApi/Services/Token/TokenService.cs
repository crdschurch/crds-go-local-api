using System;
using CrdsGoLocalApi.Services.Cache;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Services.Token
{
  public class TokenService : ITokenService
  {
    private readonly ICacheService _cache;
    private readonly IApiUserRepository _apiRepo;
    private readonly static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    public TokenService(ICacheService cacheService, IApiUserRepository apiUserRepository)
    {
      _cache = cacheService;
      _apiRepo = apiUserRepository;
    }

    public string GetClientToken()
    {
      _logger.Info("Attempting to get a client token...");

      try
      {
        string token = _cache.GetOrSet<string>("token",
        TimeSpan.FromMinutes(29),
        () => _apiRepo.GetApiClientToken("CRDS.GOLocal"));

        _logger.Info($"Got client token {token}");

        return token;
      }
      catch (Exception exc) {
        _logger.Error($"Failed to get client token! EXCEPTION: {exc}");
        throw;
      }
    }
  }
}
