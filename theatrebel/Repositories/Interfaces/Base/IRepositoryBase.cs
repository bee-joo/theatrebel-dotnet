namespace theatrebel.Repositories.Interfaces.Base
{
    public interface IRepositoryBase<T>
    {
        Task<T?> FindByIdAsync(long id);
        Task<IList<T>> FindAllAsync();
        Task<IList<T>?> FindAllByIdAsync(IList<long> ids);
        IList<T> FindAllById(IList<long> ids);
        T? Save(T entity);
        Task<bool> ExistsByIdAsync(long id);
        void SaveAll(IList<T> entities);
        bool DeleteById(long id);
        Task SaveChangesAsync();
    }
}
