using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Infrastructure.Database;

namespace WebApplication52.Infrastructure.Services
{
    public class TransactionService : ITransactionActions
    {
        private readonly IMapper mapper;
        private readonly ILogger<TransactionService> logger;
        private readonly MainDatabase data;
        private readonly ILogicService<Customer> logicService;
        public TransactionService(IMapper mapper, ILogger<TransactionService> logger, MainDatabase data, ILogicService<Customer> logicService)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.data = data;
            this.logicService = logicService;
        }
        public async Task CreateOrderAsync(OrderProductDto order)
        {
            if (order == null)
            {
                logger.LogError(nameof(order) + " order is null!");
                throw new ArgumentNullException(nameof(order) + " order cant be null!");
            }

            var products = mapper.Map<List<Product>>(order.Product);
            var customerId = order.Customer.CustomerId;
            decimal remnant = 0.01m;

            using var transaction = data.Database.BeginTransaction();

            try
            {
                var logic = await logicService.OrderLogic(remnant, customerId, products);

                data.customers.Update(logic);

                await data.SaveChangesAsync();
                await transaction.CommitAsync();

                logger.LogInformation("Order successfully created for customer {CustomerId}", customerId);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                logger.LogError(ex, "Transaction faild for customer {CustomerId}", customerId);
                throw;
            }
        }
    }
}
