﻿namespace CrdsGoLocalApi.Services.Email
{
  public interface IEmailService
  {
    int SendProjectLeaderEmails(int initiativeId);
  }
}