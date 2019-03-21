using System;
using CrdsGoLocalApi.Services.Project;
using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
    [Route("api/search")]
    [ApiController]
    public class SearchController : ControllerBase
    {
      private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
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
        try
        {
          _logger.Info("Searching for projects");
          var projects = _projectService.GetAllProjects();
          return Ok(projects);
        }
        catch (Exception ex)
        {
          _logger.Error(ex, "Error getting projects");
          return BadRequest();
        }
      }
    }
}