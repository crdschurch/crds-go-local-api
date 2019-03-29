using System;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Signup;
using Microsoft.AspNetCore.Mvc;
using Crossroads.Web.Auth.Controllers;
using Crossroads.Web.Common.Security;
using Crossroads.Web.Common.Services;
using Newtonsoft.Json;

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
      _logger.Info(JsonConvert.SerializeObject(volunteerData));
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
        try
        {
          _logger.Info($"Looking up Contact data for {authData.UserInfo.Mp.ContactId}");
          var contact = _signupService.GetContactData(authData.UserInfo.Mp.ContactId);
          return Ok(contact);
        }
        catch (Exception ex)
        {
          _logger.Error(ex, $"Error getting data for user {authData.UserInfo.Mp.ContactId}");
        }
      });
    }
  }
}