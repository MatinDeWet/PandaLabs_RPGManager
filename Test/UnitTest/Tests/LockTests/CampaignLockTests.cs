namespace UnitTest.Tests.LockTests
{
    public class CampaignLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly CampaignLock _campaignLock;

        public CampaignLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _campaignLock = new CampaignLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_shouldReturnTrue()
        {
            // Arrange
            var campaign = new Campaign { Id = Guid.NewGuid() };
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _campaignLock.HasAccess(campaign, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenUserIsGameMaster_shouldReturnTrue()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var campaign = new Campaign { Id = campaignId };

            var campaigns = new[]
            {
                campaign
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new[]
            {
                new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.GameMaster }
            }
            .AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Campaign>()).Returns(campaigns.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignLock.HasAccess(campaign, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenUserIsNotGameMaster_shouldReturnFalse()
        {
            // Arrange
            var campaignId = Guid.NewGuid();
            var operation = RepositoryOperationEnum.Update;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            var campaign = new Campaign { Id = campaignId };

            var campaigns = new[]
            {
                campaign
            }.AsQueryable().BuildMockDbSet();

            var userCampaigns = new[]
            {
            new UserCampaign { CampaignId = campaignId, UserId = identityId, Role = CampaignRoleEnum.Player }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Campaign>()).Returns(campaigns.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _campaignLock.HasAccess(campaign, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenCalled_shouldReturnCampaignsForUser()
        {
            // Arrange
            var identityId = 1;

            var campaignsList = new[]
            {
                new Campaign { Id = Guid.NewGuid() },
                new Campaign { Id = Guid.NewGuid() },
                new Campaign { Id = Guid.NewGuid() }
            };

            var userCampaignsList = new[]
            {
                new UserCampaign { CampaignId = campaignsList[0].Id, UserId = identityId },
                new UserCampaign { CampaignId = campaignsList[1].Id, UserId = identityId },
                new UserCampaign { CampaignId = campaignsList[2].Id, UserId = 2 }
            };

            var campaigns = campaignsList.AsQueryable().BuildMockDbSet();
            var userCampaigns = userCampaignsList.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<Campaign>()).Returns(campaigns.Object);
            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _campaignLock.Secured(identityId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(c => c.Id == campaignsList[0].Id);
            result.Should().Contain(c => c.Id == campaignsList[1].Id);
        }
    }
}
