using Application.Features.SessionFeatures.Commands.ChangeSessionPrivacy;
using Application.Features.SessionFeatures.Commands.CreateSession;
using Application.Features.SessionFeatures.Commands.DeleteSession;
using Application.Features.SessionFeatures.Commands.UpdateSession;
using Application.Features.SessionFeatures.Queries.GetSessionById;
using Application.Features.SessionFeatures.Queries.SearchSessions;
using Pagination.Models;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class SessionController(ISender sender) : ControllerBase
    {
        #region Commands
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangeSessionPrivacy(ChangeSessionPrivacyRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateSessionResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateSession(CreateSessionRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteSession(DeleteSessionRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateSession(UpdateSessionRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }
        #endregion

        #region Queries
        [HttpGet]
        [ProducesResponseType(typeof(GetSessionByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetSessionById([FromQuery] GetSessionByIdRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageableResponse<SearchSessionsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchSessions([FromBody] SearchSessionsRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }
        #endregion
    }
}
