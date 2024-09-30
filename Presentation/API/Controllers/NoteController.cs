using Application.Features.NoteFeatures.Commands.ChangeNotePrivacy;
using Application.Features.NoteFeatures.Commands.CreateNote;
using Application.Features.NoteFeatures.Commands.DeleteNote;
using Application.Features.NoteFeatures.Commands.UpdateNote;
using Application.Features.NoteFeatures.Queries.GetNoteById;
using Application.Features.NoteFeatures.Queries.SearchNotes;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class NoteController(ISender sender) : ControllerBase
    {
        #region Commands
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> ChangeNotePrivacy([FromBody] ChangeNotePrivacyRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(typeof(CreateNoteResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateNote([FromBody] CreateNoteRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteNote([FromBody] DeleteNoteRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdateNote([FromBody] UpdateNoteRequest request)
        {
            await sender.Send(request);

            return NoContent();
        }
        #endregion

        #region Queries
        [HttpGet]
        [ProducesResponseType(typeof(GetNoteByIdResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetNoteById([FromQuery] GetNoteByIdRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }

        //[HttpGet]
        //[ProducesResponseType(typeof(List<BasicList>), StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetNoteHolders()
        //{
        //    var request = new GetNoteHoldersRequest();

        //    var response = await sender.Send(request);

        //    return Ok(response);
        //}

        [HttpPost]
        [ProducesResponseType(typeof(SearchNotesResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> SearchNotes([FromBody] SearchNotesRequest request)
        {
            var response = await sender.Send(request);

            return Ok(response);
        }
        #endregion
    }
}
