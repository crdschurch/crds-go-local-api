using System;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Signup;
using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
  [Route("api/signup")]
  [ApiController]
  public class SignupController : ControllerBase
  {
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private readonly ISignupService _signupService;

    public SignupController(ISignupService signupService)
    {
      _signupService = signupService;
    }

    // POST /api/signup/submit
    [HttpPost]
    [Route("submit")]
    public IActionResult SignupVolunteer(VolunteerDTO volunteerData)
    {
      try
      {
        var success = _signupService.SignupUser(volunteerData);
        if (success)
        {
          return Ok();
        }
        return BadRequest();
      }
      catch (Exception ex)
      {
        _logger.Error(ex, "Error saving signup");
        _logger.Error($"Volunteer info: First Name: {volunteerData.FirstName}, Last Name: {volunteerData.LastName}, Email: {volunteerData.Email}, Project: {volunteerData.ProjectId}");
        return BadRequest();
      }
      
    }
  }
}