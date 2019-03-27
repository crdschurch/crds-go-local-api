﻿using System;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.ContactData;
using CrdsGoLocalApi.Repositories.Email;
using CrdsGoLocalApi.Repositories.HouseholdData;
using CrdsGoLocalApi.Repositories.ParticipantData;
using CrdsGoLocalApi.Repositories.ProjectData;
using Newtonsoft.Json;

namespace CrdsGoLocalApi.Services.Signup
{
  public class SignupService : ISignupService
  {
    private readonly IContactDataRepository _contactDataRepository;
    private readonly IEmailRepository _emailRepository;
    private readonly IHouseholdDataRepository _householdDataRepository;
    private readonly IParticipantDataRepository _participantDataRepository;
    private readonly IProjectDataRepository _projectDataRepository;

    private static readonly NLog.Logger Logger = NLog.LogManager.GetCurrentClassLogger();

    public SignupService(IContactDataRepository contactData, IEmailRepository emailRepository, IHouseholdDataRepository householdData, IParticipantDataRepository participantData, IProjectDataRepository projectData)
    {
      _contactDataRepository = contactData;
      _emailRepository = emailRepository;
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
        var mainVolunteer = SignupVolunteer(signupData.FirstName, signupData.LastName, signupData.Email, signupData.PhoneNumber, signupData.BirthDate, project, null, null, signupData.ContactId);
        var goLocalKidsId = CreateGoLocalKids(mainVolunteer.GroupParticipantId, signupData.KidsTwoToSevenCount,signupData.KidsEightToTwelveCount);

        if (signupData.Guests?.Count > 0)
        {
          foreach (var guest in signupData.Guests)
          {
            SignupVolunteer(guest.FirstName, guest.LastName, guest.Email, null, guest.BirthDate, project, mainVolunteer, guest.HouseholdPositionId);
          }
          
        }
        succeeded = _emailRepository.SendConfirmationEmail(project, signupData, mainVolunteer.ContactId);
      }
      catch (Exception ex)
      {
        Logger.Error(ex, "Error saving signup for user");
        Logger.Error(JsonConvert.SerializeObject(signupData));
        succeeded = false;
      }
      return succeeded;
    }

    public ContactDTO GetContactData(int contactId)
    {
      var contactData = _contactDataRepository.GetContact(contactId);
      var contact = new ContactDTO
      {
        ContactId = contactData.ContactId,
        FirstName = contactData.FirstName,
        LastName = contactData.LastName,
        Email = contactData.EmailAddress,
        BirthDate = contactData.DateOfBirth,
        PhoneNumber = contactData.MobilePhone
      };
      return contact;
    }

    public NewVolunteer SignupVolunteer(string firstName, string lastName, string email, string phoneNumber, 
      DateTime birthDate, MpProject project, NewVolunteer mainVolunteer = null, int? householdPostionId = null, int? contactId = null)
    {
      var newVol = new NewVolunteer();
      if (contactId == null)
      {
        if (householdPostionId.HasValue && mainVolunteer?.HouseholdId > 0)
        {
          newVol.HouseholdId = mainVolunteer.HouseholdId;
        }
        else
        {
          newVol.HouseholdId = CreateHousehold(lastName);
        }
        newVol.ContactId = CreateContact(firstName,
          lastName,
          email,
          phoneNumber,
          birthDate,
          newVol.HouseholdId,
          householdPostionId);
        newVol.ParticipantId = CreateParticipant(newVol.ContactId);
      }
      else
      {
        newVol.ContactId = UpdateContact(contactId.Value, birthDate, phoneNumber);
        newVol.HouseholdId = GetHouseholdId(newVol.ContactId);
        newVol.ParticipantId = GetParticipantId(newVol.ContactId);
      }
     
      newVol.GroupParticipantId = CreateGroupParticipant(newVol.ParticipantId, project.GroupId, mainVolunteer?.GroupParticipantId);
      var eventParticipantId = CreateEventParticipant(newVol.ParticipantId, newVol.GroupParticipantId, project.EventId);
      return newVol;
    }

    public int CreateHousehold(string householdName)
    {
      var household = new Household{ HouseholdName = householdName };

      household.HouseholdId = _householdDataRepository.CreateHousehold(household);

      return household.HouseholdId;
    }

    public int CreateContact(string firstName, string lastName, string email, string phoneNumber, 
                             DateTime birthday, int householdId, int? householdPositionId)
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
        HouseholdPosition = householdPositionId ?? MpConstants.HeadOfHousehold
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

    public int UpdateContact(int contactId, DateTime birthday, string mobilePhone)
    {
      var contact = _contactDataRepository.GetContact(contactId);
      contact.DateOfBirth = birthday;
      contact.MobilePhone = mobilePhone;
      _contactDataRepository.UpdateContact(contact);
      return contactId;
    }

    public int GetParticipantId(int contactId)
    {
      var participantId = _participantDataRepository.GetParticipantId(contactId);
      return participantId;
    }

    public int GetHouseholdId(int contactId)
    {
      var householdId = _householdDataRepository.GetHouseholdId(contactId);
      return householdId;
    }
  }
}
