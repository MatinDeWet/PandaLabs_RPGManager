namespace UnitTest.Tests.LockTests
{
    public class UserCampaignLockTests
    {
        private readonly Mock<ManagerContext> _mockContext;
        private readonly UserCampaignLock _userCampaignLock;

        public UserCampaignLockTests()
        {
            _mockContext = new Mock<ManagerContext>();
            _userCampaignLock = new UserCampaignLock(_mockContext.Object);
        }

        [Fact]
        public async Task HasAccess_whenOperationIsInsert_shouldReturnTrue()
        {
            // Arrange
            var userCampaign = new UserCampaign();
            var operation = RepositoryOperationEnum.Insert;
            var identityId = 1;
            var cancellationToken = CancellationToken.None;

            // Act
            var result = await _userCampaignLock.HasAccess(userCampaign, operation, identityId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsInCampaign_shouldReturnTrue()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var userCampaign = new UserCampaign { UserId = userId, CampaignId = campaignId };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _userCampaignLock.HasAccess(userCampaign, operation, userId, cancellationToken);

            // Assert
            result.Should().BeTrue();
        }

        [Fact]
        public async Task HasAccess_whenOperationIsNotInsert_andUserIsNotInCampaign_shouldReturnFalse()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();
            var userCampaign = new UserCampaign { UserId = userId, CampaignId = campaignId };
            var operation = RepositoryOperationEnum.Update;
            var cancellationToken = CancellationToken.None;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = 2, CampaignId = campaignId }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = await _userCampaignLock.HasAccess(userCampaign, operation, userId, cancellationToken);

            // Assert
            result.Should().BeFalse();
        }

        [Fact]
        public void Secured_whenUserIsInCampaign_shouldReturnUserCampaigns()
        {
            // Arrange
            var userId = 1;
            var campaignId = Guid.NewGuid();

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = userId, CampaignId = campaignId },
                new UserCampaign { UserId = userId, CampaignId = Guid.NewGuid() }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _userCampaignLock.Secured(userId);

            // Assert
            result.Should().HaveCount(2);
            result.Should().Contain(uc => uc.CampaignId == campaignId);
        }

        [Fact]
        public void Secured_whenUserIsNotInCampaign_shouldReturnEmpty()
        {
            // Arrange
            var userId = 1;

            var userCampaigns = new List<UserCampaign>
            {
                new UserCampaign { UserId = 2, CampaignId = Guid.NewGuid() }
            }.AsQueryable().BuildMockDbSet();

            _mockContext.Setup(c => c.Set<UserCampaign>()).Returns(userCampaigns.Object);

            // Act
            var result = _userCampaignLock.Secured(userId);

            // Assert
            result.Should().BeEmpty();
        }
    }
}
