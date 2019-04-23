using System;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Services.Email;
using Crossroads.Web.Auth.Controllers;
using Crossroads.Web.Common.Security;
using Crossroads.Web.Common.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrdsGoLocalApi.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : AuthBaseController
    {
      private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();
      private readonly IEmailService _emailService;

      public EmailController(IEmailService emailService, IAuthenticationRepository authenticationRepository, IAuthTokenExpiryService authTokenExpiryService) : base(authenticationRepository, authTokenExpiryService)
      {
        _emailService = emailService;
      }

      // GET /api/email/projectlead
      [HttpGet]
      [Route("projectlead")]
      public IActionResult SendProjectLeadEmail(int initiativeId)
      {
        return Authorized(authData =>
        {
          try
          {
            if (authData.Authorization.MpRoles.ContainsKey(MpConstants.GoLocalEmailRoleId))
            {
              if (initiativeId > 0)
              {
                var emailsSent = _emailService.SendProjectLeaderEmails(initiativeId);
                return Ok($"{emailsSent} emails sent.");
              }
              return BadRequest("Invalid or missing Initiative.");
            }
            else
            {
              return Unauthorized();
            }
          }
          catch (Exception ex)
          {
            _logger.Error(ex, "Error sending project lead emails.");
            return BadRequest();
          }
        });
      }

      // GET /api/email/volunteer-reminders
      [HttpGet]
      [Route("volunteer-reminders")]
      public IActionResult SendVolunteerReminderEmails(int initiativeId)
      {
        return Authorized(authData =>
        {
          try
          {
            if (authData.Authorization.MpRoles.ContainsKey(MpConstants.GoLocalEmailRoleId))
            {
              if (initiativeId > 0)
              {
                var emailsSent = _emailService.SendVolunteersReminderEmails(initiativeId);
                return Ok($"{emailsSent} emails sent.");
              }
              return BadRequest("Invalid or missing Initiative.");
            }
            else
            {
              return Unauthorized();
            }
          }
          catch (Exception ex)
          {
            _logger.Error(ex, "Error sending project volunteer emails.");
            return BadRequest();
          }
        });
      }

    }
}