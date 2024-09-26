using Application.Common.Tools;
using Domain.Enums;

namespace Application.Features.CampaignFeatures.Commands.CreateCampaign
{
    public class CreateCampaignHandler(ICampaignRepository repo, IIdentityInfo identityInfo, IUnitOfWork unitOfWork)
        : ICommandHandler<CreateCampaignRequest, CreateCampaignResponse>
    {
        public async Task<CreateCampaignResponse> Handle(CreateCampaignRequest request, CancellationToken cancellationToken)
        {
            var campaign = new Campaign
            {
                Title = request.Title
            };

            campaign.Users.Add(new UserCampaign
            {
                UserId = identityInfo.GetIdentityId(),
                Role = CampaignRoleEnum.GameMaster
            });

            campaign.Token = StringTools.GenerateSecureString(20);

            await repo.InsertAsync(campaign, cancellationToken);

            await unitOfWork.SaveAsync(cancellationToken);

            return new CreateCampaignResponse(campaign.Id);
        }
    }
}
