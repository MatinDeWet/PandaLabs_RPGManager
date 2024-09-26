using Application.Features.CampaignFeatures.Commands.CreateCampaign;
using Application.Features.CampaignFeatures.Commands.DeleteCampaign;
using Application.Features.CampaignFeatures.Commands.JoinCampaignWithToken;
using Application.Features.CampaignFeatures.Commands.LeaveCampaign;
using Application.Features.CampaignFeatures.Commands.RefreshCampaignToken;
using Application.Features.CampaignFeatures.Commands.RemoveUserFromCampaign;
using Application.Features.CampaignFeatures.Commands.UpdateCampaign;
using Application.Features.CampaignFeatures.Queries.GetCampaignById;
using Application.Features.CampaignFeatures.Queries.GetCampaignUsers;
using Application.Features.CampaignFeatures.Queries.SearchCampaigns;
using Pagination.Models;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class CampaignController(ISender sender) : ControllerBase
    {
        #region Commands

        [HttpPost]
        [ProducesResponseType(typeof(CreateCampaignResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateCampaign(CreateCampaignRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteCampaign(DeleteCampaignRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> JoinCampaignWithToken(JoinCampaignWithTokenRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> LeaveCampaign(LeaveCampaignRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RefreshCampaignToken(RefreshCampaignTokenRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> RemoveUserFromCampaign(RemoveUserFromCampaignRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateCampaign(UpdateCampaignRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        #endregion

        #region Queries
        [HttpGet]
        [ProducesResponseType(typeof(GetCampaignByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCampaignById([FromQuery] GetCampaignByIdRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetCampaignUsersResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetCampaignUsers([FromQuery] GetCampaignUsersRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageableResponse<SearchCampaignsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchCampaigns(SearchCampaignsRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }
        #endregion
    }
}
