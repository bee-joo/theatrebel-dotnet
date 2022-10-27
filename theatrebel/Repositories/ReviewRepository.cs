using Microsoft.EntityFrameworkCore;
using theatrebel.Data.Models;
using theatrebel.Repositories.Interfaces;

namespace theatrebel.Repositories
{
    public class ReviewRepository : RepositoryBase<Review>, IReviewRepository
    {
        public ReviewRepository(TheatrebelContext context) : base(context)
        {

        }

        public async Task<IList<Review>> FindByPlayIdAsync(long id)
        {
            return await _context.Reviews
                .Where(r => r.PlayId == id)
                .ToListAsync();
        }
    }
}
