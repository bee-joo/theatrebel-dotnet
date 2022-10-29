using System.Reflection.Metadata;
using theatrebel.Data.Models;
using theatrebel.Data.Parameters;

namespace theatrebel.Repositories.Interfaces
{
    public interface ISortingRepository<T, P> : IRepositoryBase<T>
        where T : ModelBase
        where P : Parameters
    {
        Task<IList<T>> FindByParamsAsync(P parameters, Pagination pagination);
    }
}
