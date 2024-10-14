namespace UnitTest.Tests.LockTests
{
    public class SessionNoteLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly SessionNoteLock _sessionNoteLock;

        public SessionNoteLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _sessionNoteLock = new SessionNoteLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsInCampaign_shouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var sessionId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var sessionNote = new SessionNote { SessionId = sessionId };
            var operation = RepositoryOperationEnum.Insert;
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
            var result = await _sessionNoteLock.HasAccess(sessionNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsNotInCampaign_shouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var sessionId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var sessionNote = new SessionNote { SessionId = sessionId };
            var operation = RepositoryOperationEnum.Insert;
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
            var result = await _sessionNoteLock.HasAccess(sessionNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var sessionId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var sessionNote = new SessionNote { SessionId = sessionId, Note = new Note { Id = noteId, CreatedById = userId } };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _sessionNoteLock.HasAccess(sessionNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var sessionId = Guid.NewGuid();
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var sessionNote = new SessionNote { SessionId = sessionId, Note = new Note { Id = noteId, CreatedById = 2 } };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = 2, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _sessionNoteLock.HasAccess(sessionNote, operation, userId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsGameMaster_shouldReturnAllSessionNotes()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var noteId = Guid.NewGuid();

            var sessionNotes = new List<SessionNote>
            {
                new SessionNote { SessionId = sessionId, Note = new Note { Id = noteId, IsPrivate = false } }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.GameMaster }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<SessionNote>()).Returns(sessionNotes.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _sessionNoteLock.Secured(userId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(sn => sn.SessionId == sessionId && sn.Note.Id == noteId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andNoteIsNotPrivate_shouldReturnSessionNotes()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var noteId = Guid.NewGuid();

            var sessionNotes = new List<SessionNote>
            {
                new SessionNote { SessionId = sessionId, Note = new Note { Id = noteId, IsPrivate = false } }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<SessionNote>()).Returns(sessionNotes.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _sessionNoteLock.Secured(userId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(sn => sn.SessionId == sessionId && sn.Note.Id == noteId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andNoteIsPrivate_shouldReturnEmpty()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var sessionId = Guid.NewGuid();
            var noteId = Guid.NewGuid();

            var sessionNotes = new List<SessionNote>
            {
                new SessionNote { SessionId = sessionId, Note = new Note { Id = noteId, IsPrivate = true } }
            }.AsQueryable().BuildMockDbSet();

            var sessions = new List<Session>
            {
                new Session { Id = sessionId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<SessionNote>()).Returns(sessionNotes.Object);
            _mockContext.Setup(c => c.Set<Session>()).Returns(sessions.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _sessionNoteLock.Secured(userId);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
