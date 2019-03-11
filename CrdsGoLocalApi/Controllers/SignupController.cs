using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Signup;
using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
    [Route("api/signup")]
    [ApiController]
    public class SignupController : ControllerBase
    {
      private readonly ISignupService _signupService;

      public SignupController(ISignupService signupService)
      {
        _signupService = signupService;
      }

      [HttpPost]
      [Route("submit")]
      public IActionResult SignupVolunteer(VolunteerDTO volunteerData)
      {
        var success = _signupService.SignupUser(volunteerData);
        if (success)
        {
          return Ok();
        }
        return BadRequest();
      }
    }
}