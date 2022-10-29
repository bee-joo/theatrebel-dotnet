using theatrebel.Data.Models;
using theatrebel.Repositories.Interfaces.Base;

namespace theatrebel.Repositories.Interfaces
{
    public interface IReviewRepository : IRepositoryBase<Review>
    {
        Task<IList<Review>> FindByPlayIdAsync(long id);
    }
}
