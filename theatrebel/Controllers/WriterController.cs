using Microsoft.AspNetCore.Mvc;
using theatrebel.Data.DTOs;
using theatrebel.Data.Views;
using theatrebel.Services.Interfaces;

namespace theatrebel.Controllers
{
    [ApiController]
    [Route("api/writers")]
    public class WriterController : ControllerBase
    {
        private readonly IWriterService _writerService;

        public WriterController(IWriterService writerService)
        {
            _writerService = writerService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<WriterView?>> GetWriter(long id)
            => await _writerService.GetWriter(id);

        [HttpPost]
        public async Task<ActionResult<EmbeddedWriterView?>> AddWriter([FromBody] WriterDTO writerDto)
            => await _writerService.AddWriter(writerDto);

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteWriter(long id)
            => await _writerService.DeleteWriter(id);
    }
}
