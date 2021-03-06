﻿using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.ParticipantData
{
  public interface IParticipantDataRepository
  {
    int CreateParticipant(Participant participantData);
    int CreateEventParticipant(EventParticipant eventParticipantData);
    int CreateGroupParticipant(GroupParticipant groupParticipantData);
    int CreateGoLocalKids(GoLocalKids kidsData);

    int GetParticipantId(int contactId);
  }
}