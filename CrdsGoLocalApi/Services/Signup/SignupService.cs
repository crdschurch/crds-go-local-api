﻿using System;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.ContactData;
using CrdsGoLocalApi.Repositories.HouseholdData;
using CrdsGoLocalApi.Repositories.ParticipantData;
using CrdsGoLocalApi.Repositories.ProjectData;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Services.Signup
{
  public class SignupService : ISignupService
  {
    private readonly IContactDataRepository _contactDataRepository;
    private readonly IHouseholdDataRepository _householdDataRepository;
    private readonly IParticipantDataRepository _participantDataRepository;
    private readonly IProjectDataRepository _projectDataRepository;

    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public SignupService(IContactDataRepository contactData, IHouseholdDataRepository householdData, IParticipantDataRepository participantData, IProjectDataRepository projectData)
    {
      _contactDataRepository = contactData;
      _householdDataRepository = householdData;
      _participantDataRepository = participantData;
      _projectDataRepository = projectData;
    }

    public bool SignupUser(VolunteerDTO signupData)
    {
      var succeeded = true;
      try
      {
        var project = _projectDataRepository.GetProject(signupData.ProjectId);
        var groupParticipantId = SignupVolunteer(signupData.FirstName, signupData.LastName, signupData.Email, signupData.PhoneNumber, signupData.BirthDate, project);
        var goLocalKidsId = CreateGoLocalKids(groupParticipantId, signupData.KidsTwoToSevenCount,signupData.KidsEightToTwelveCount);

        if (signupData.Guests?.Count > 0)
        {
          foreach (var guest in signupData.Guests)
          {
            SignupVolunteer(guest.FirstName, guest.LastName, guest.Email, null, guest.BirthDate, project, groupParticipantId);
          }
          
        }
      }
      catch (Exception ex)
      {
        Logger.Error(ex, "Error saving signup for user");
        Logger.Error(JsonConvert.SerializeObject(signupData));
        succeeded = false;
      }
      return succeeded;
    }

    public int SignupVolunteer(string firstName, string lastName, string email, string phoneNumber, DateTime birthDate, 
                               MpProject project, int? enrolledByGroupParticipantId = null)
    {
      var houseHoldId = CreateHousehold(lastName);
      var contactId = CreateContact(firstName,
                                    lastName,
                                    email,
                                    phoneNumber,
                                    birthDate,
                                    houseHoldId);
      var participantId = CreateParticipant(contactId);
      var groupParticipantId = CreateGroupParticipant(participantId, project.GroupId, enrolledByGroupParticipantId);
      var eventParticipantId = CreateEventParticipant(participantId, groupParticipantId, project.EventId);
      return groupParticipantId;
    }

    public int CreateHousehold(string householdName)
    {
      var household = new Household{ HouseholdName = householdName };

      household.HouseholdId = _householdDataRepository.CreateHousehold(household);

      return household.HouseholdId;
    }

    public int CreateContact(string firstName, string lastName, string email, string phoneNumber, 
                             DateTime birthday, int householdId)
    {
      var contact = new Contact
      {
        Company = false,
        ContactStatusId = MpConstants.ActiveContactStatus,
        FirstName = firstName,
        DisplayName = $"{lastName}, {firstName}",
        LastName = lastName,
        EmailAddress = email,
        MobilePhone = phoneNumber,
        DateOfBirth = birthday,
        HouseholdId = householdId,
        HouseholdPosition = MpConstants.HeadOfHousehold
      };

      contact.ContactId = _contactDataRepository.CreateContact(contact);

      return contact.ContactId;
    }

    public int CreateParticipant(int contactId)
    {
      var participant = new Participant
      {
        ContactId = contactId,
        ParticipantStartDate = DateTime.Now,
        ParticipantTypeId = MpConstants.TempParticipantTypeId
      };

      participant.ParticipantId = _participantDataRepository.CreateParticipant(participant);

      return participant.ParticipantId;
    }

    public int CreateGroupParticipant(int participantId, int? groupId, int? enrolledByGroupParticipant)
    {
      if (groupId.HasValue)
      {
        var groupParticipant = new GroupParticipant
        {
          ParticipantId = participantId,
          GroupRoleId = MpConstants.GroupMemberRoleId,
          GroupId = groupId.GetValueOrDefault(),
          StartDate = DateTime.Now,
          EnrolledBy = enrolledByGroupParticipant
        };

        groupParticipant.GroupParticipantId = _participantDataRepository.CreateGroupParticipant(groupParticipant);

        return groupParticipant.GroupParticipantId;
      }

      return 0;
    }

    public int CreateEventParticipant(int participantId, int groupParticipantId, int eventId)
    {
      var eventParticipant = new EventParticipant
      {
        EventId = eventId,
        GroupParticipantId = groupParticipantId,
        ParticipantId = participantId, 
        ParticipantStatus = MpConstants.RegisteredEventParticipantStatus
      };

      eventParticipant.EventParticipantId = _participantDataRepository.CreateEventParticipant(eventParticipant);

      return eventParticipant.EventParticipantId;
    }

    public int CreateGoLocalKids(int groupParticipantId, int kids2To7, int kids8To12)
    {
      if (groupParticipantId != 0 && kids2To7 + kids8To12 > 0)
      {
        var goLocalKids = new GoLocalKids
        {
          GroupParticipantId = groupParticipantId,
          TwoToSeven = kids2To7,
          EightToTwelve = kids8To12
        };

        goLocalKids.GoLocalKidsId = _participantDataRepository.CreateGoLocalKids(goLocalKids);
        return goLocalKids.GoLocalKidsId;
      }
      return 0;
    }
  }
}