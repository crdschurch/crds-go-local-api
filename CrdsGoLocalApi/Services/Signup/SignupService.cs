﻿using System;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.ContactData;
using CrdsGoLocalApi.Repositories.HouseholdData;
using CrdsGoLocalApi.Repositories.ParticipantData;
using CrdsGoLocalApi.Repositories.ProjectData;

namespace CrdsGoLocalApi.Services.Signup
{
  public class SignupService : ISignupService
  {
    private readonly IContactDataRepository _contactDataRepository;
    private readonly IHouseholdDataRepository _householdDataRepository;
    private readonly IParticipantDataRepository _participantDataRepository;
    private readonly IProjectDataRepository _projectDataRepository;

    public SignupService(IContactDataRepository contactData, IHouseholdDataRepository householdData, IParticipantDataRepository participantData, IProjectDataRepository projectData)
    {
      _contactDataRepository = contactData;
      _householdDataRepository = householdData;
      _participantDataRepository = participantData;
      _projectDataRepository = projectData;
    }

    public bool SignupUser(VolunteerDTO signupData)
    {
      var project = _projectDataRepository.GetProject(signupData.ProjectId);
      var houseHoldId = CreateHousehold(signupData.LastName);
      var contactId = CreateContact(signupData.FirstName, 
        signupData.LastName, 
        signupData.Email, 
        signupData.BirthDate,
        houseHoldId);
      var participantId = CreateParticipant(contactId);
      var groupParticipantId = CreateGroupParticipant(participantId, project.GroupId);
      var eventParticipantId = CreateEventParticipant(participantId, groupParticipantId, project.EventId);

      return true;
    }

    public int CreateHousehold(string householdName)
    {
      var household = new Household{ HouseholdName = householdName };

      household.HouseholdId = _householdDataRepository.CreateHousehold(household);

      return household.HouseholdId;
    }

    public int CreateContact(string firstName, string lastName, string email, DateTime birthday, int householdId)
    {
      var contact = new Contact
      {
        Company = false,
        ContactStatusId = MpConstants.ActiveContactStatus,
        FirstName = firstName,
        DisplayName = $"{lastName}, {firstName}",
        LastName = lastName,
        EmailAddress = email,
        DateOfBirth = birthday,
        HouseholdId = householdId
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

    public int CreateGroupParticipant(int participantId, int? groupId)
    {
      if (groupId.HasValue)
      {
        var groupParticipant = new GroupParticipant
        {
          ParticipantId = participantId,
          GroupRoleId = MpConstants.GroupMemberRoleId,
          GroupId = groupId.GetValueOrDefault(),
          StartDate = DateTime.Now
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
  }
}
