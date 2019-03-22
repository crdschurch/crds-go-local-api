using System;
using CrdsGoLocalApi.Models;
using CrdsGoLocalApi.Repositories.ContactData;
using CrdsGoLocalApi.Repositories.HouseholdData;
using CrdsGoLocalApi.Repositories.ParticipantData;
using CrdsGoLocalApi.Repositories.ProjectData;
using CrdsGoLocalApi.Services.Signup;
using CrdsGoLocalApi.Tests.Helpers;
using Moq;
using Xunit;

namespace CrdsGoLocalApi.Tests.Services
{
  public class SignupServiceTests : IDisposable
  {
    private readonly Mock<IContactDataRepository> _contactDataRepository;
    private readonly Mock<IHouseholdDataRepository> _householdDataRepository;
    private readonly Mock<IParticipantDataRepository> _participantDataRepository;
    private readonly Mock<IProjectDataRepository> _projectDataRepository;

    private readonly SignupService _fixture;

    public SignupServiceTests()
    {
      _contactDataRepository = new Mock<IContactDataRepository>();
      _householdDataRepository = new Mock<IHouseholdDataRepository>();
      _participantDataRepository = new Mock<IParticipantDataRepository>();
      _projectDataRepository = new Mock<IProjectDataRepository>();
      _fixture = new SignupService(_contactDataRepository.Object, _householdDataRepository.Object, _participantDataRepository.Object, _projectDataRepository.Object);
    }

    public void Dispose()
    {
      _contactDataRepository.VerifyAll();
      _householdDataRepository.VerifyAll();
      _participantDataRepository.VerifyAll();
      _projectDataRepository.VerifyAll();
    }

    [Fact]
    public void ShouldCreateGoLocalKidsRecord()
    {
      var signupData = SignupDataHelpers.MockSignupDataWithKids();

      _projectDataRepository.Setup(m => m.GetProject(signupData.ProjectId)).Returns(SignupDataHelpers.MockProject());
      _contactDataRepository.Setup(m => m.CreateContact(It.IsAny<Contact>())).Returns(1234);
      _householdDataRepository.Setup(m => m.CreateHousehold(It.IsAny<Household>())).Returns(5678);
      _participantDataRepository.Setup(m => m.CreateParticipant(It.IsAny<Participant>())).Returns(9012);
      _participantDataRepository.Setup(m => m.CreateGroupParticipant(It.IsAny<GroupParticipant>())).Returns(3456);
      _participantDataRepository.Setup(m => m.CreateEventParticipant(It.IsAny<EventParticipant>())).Returns(7890);
      _participantDataRepository.Setup(m => m.CreateGoLocalKids(It.IsAny<GoLocalKids>())).Returns(1357);

      var result = _fixture.SignupUser(signupData);

      Assert.True(result);
    }

    [Fact]
    public void ShouldNotCreateGoLocalKidsRecord()
    {
      var signupData = SignupDataHelpers.MockSignupDataNoKids();

      _projectDataRepository.Setup(m => m.GetProject(signupData.ProjectId)).Returns(SignupDataHelpers.MockProject());
      _contactDataRepository.Setup(m => m.CreateContact(It.IsAny<Contact>())).Returns(1234);
      _householdDataRepository.Setup(m => m.CreateHousehold(It.IsAny<Household>())).Returns(5678);
      _participantDataRepository.Setup(m => m.CreateParticipant(It.IsAny<Participant>())).Returns(9012);
      _participantDataRepository.Setup(m => m.CreateGroupParticipant(It.IsAny<GroupParticipant>())).Returns(3456);
      _participantDataRepository.Setup(m => m.CreateEventParticipant(It.IsAny<EventParticipant>())).Returns(7890);

      var result = _fixture.SignupUser(signupData);

      Assert.True(result);
    }
  }
}
