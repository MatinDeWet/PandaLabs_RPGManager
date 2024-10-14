namespace UnitTest.Tests.LockTests
{
    public class SessionLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly SessionLock _sessionLock;

        public SessionLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _sessionLock = new SessionLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var session = new Session { CampaignId = campaignId };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _sessionLock.HasAccess(session, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var session = new Session { CampaignId = campaignId };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _sessionLock.HasAccess(session, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var session = new Session { Id = sessionId, CampaignId = campaignId };
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session> { session }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);

            // Act
            var result = await _sessionLock.HasAccess(session, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var session = new Session { Id = sessionId, CampaignId = campaignId };
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session> { session }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);

            // Act
            var result = await _sessionLock.HasAccess(session, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsGameMaster_shouldReturnAllSessions()
        {
            // Arrange
            var identityId = 1;
            var campaignId = Guid.NewGuid();

            var session1 = new Session { Id = Guid.NewGuid(), CampaignId = campaignId, IsPrivate = false };
            var session2 = new Session { Id = Guid.NewGuid(), CampaignId = campaignId, IsPrivate = true };

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session> { session1, session2 }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _sessionLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(s => s.Id == session1.Id);
            result.Should().Contain(s => s.Id == session2.Id);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andSessionIsNotPrivate_shouldReturnSessions()
        {
            // Arrange
            var identityId = 1;
            var campaignId = Guid.NewGuid();

            var session1 = new Session { Id = Guid.NewGuid(), CampaignId = campaignId, IsPrivate = false };
            var session2 = new Session { Id = Guid.NewGuid(), CampaignId = campaignId, IsPrivate = true };

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session> { session1, session2 }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _sessionLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(s => s.Id == session1.Id);
        }
    }
}
