using Microsoft.EntityFrameworkCore;
using theatrebel.Data.Models;
using theatrebel.Repositories.Interfaces;

namespace theatrebel.Repositories
{
    public class WriterRepository : RepositoryBase<Writer>, IWriterRepository
    {
        public WriterRepository(TheatrebelContext context) : base(context)
        {
        }

        public override async Task<Writer?> FindByIdAsync(long id)
        {
            return await _context.Writers
                .Include(w => w.Plays)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<Writer>> FindByPlayIdAsync(long id)
        {
            return await _context.Writers
                .Where(w => w.Plays.Any(x => x.Id == id))
                .ToListAsync();
        }
    }
}
