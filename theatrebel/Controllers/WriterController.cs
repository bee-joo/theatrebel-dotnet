using Microsoft.AspNetCore.Mvc;
using theatrebel.Data.DTOs;
using theatrebel.Data.Responses;
using theatrebel.Data.Views;
using theatrebel.Services.Interfaces;

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
        public async Task<ActionResult<WriterView?>> GetWriter(long id)
            => await _writerService.GetWriter(id);

        [HttpPost]
        [ProducesResponseType(typeof(EmbeddedWriterView), 200)]
        public async Task<ActionResult<EmbeddedWriterView?>> AddWriter([FromBody] WriterDTO writerDto)
            => await _writerService.AddWriter(writerDto);

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> DeleteWriter(long id)
            => await _writerService.DeleteWriter(id) ? true
            : BadRequest(new BadRequestResponse($"Writer with id {id} not found"));
    }
}
