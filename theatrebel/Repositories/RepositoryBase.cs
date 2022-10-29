using Microsoft.EntityFrameworkCore;
using theatrebel.Data.Models;
using theatrebel.Repositories.Interfaces.Base;

namespace theatrebel.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : ModelBase
    {
        protected readonly TheatrebelContext _context;

        protected RepositoryBase(TheatrebelContext context)
        {
            _context = context;
        }

        public bool DeleteById(long id)
        {
            var entity = _context.Set<T>().Find(id);
            if (entity != null)
            {
                _context.Set<T>().Remove(entity);
                return true;
            }

            return false;
        }

        public async Task<bool> ExistsByIdAsync(long id)
        {
            return await _context.Set<T>().AnyAsync(l => l.Id == id);
        }

        public async Task<IList<T>> FindAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IList<T> FindAllById(IList<long> ids)
        {
            return _context.Set<T>().Where(l => ids.Any(id => id == l.Id))
                                  .ToList();
        }

        public async Task<IList<T>?> FindAllByIdAsync(IList<long> ids)
        {
            return await _context.Set<T>().Where(l => ids.Any(id => id == l.Id))
                                  .ToListAsync();
        }

        public virtual async Task<T?> FindByIdAsync(long id)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public T? Save(T entity)
        {
            var entry = _context.Set<T>().Add(entity);
            return entry.Entity;
        }

        public void SaveAll(IList<T> entities)
        {
            _context.Set<T>().AddRange(entities);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
