using theatrebel.Data.Models;
using theatrebel.Data.Parameters;

namespace theatrebel.Repositories.Interfaces
{
    public interface IPlayRepository : IRepositoryBase<Play>, ISortingRepository<Play, PlayParameters>
    {
        Task<IList<Play>> FindByWriterIdAsync(long id);
    }
}
