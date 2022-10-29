using theatrebel.Data.Models;
using theatrebel.Repositories.Interfaces.Base;

namespace theatrebel.Repositories.Interfaces
{
    public interface IWriterRepository : IRepositoryBase<Writer> 
    {
        Task<IList<Writer>> FindByPlayIdAsync(long id);
    }
}
