namespace UnitTest.Tests.LockTests
{
    public class CampaignNoteLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly CampaignNoteLock _campaignNoteLock;

        public CampaignNoteLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _campaignNoteLock = new CampaignNoteLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsInCampaign_shouldReturnTrue()
        {
            // Arrange
            var campaignNote = new CampaignNote { CampaignId = Guid.NewGuid() };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignNote.CampaignId, UserId = identityId }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignNoteLock.HasAccess(campaignNote, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_andUserIsNotInCampaign_shouldReturnFalse()
        {
            // Arrange
            var campaignNote = new CampaignNote { CampaignId = Guid.NewGuid() };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignNote.CampaignId, UserId = 2 }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignNoteLock.HasAccess(campaignNote, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var note = new Note { Id = noteId, CreatedById = 2 };
            var campaignNote = new CampaignNote { CampaignId = campaignId, Note = note };

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignNoteLock.HasAccess(campaignNote, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNoteCreator_shouldReturnTrue()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var note = new Note { Id = noteId, CreatedById = identityId };
            var campaignNote = new CampaignNote { CampaignId = campaignId, Note = note };

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignNoteLock.HasAccess(campaignNote, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNotGameMasterOrNoteCreator_shouldReturnFalse()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var noteId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var note = new Note { Id = noteId, CreatedById = 2 };
            var campaignNote = new CampaignNote { CampaignId = campaignId, Note = note };

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.ToList();

            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignNoteLock.HasAccess(campaignNote, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsGameMaster_shouldReturnAllCampaignNotes()
        {
            // Arrange
            var identityId = 1;

            var campaignNotesList = new[]
            {
                new CampaignNote { CampaignId = Guid.NewGuid(), Note = new Note { IsPrivate = false } },
                new CampaignNote { CampaignId = Guid.NewGuid(), Note = new Note { IsPrivate = true, CreatedById = 2 } }
            }.ToList();

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignNotesList[0].CampaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster },
                new UserCampaign { CampaignId = campaignNotesList[1].CampaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }.ToList();

            var campaignNotes = campaignNotesList.AsQueryable().BuildMockDbSet();
            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<CampaignNote>()).Returns(campaignNotes.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _campaignNoteLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(cn => cn.CampaignId == campaignNotesList[0].CampaignId);
            result.Should().Contain(cn => cn.CampaignId == campaignNotesList[1].CampaignId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andNoteIsNotPrivate_shouldReturnCampaignNotes()
        {
            // Arrange
            var identityId = 1;

            var campaignNotesList = new[]
            {
                new CampaignNote { CampaignId = Guid.NewGuid(), Note = new Note { IsPrivate = false } },
                new CampaignNote { CampaignId = Guid.NewGuid(), Note = new Note { IsPrivate = true, CreatedById = 2 } }
            }.ToList();

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignNotesList[0].CampaignId, UserId = identityId, Role = CampaignRoleEnum.Player },
                new UserCampaign { CampaignId = campaignNotesList[1].CampaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.ToList();

            var campaignNotes = campaignNotesList.AsQueryable().BuildMockDbSet();
            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<CampaignNote>()).Returns(campaignNotes.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _campaignNoteLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(cn => cn.CampaignId == campaignNotesList[0].CampaignId);
        }

        [Fact]
        public void Secured_whenUserIsNotGameMaster_andNoteIsPrivate_andUserIsNoteCreator_shouldReturnCampaignNotes()
        {
            // Arrange
            var identityId = 1;

            var campaignNotesList = new[]
            {
                new CampaignNote { CampaignId = Guid.NewGuid(), Note = new Note { IsPrivate = true, CreatedById = identityId } },
                new CampaignNote { CampaignId = Guid.NewGuid(), Note = new Note { IsPrivate = true, CreatedById = 2 } }
            }.ToList();

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignNotesList[0].CampaignId, UserId = identityId, Role = CampaignRoleEnum.Player },
                new UserCampaign { CampaignId = campaignNotesList[1].CampaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.ToList();

            var campaignNotes = campaignNotesList.AsQueryable().BuildMockDbSet();
            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<CampaignNote>()).Returns(campaignNotes.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _campaignNoteLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(1);
            result.Should().Contain(cn => cn.CampaignId == campaignNotesList[0].CampaignId);
        }
    }
}
