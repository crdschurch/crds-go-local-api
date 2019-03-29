using System;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Signup;
using Microsoft.AspNetCore.Mvc;
using Crossroads.Web.Auth.Controllers;
using Crossroads.Web.Common.Security;
using Crossroads.Web.Common.Services;

namespace CrdsGoLocalApi.Controllers
{
  [Route("api/signup")]
  [ApiController]
  public class SignupController : AuthBaseController 
  {
    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
    private readonly ISignupService _signupService;

    public SignupController(ISignupService signupService, IAuthenticationRepository authentication, IAuthTokenExpiryService authTokenExpiry) : base(authentication, authTokenExpiry)
    {
      _signupService = signupService;
    }

    // POST /api/signup/submit
    [HttpPost]
    [Route("submit")]
    public IActionResult SignupVolunteer(VolunteerDTO volunteerData)
    {
      _logger.Info($"Saving volunteer signup...");
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

    // GET /api/signup/loggedin
    [HttpGet]
    [Route("loggedin")]
    public IActionResult GetLoggedInUserData()
    {
      return Authorized(authData =>
      {
        var contact = _signupService.GetContactData(authData.UserInfo.Mp.ContactId);
        return Ok(contact);
      });
    }
  }
}