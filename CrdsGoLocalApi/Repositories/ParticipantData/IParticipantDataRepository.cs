using CrdsGoLocalApi.Models;

namespace CrdsGoLocalApi.Repositories.ParticipantData
{
  public interface IParticipantDataRepository
  {
    int CreateParticipant(Participant participantData);
  }
}