using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.ParticipantData
{
  public interface IParticipantDataRepository
  {
    int CreateParticipant(Participant participantData);
    int CreateEventParticipant(EventParticipant eventParticipantData);
    int CreateGroupParticipant(GroupParticipant groupParticipantData);
  }
}