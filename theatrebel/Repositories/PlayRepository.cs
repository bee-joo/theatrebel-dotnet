using Microsoft.EntityFrameworkCore;
using theatrebel.Data.Models;
using theatrebel.Data.Parameters;
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

        public async Task<IList<Play>> FindByParamsAsync(PlayParameters parameters, Pagination pagination) 
        {
            return await _context.Plays
                .Where(p => (parameters.Name == null || p.Name.ToLower().Contains(parameters.Name.ToLower().Trim())) &&
                            (parameters.HasText == null || p.HasText == parameters.HasText))
                .OrderBy(p => EF.Property<Play>(p, parameters.OrderBy))
                .Skip((pagination.Page - 1) * pagination.Count)
                .Take(pagination.Count)
                .ToListAsync();
        }
    }
}
