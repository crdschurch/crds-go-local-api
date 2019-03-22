using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HealthController : ControllerBase
  {
     private readonly static NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    // GET /api/health/status
    [HttpGet]
    [Route("status")]
    public IActionResult GetHealth()
    {
      _logger.Info("Running health check...");
      return StatusCode(200, "OK");
    }
  }
}