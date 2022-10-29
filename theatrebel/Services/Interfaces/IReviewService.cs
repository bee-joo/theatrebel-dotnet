using theatrebel.Data.DTOs;
using theatrebel.Data.Views;

namespace theatrebel.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewView> GetReview(long id);
        Task<ReviewView> AddReview(ReviewDTO reviewDto);
        Task<bool> DeleteReview(long id);
    }
}
