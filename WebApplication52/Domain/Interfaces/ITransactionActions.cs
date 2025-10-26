using WebApplication52.Application.Dto;

namespace WebApplication52.Domain.Interfaces
{
    public interface ITransactionActions
    {
        Task CreateOrderAsync(OrderProductDto order);
    }
}
