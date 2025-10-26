using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Domain.Value_Object;
using WebApplication52.Infrastructure.Database;

namespace WebApplication52.Domain.Logic
{
    public class LogicService : ILogicService<Customer> 
    { 
        private readonly ILogger<LogicService> logger;
        private readonly IReadServices<Customer, Guid> readCustomer;
        private readonly IReadServices<Product, int> readProduct;
        private readonly IWriteService<Customer, Guid> writeCustomer;
        private readonly IWriteService<Product, int> writeProduct; 
        public LogicService(ILogger<LogicService> logger, 
            IReadServices<Customer, Guid> readCustomer, 
            IReadServices<Product, int> readProduct,
            IWriteService<Customer, Guid> writeCustomer,
            IWriteService<Product, int> writeProduct) 
        { 
            this.logger = logger;
            this.readCustomer = readCustomer; 
            this.readProduct = readProduct;
            this.writeCustomer = writeCustomer;
            this.writeProduct = writeProduct; 
        }
        public async Task<Customer> OrderLogic(decimal remnant, Guid customerId, List<Product> products)
        { 
            var customer = await readCustomer.GetByIdAsync(customerId); 
            
            if (customer == null) 
            {
                logger.LogError(nameof(customer) + " Customer is null!"); 
                throw new ArgumentNullException(nameof(customer) + " Customer cannot be null!"); 
            } 

            var total = products.Sum(x => x.Money.Amount); 
            var remaining = (customer.Money.Amount - total) - remnant; 
            
            if (remaining < 0.01m) 
            {
                logger.LogError(nameof(remaining) + " Invalid Transaction!");
                throw new ArgumentOutOfRangeException(nameof(remaining) + " Invalid Transaction");
            } 

            customer.Money = new Money(customer.Money.Currency, remaining); 
            logger.LogInformation("{CustomerId} customer's transaction success", customer.CustomerId); 
            
            return customer; 
        } 
    }
}
