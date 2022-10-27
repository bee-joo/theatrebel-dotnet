using Microsoft.AspNetCore.Mvc;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;
using theatrebel.Services.Interfaces;

namespace theatrebel.Controllers
{
    [ApiController]
    [Route("api/plays")]
    public class PlayController : ControllerBase
    {
        private readonly IPlayService _playService;
        private readonly ILogger _logger;

        public PlayController(ILogger<PlayController> logger, IPlayService playService)
        {
            _logger = logger;
            _playService = playService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PlayView>> GetPlay(long id)
            => await _playService.GetPlay(id);

        [HttpGet("{id}/writers")]
        public async Task<ActionResult<List<EmbeddedWriterView>>> GetPlaysWriters(long id)
        {
            var playsWriters = await _playService.GetPlaysWriters(id);
            if (playsWriters == null || !playsWriters.Any())
            {
                return NotFound();
            }

            return playsWriters;
        }

        [HttpGet("{id}/reviews")]
        public async Task<ActionResult<List<ReviewView>>> GetPlaysReviews(long id)
            => await _playService.GetPlaysReviews(id);

        [HttpPost]
        public async Task<ActionResult<PlayView>> AddPlay([FromBody] PlayDTO playDto)
        {
            if (ModelState.IsValid)
            {
                return await _playService.AddPlay(playDto);
            }
            return BadRequest("Invalid data");
        }

        [HttpPost("{id}/reviews")]
        public async Task<ActionResult<ReviewView>> AddReview(long id, [FromBody] ReviewDTO reviewDto)
        {
            if (ModelState.IsValid)
            {
                return await _playService.AddReview(id, reviewDto);
            }
            return BadRequest("Invalid data");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlay(long id)
            => await _playService.DeletePlay(id) ? Ok(true) : BadRequest($"Play with id {id} not found");
    }
}