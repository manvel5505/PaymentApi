namespace WebApplication52.Domain.Interfaces
{
    public interface IReadServices<T, ID>
    {
        Task<T> GetByIdAsync(ID id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
