namespace UnitTest.Tests.LockTests
{
    public class LocationNoteLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly LocationNoteLock _locationNoteLock;

        public LocationNoteLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _locationNoteLock = new LocationNoteLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsInCampaign_shouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var locationId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var locationNote = new LocationNote { LocationId = locationId };
            var operation = RepositoryOperationEnum.Insert;
            var cancellationToken = CancellationToken.None;

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _locationNoteLock.HasAccess(locationNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsNotInCampaign_shouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var locationId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var locationNote = new LocationNote { LocationId = locationId };
            var operation = RepositoryOperationEnum.Insert;
            var cancellationToken = CancellationToken.None;

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = 2, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _locationNoteLock.HasAccess(locationNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var locationId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var locationNote = new LocationNote { LocationId = locationId, Note = new Note { Id = noteId, CreatedById = userId } };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _locationNoteLock.HasAccess(locationNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var locationId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var locationNote = new LocationNote { LocationId = locationId, Note = new Note { Id = noteId, CreatedById = 2 } };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = 2, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _locationNoteLock.HasAccess(locationNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsGameMaster_shouldReturnAllLocationNotes()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var locationId = Guid.NewGuid();
            var noteId = Guid.NewGuid();

            var locationNotes = new List<LocationNote>
            {
                new LocationNote { LocationId = locationId, Note = new Note { Id = noteId, IsPrivate = false } }
            }.AsQueryable().BuildMockDbSet();

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<LocationNote>()).Returns(locationNotes.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _locationNoteLock.Secured(userId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(ln => ln.LocationId == locationId && ln.Note.Id == noteId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andNoteIsNotPrivate_shouldReturnLocationNotes()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var locationId = Guid.NewGuid();
            var noteId = Guid.NewGuid();

            var locationNotes = new List<LocationNote>
            {
                new LocationNote { LocationId = locationId, Note = new Note { Id = noteId, IsPrivate = false } }
            }.AsQueryable().BuildMockDbSet();

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<LocationNote>()).Returns(locationNotes.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _locationNoteLock.Secured(userId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(ln => ln.LocationId == locationId && ln.Note.Id == noteId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andNoteIsPrivate_shouldReturnEmpty()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var locationId = Guid.NewGuid();
            var noteId = Guid.NewGuid();

            var locationNotes = new List<LocationNote>
            {
                new LocationNote { LocationId = locationId, Note = new Note { Id = noteId, IsPrivate = true } }
            }.AsQueryable().BuildMockDbSet();

            var locations = new List<Location>
            {
                new Location { Id = locationId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<LocationNote>()).Returns(locationNotes.Object);
            _mockContext.Setup(c => c.Set<Location>()).Returns(locations.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _locationNoteLock.Secured(userId);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
