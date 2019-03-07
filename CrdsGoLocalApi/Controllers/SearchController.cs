using CrdsGoLocalApi.Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
      private readonly IProjectService _projectService;

      public SearchController(IProjectService projectService)
      {
        _projectService = projectService;
      }

      // GET /api/search/projects
      [HttpGet]
      [Route("projects")]
      public IActionResult GetProjects()
      {
        var projects = _projectService.GetAllProjects();
        return Ok(projects);
      }
    }
}