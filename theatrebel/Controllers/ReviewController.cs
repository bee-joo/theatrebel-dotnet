using Microsoft.AspNetCore.Mvc;
using theatrebel.Data.DTOs;
using theatrebel.Data.Responses;
using theatrebel.Data.Views;
using theatrebel.Services;
using theatrebel.Services.Interfaces;
using theatrebel.Utility;

namespace theatrebel.Controllers
{
    [ApiController]
    [Route("api/reviews")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(ErrorResponse), 400)]
    [ProducesResponseType(typeof(ErrorResponse), 404)]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ReviewView), 200)]
        public async Task<ActionResult<ReviewView>> GetReview(long id)
            => await _reviewService.GetReview(id);

        [HttpPost]
        [ProducesResponseType(typeof(ReviewView), 200)]
        public async Task<ActionResult<ReviewView>> AddReview([FromBody] ReviewDTO reviewDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new BadRequestResponse(ModelErrors.GetString(ModelState)));
            }
            return await _reviewService.AddReview(reviewDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult<bool>> DeleteReview(long id)
            => await _reviewService.DeleteReview(id) ? true
            : BadRequest(new BadRequestResponse($"Review with id {id} not found"));
    }
}
