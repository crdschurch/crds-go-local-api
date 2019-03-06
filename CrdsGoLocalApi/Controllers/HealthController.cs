using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class HealthController : ControllerBase
  {
    // GET /api/health/status
    [HttpGet]
    [Route("status")]
    public IActionResult GetHealth()
    {
      return StatusCode(200, "OK");
    }
  }
}