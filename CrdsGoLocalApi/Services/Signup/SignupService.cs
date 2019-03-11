using System;
using CrdsGoLocalApi.Constants;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.HouseholdData;
using CrdsGoLocalApi.Repositories.ProjectData;

namespace CrdsGoLocalApi.Services.Signup
{
  public class SignupService : ISignupService
  {
    private readonly IProjectDataRepository _projectDataRepository;
    private readonly IHouseholdDataRepository _householdDataRepository;

    public SignupService(IProjectDataRepository projectData, IHouseholdDataRepository householdData)
    {
      _projectDataRepository = projectData;
      _householdDataRepository = householdData;
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
        FirstName = firstName,
        Nickname = firstName,
        LastName = lastName,
        EmailAddress = email,
        DateOfBirth = birthday,
        HouseholdId = householdId
      };

      // TODO: Create Contact Record

      return contact.ContactId;
    }

    public int CreateParticipant(int contactId)
    {
      var participant = new Participant
      {
        ContactId = contactId,
        ParticipantStartDate = DateTime.Now,
        ParticipantType = MpConstants.TempParticipantTypeId
      };

      // TODO: Create Participant Record

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

        // TODO: Create Group Participant Record

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

      // TODO: Create Event Participant

      return eventParticipant.EventParticipantId;
    }
  }
}
