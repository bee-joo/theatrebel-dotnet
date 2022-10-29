using Microsoft.AspNetCore.Mvc;
using theatrebel.Data.DTOs;
using theatrebel.Data.Responses;
using theatrebel.Data.Views;
using theatrebel.Services.Interfaces;
using theatrebel.Utility;

namespace theatrebel.Controllers
{
    [ApiController]
    [Route("api/writers")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 404)]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(WriterView), 200)]
        public async Task<ActionResult<WriterView>> GetWriter(long id)
            => await _writerService.GetWriter(id);


        [HttpGet("{id}/plays")]
        [ProducesResponseType(typeof(List<EmbeddedPlayView>), 200)]
        public async Task<ActionResult<List<EmbeddedPlayView>>> GetWritersPlays(long id)
        {
            var writersPlays = await _writerService.GetWritersPlays(id);
            if (writersPlays == null || writersPlays.Count == 0)
            {
                return NotFound(new NotFoundResponse($"Writer with id {id} or plays not found"));
            }

            return writersPlays;
        }


        [HttpPost]
        [ProducesResponseType(typeof(EmbeddedWriterView), 200)]
        public async Task<ActionResult<EmbeddedWriterView>> AddWriter([FromBody] WriterDTO writerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadRequestResponse(ModelErrors.GetString(ModelState)));
            }
            return await _writerService.AddWriter(writerDto);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> DeleteWriter(long id)
            => await _writerService.DeleteWriter(id) ? true
            : BadRequest(new BadRequestResponse($"Writer with id {id} not found"));
    }
}
