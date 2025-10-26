using WebApplication52.Domain.Entity;

namespace WebApplication52.Domain.Interfaces
{
    public interface ILogicService<T>
    {
        Task<T> OrderLogic(decimal remnant, Guid customerId, List<Product> products);
    }
}
