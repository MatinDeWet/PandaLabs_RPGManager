namespace UnitTest.Tests.LockTests
{
    public class SessionLocationLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly SessionLocationLock _sessionLocationLock;

        public SessionLocationLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _sessionLocationLock = new SessionLocationLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenUserIsInCampaign_shouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var sessionId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var sessionLocation = new SessionLocation { SessionId = sessionId };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _sessionLocationLock.HasAccess(sessionLocation, operation, userId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenUserIsNotInCampaign_shouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var sessionId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var sessionLocation = new SessionLocation { SessionId = sessionId };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = 2, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _sessionLocationLock.HasAccess(sessionLocation, operation, userId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsGameMaster_shouldReturnAllSessionLocations()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var locationId = Guid.NewGuid();

            var sessionLocations = new List<SessionLocation>
            {
                new SessionLocation { SessionId = sessionId, LocationId = locationId }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            var locations = new List<Location>
            {
                new Location { Id = locationId, IsPrivate = false }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<SessionLocation>()).Returns(sessionLocations.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);

            // Act
            var result = _sessionLocationLock.Secured(userId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(sl => sl.SessionId == sessionId && sl.LocationId == locationId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andLocationIsNotPrivate_shouldReturnSessionLocations()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var locationId = Guid.NewGuid();

            var sessionLocations = new List<SessionLocation>
            {
                new SessionLocation { SessionId = sessionId, LocationId = locationId }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            var locations = new List<Location>
            {
                new Location { Id = locationId, IsPrivate = false }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<SessionLocation>()).Returns(sessionLocations.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);

            // Act
            var result = _sessionLocationLock.Secured(userId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(sl => sl.SessionId == sessionId && sl.LocationId == locationId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andLocationIsPrivate_shouldReturnEmpty()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var locationId = Guid.NewGuid();

            var sessionLocations = new List<SessionLocation>
            {
                new SessionLocation { SessionId = sessionId, LocationId = locationId }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            var locations = new List<Location>
            {
                new Location { Id = locationId, IsPrivate = true }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<SessionLocation>()).Returns(sessionLocations.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);

            // Act
            var result = _sessionLocationLock.Secured(userId);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
