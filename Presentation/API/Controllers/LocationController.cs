using Application.Common.Models;
using Application.Common.Tools;
using Application.Features.LocationFeatures.Commands.ChangeLocationPrivacy;
using Application.Features.LocationFeatures.Commands.CreateLocation;
using Application.Features.LocationFeatures.Commands.DeleteLocation;
using Application.Features.LocationFeatures.Commands.LinkLocationToHolder;
using Application.Features.LocationFeatures.Commands.UnlinkLocationFromHolder;
using Application.Features.LocationFeatures.Commands.UpdateLocation;
using Application.Features.LocationFeatures.Commands.UpdateLocationParent;
using Application.Features.LocationFeatures.Commands.UpdateLocationSubType;
using Application.Features.LocationFeatures.Queries.GetLocationById;
using Application.Features.LocationFeatures.Queries.GetLocationSubTypes;
using Application.Features.LocationFeatures.Queries.SearchHolderLocations;
using Application.Features.LocationFeatures.Queries.SearchLocations;
using Domain.Enums;
using Pagination.Models;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class LocationController(ISender sender) : ControllerBase
    {
        #region Commands
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangeLocationPrivacy([FromBody] ChangeLocationPrivacyRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateLocationResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateLocation([FromBody] CreateLocationRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteLocation([FromBody] DeleteLocationRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> LinkLocationToHolder([FromBody] LinkLocationToHolderRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UnlinkLocationFromHolder([FromBody] UnlinkLocationFromHolderRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLocation([FromBody] UpdateLocationRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLocationParent([FromBody] UpdateLocationParentRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateLocationSubType([FromBody] UpdateLocationSubTypeRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }
        #endregion

        #region Queries
        [HttpGet]
        [ProducesResponseType(typeof(List<BasicList>), StatusCodes.Status200OK)]
        public IActionResult GetLocationTypes()
        {
            var list = EnumTools.GetEnumList<LocationTypeEnum>();

            return Ok(list);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BasicList>), StatusCodes.Status200OK)]
        public IActionResult GetLocationHolders()
        {
            var list = EnumTools.GetEnumList<LocationHolderEnum>();

            return Ok(list);
        }

        [HttpGet]
        [ProducesResponseType(typeof(GetLocationByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationById([FromQuery] GetLocationByIdRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<BasicList>), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetLocationSubTypes([FromQuery] GetLocationSubTypesRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageableResponse<SearchHolderLocationsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchHolderLocations([FromBody] SearchHolderLocationsRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(PageableResponse<SearchLocationsResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchLocations([FromBody] SearchLocationsRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }
        #endregion
    }
}
