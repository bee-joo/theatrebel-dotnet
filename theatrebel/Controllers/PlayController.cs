using Microsoft.AspNetCore.Mvc;
using theatrebel.Data.DTOs;
using theatrebel.Data.Responses;
using theatrebel.Data.Views;
using theatrebel.Services.Interfaces;
using theatrebel.Utility;

namespace theatrebel.Controllers
{
    [ApiController]
    [Route("api/plays")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 404)]
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
        [ProducesResponseType(typeof(PlayView), 200)]
        public async Task<ActionResult<PlayView>> GetPlay(long id)
            => await _playService.GetPlay(id);


        [HttpGet("{id}/writers")]
        [ProducesResponseType(typeof(List<EmbeddedWriterView>), 200)]
        public async Task<ActionResult<List<EmbeddedWriterView>>> GetPlaysWriters(long id)
        {
            var playsWriters = await _playService.GetPlaysWriters(id);
            if (playsWriters == null || playsWriters.Count == 0)
            {
                return NotFound(new NotFoundResponse($"Play with id {id} or writers not found"));
            }

            return playsWriters;
        }


        [HttpGet("{id}/reviews")]
        [ProducesResponseType(typeof(List<ReviewView>), 200)]
        public async Task<ActionResult<List<ReviewView>>> GetPlaysReviews(long id)
        {
            var playsReviews = await _playService.GetPlaysReviews(id);
            if (playsReviews == null || playsReviews.Count == 0)
            {
                return NotFound(new NotFoundResponse($"Play with id {id} or reviews not found"));
            }

            return playsReviews;
        }


        [HttpPost]
        [ProducesResponseType(typeof(PlayView), 200)]
        public async Task<ActionResult<PlayView>> AddPlay([FromBody] PlayDTO playDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadRequestResponse(ModelErrors.GetString(ModelState)));
            }
            return await _playService.AddPlay(playDto);
        }


        [HttpPost("{id}/reviews")]
        [ProducesResponseType(typeof(ReviewView), 200)]
        public async Task<ActionResult<ReviewView>> AddReview(long id, [FromBody] ReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadRequestResponse(ModelErrors.GetString(ModelState)));
            }
            return await _playService.AddReview(id, reviewDto);
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> DeletePlay(long id)
            => await _playService.DeletePlay(id) ? true
            : BadRequest(new BadRequestResponse($"Play with id {id} not found"));
    }
}