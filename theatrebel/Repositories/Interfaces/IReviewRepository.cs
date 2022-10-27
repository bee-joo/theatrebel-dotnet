using theatrebel.Data.Models;

namespace theatrebel.Repositories.Interfaces
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Task<IList<Review>> FindByPlayIdAsync(long id);
    }
}
