﻿using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Services.Token;
using Crossroads.Web.Common.MinistryPlatform;

namespace CrdsGoLocalApi.Repositories.ContactData
{
  public class ContactDataRepository : IContactDataRepository
  {
    private readonly ITokenService _tokenService;
    private readonly IMinistryPlatformRestRequestBuilderFactory _ministryPlatformBuilder;

    public ContactDataRepository(ITokenService tokenService, IMinistryPlatformRestRequestBuilderFactory ministryPlatformRestRequestBuilderFactory)
    {
      _tokenService = tokenService;
      _ministryPlatformBuilder = ministryPlatformRestRequestBuilderFactory;
    }

    public int CreateContact(Contact contactData)
    {
      var apiToken = _tokenService.GetClientToken();
      contactData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Create<Contact>(contactData);
      return contactData.ContactId;
    }

    public Contact GetContact(int contactId)
    {
      var apiToken = _tokenService.GetClientToken();
      var contactData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Get<Contact>(contactId);
      return contactData;
    }

    public int UpdateContact(Contact contactData)
    {
      var apiToken = _tokenService.GetClientToken();
      contactData = _ministryPlatformBuilder.NewRequestBuilder()
        .WithAuthenticationToken(apiToken)
        .Build()
        .Update(contactData);
      return contactData.ContactId;
    }
  }
}
