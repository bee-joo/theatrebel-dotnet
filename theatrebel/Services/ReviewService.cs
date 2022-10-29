using AutoMapper;
using theatrebel.Data.DTOs;
using theatrebel.Data.Models;
using theatrebel.Data.Views;
using theatrebel.Exceptions;
using theatrebel.Repositories.Interfaces;
using theatrebel.Services.Interfaces;

namespace theatrebel.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewView> AddReview(ReviewDTO reviewDto)
        {
            if (reviewDto.PlayId == null)
            {
                throw new BadRequestException("Play id can't be null in this case");
            }
            var review = _mapper.Map<Review>(reviewDto);
            
            var result = _reviewRepository.Save(review);
            if (result == null)
            {
                throw new BadRequestException("Something went wrong with this review");
            }
            await _reviewRepository.SaveChangesAsync();
            return _mapper.Map<ReviewView>(result);
        }

        public async Task<bool> DeleteReview(long id)
        {
            if (_reviewRepository.DeleteById(id))
            {
                await _reviewRepository.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<ReviewView> GetReview(long id)
        {
            var review = await _reviewRepository.FindByIdAsync(id);
            if (review == null)
            {
                throw new NotFoundException($"Review with id {id} not found!");
            }
            return _mapper.Map<ReviewView>(review);
        }
    }
}
