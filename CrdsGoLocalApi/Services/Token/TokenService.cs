using System;
using CrdsGoLocalApi.Services.Cache;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Services.Token
{
  public class TokenService : ITokenService
  {
    private readonly ICacheService _cache;
    private readonly IApiUserRepository _apiRepo;

    public TokenService(ICacheService cacheService, IApiUserRepository apiUserRepository)
    {
      _cache = cacheService;
      _apiRepo = apiUserRepository;
    }

    public string GetClientToken()
    {
      return _cache.GetOrSet<string>("token",
        TimeSpan.FromMinutes(29),
        () => _apiRepo.GetApiClientToken("CRDS.GOLocal"));
    }
  }
}
