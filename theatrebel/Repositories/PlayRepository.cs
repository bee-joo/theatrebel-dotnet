using Microsoft.EntityFrameworkCore;
using theatrebel.Data.Models;
using theatrebel.Repositories.Interfaces;

namespace theatrebel.Repositories
{
    public class PlayRepository : RepositoryBase<Play>, IPlayRepository
    {
        public PlayRepository(TheatrebelContext context) : base(context)
        {
        }

        public override async Task<Play?> FindByIdAsync(long id)
        {
            return await _context.Plays
                .Include(p => p.Writers)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Play>> FindByWriterIdAsync(long id)
        {
            return await _context.Plays
                .Where(p => p.Writers.Any(x => x.Id == id))
                .ToListAsync();
        } 
    }
}
