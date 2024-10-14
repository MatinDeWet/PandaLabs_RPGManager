namespace UnitTest.Tests.LockTests
{
    public class LocationLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly LocationLock _locationLock;

        public LocationLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _locationLock = new LocationLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var location = new Location { CampaignId = Guid.NewGuid() };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = location.CampaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _locationLock.HasAccess(location, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var location = new Location { CampaignId = Guid.NewGuid() };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = location.CampaignId, UserId = 2, Role = CampaignRoleEnum.Player }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _locationLock.HasAccess(location, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var locationId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var location = new Location { Id = locationId, CampaignId = campaignId };

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(new[] { location }.AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _locationLock.HasAccess(location, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var locationId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var location = new Location { Id = locationId, CampaignId = campaignId };

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(new[] { location }.AsQueryable().BuildMockDbSet().Object);

            // Act
            var result = await _locationLock.HasAccess(location, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsGameMaster_shouldReturnAllLocations()
        {
            // Arrange
            var identityId = 1;

            var locationsList = new[]
            {
                new Location { CampaignId = Guid.NewGuid(), IsPrivate = false },
                new Location { CampaignId = Guid.NewGuid(), IsPrivate = true }
            }.ToList();

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = locationsList[0].CampaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster },
                new UserCampaign { CampaignId = locationsList[1].CampaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.ToList();

            var locations = locationsList.AsQueryable().BuildMockDbSet();
            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _locationLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(l => l.CampaignId == locationsList[0].CampaignId);
            result.Should().Contain(l => l.CampaignId == locationsList[1].CampaignId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andLocationIsNotPrivate_shouldReturnLocations()
        {
            // Arrange
            var identityId = 1;

            var locationsList = new[]
            {
                new Location { CampaignId = Guid.NewGuid(), IsPrivate = false },
                new Location { CampaignId = Guid.NewGuid(), IsPrivate = true }
            }.ToList();

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = locationsList[0].CampaignId, UserId = identityId, Role = CampaignRoleEnum.Player },
                new UserCampaign { CampaignId = locationsList[1].CampaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.ToList();

            var locations = locationsList.AsQueryable().BuildMockDbSet();
            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _locationLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(l => l.CampaignId == locationsList[0].CampaignId);
        }
    }
}
