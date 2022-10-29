using theatrebel.Data.DTOs;
using theatrebel.Data.Parameters;
using theatrebel.Data.Views;

namespace theatrebel.Services.Interfaces
{
    public interface IPlayService
    {
        Task<PlayView> GetPlay(long id);
        Task<List<EmbeddedPlayView>> SearchPlays(PlayParameters parameters, Pagination pagination);
        Task<List<EmbeddedWriterView>?> GetPlaysWriters(long id);
        Task<List<ReviewView>> GetPlaysReviews(long id);
        Task<PlayView> AddPlay(PlayDTO playDto);
        Task<ReviewView> AddReview(long playId, ReviewDTO reviewDto);
        Task<bool> DeletePlay(long id);
    }
}
