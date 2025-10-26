namespace WebApplication52.Domain.Interfaces
{
    public interface IWriteService<T, ID>
    {
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(ID id, T entity);
        Task<T> DeleteAsync(ID id);
    }
}
