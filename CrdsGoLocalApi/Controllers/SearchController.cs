using CrdsGoLocalApi.Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
      private readonly IProjectService _projectService;

      public SearchController(IProjectService projectService)
      {
        _projectService = projectService;
      }

      [HttpGet]
      [Route("projects")]
      public IActionResult GetProjects()
      {
        var projects = _projectService.GetAllProjects();
        return Ok(projects);
      }
    }
}