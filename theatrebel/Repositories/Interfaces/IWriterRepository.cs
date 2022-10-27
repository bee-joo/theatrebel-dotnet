using theatrebel.Data.Models;

namespace theatrebel.Repositories.Interfaces
{
    public interface IWriterRepository : IRepositoryBase<Writer> 
    {
        Task<IList<Writer>> FindByPlayIdAsync(long id);
    }
}
