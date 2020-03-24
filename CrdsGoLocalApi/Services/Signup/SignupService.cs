using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
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
    private readonly IMapper _mapper;

    private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

    public SignupService(IContactDataRepository contactData, IEmailRepository emailRepository,
      IHouseholdDataRepository householdData, IParticipantDataRepository participantData,
      IProjectDataRepository projectData, IMapper mapper)
    {
      _contactDataRepository = contactData;
      _emailRepository = emailRepository;
      _householdDataRepository = householdData;
      _participantDataRepository = participantData;
      _projectDataRepository = projectData;
      _mapper = mapper;
    }

    public bool SignupUser(VolunteerDTO signupData)
    {
      var succeeded = true;
      try
      {
        var project = _projectDataRepository.GetProject(signupData.ProjectId);
        var groupParticipantId = SignupVolunteer( project, signupData.ContactId, null);
        var goLocalKidsId = CreateGoLocalKids(groupParticipantId, signupData.KidsTwoToSevenCount,
          signupData.KidsEightToTwelveCount);

        if (signupData.FamilyMembers?.Count > 0)
        {
          _logger.Info("Signing up guests...");
          try
          {
            foreach (var member in signupData.FamilyMembers)
            {
              SignupVolunteer(project, member.ContactId, groupParticipantId);
            }
          }
          catch (Exception exc) {
            _logger.Error("Failed to sign up guests");
          }
        }
        succeeded = _emailRepository.SendConfirmationEmail(project, signupData, signupData.ContactId);
      }
      catch (Exception ex)
      {
        _logger.Error(ex, "Error saving signup for user");
        _logger.Error(JsonConvert.SerializeObject(signupData));
        succeeded = false;
      }
      return succeeded;
    }

    public FamilyDTO GetVolunteerData(int contactId)
    {
      var contactData = _contactDataRepository.GetContact(contactId);

      var allHouseholdMembers = _householdDataRepository.GetHouseholdMembers(contactData.HouseholdId);
      var validHouseholdMembers = allHouseholdMembers.Where(FilterHouseholdMembers)
                                            .Where(fm => fm.ContactId != contactData.ContactId)
                                            .ToList();
      var familyData = new FamilyDTO
      {
        MainVolunteer = _mapper.Map<Contact, ContactDTO>(contactData),
        FamilyMembers = _mapper.Map<List<Contact>, List<ContactDTO>>(validHouseholdMembers)
      };

      return familyData;
    }

    public int SignupVolunteer( MpProject project, int contactId, int? enrolledByGroupParticipant = null)
    {
      _logger.Info("Attempting to sign up volunteer...");
      try {
        var participantId = GetParticipantId(contactId);
        var groupParticipantId =
          CreateGroupParticipant(participantId, project.GroupId, enrolledByGroupParticipant);
        CreateEventParticipant(participantId, groupParticipantId, project.EventId);
        return groupParticipantId;
      }
      catch (Exception exc) {
        _logger.Error($"Failed to signup volunteer, exc: {exc}");
        throw;
      }
    }

    public int CreateHousehold(string householdName)
    {
      var household = new Household {HouseholdName = householdName};

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
      _logger.Info($"Creating GOLocal kids...");
      try
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
      catch (Exception exc)
      {
        _logger.Error($"Failed to CreateGoLocalKids, exc: {exc}");
        throw;
      }
    }

    public int UpdateContact(int contactId, DateTime birthday, string mobilePhone)
    {
      var contact = _contactDataRepository.GetContact(contactId);
      var needsUpdate = false;
      if (contact.DateOfBirth != birthday)
      {
        contact.DateOfBirth = birthday;
        needsUpdate = true;
      }
      if (contact.MobilePhone != mobilePhone)
      {
        contact.MobilePhone = mobilePhone;
        needsUpdate = true;
      }
      if (needsUpdate)
      {
        _contactDataRepository.UpdateContact(contact);
      }
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

    public int? CheckIfGuestIsInHousehold(GuestContact guest, List<HouseholdMembers> household)
    {
      return household.FirstOrDefault(h =>
        h.FirstName == guest.FirstName &&
        h.LastName == guest.LastName &&
        h.DateOfBirth?.Date == guest.BirthDate.Date)?.ContactId;
    }

    private Boolean FilterHouseholdMembers(Contact householdMember)
    {
        // Head Of Household: 1, MinorChild: 2, Adult Child: 4, Head of Household Spouse: 7
        int[] householdPositionId = {1, 2, 4, 7};
        if (!householdMember.DateOfBirth.HasValue) return false;
        
        var age = DateTime.Today.Year - householdMember.DateOfBirth.Value.Year;
        if (householdMember.DateOfBirth?.Date > DateTime.Today.AddYears(-age)) age -= 1;

        // person needs to be 13 or older and either a suppose or a child  
        return age >= 13 && householdPositionId.Contains(householdMember.HouseholdPosition);
    }
  }
}