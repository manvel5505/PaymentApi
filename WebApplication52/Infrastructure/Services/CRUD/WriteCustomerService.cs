using AutoMapper;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Infrastructure.Database;

namespace WebApplication52.Infrastructure.Services.CRUD
{
    public class WriteCustomerService : IWriteService<Customer, Guid>
    {
        private readonly MainDatabase data;
        private readonly ILogger<WriteCustomerService> logger;
        public WriteCustomerService(MainDatabase data, ILogger<WriteCustomerService> logger)
        {
            this.data = data;
            this.logger = logger;
        }
        public async Task<Customer> AddAsync(Customer entity)
        {
            if (entity == null)
            {
                logger.LogError(nameof(entity) + " Customer cannot be null!");
                throw new ArgumentNullException(nameof(entity) + " Customer cannot be null");
            }

            await data.customers.AddAsync(entity);

            return entity;
        }

        public async Task<Customer> DeleteAsync(Guid id)
        {
            var customer = await data.customers.FindAsync(id);

            if (customer == null)
            {
                logger.LogError(nameof(customer) + " Customer with id not found!");
                throw new KeyNotFoundException(nameof(customer) + " Customer with id not found!");
            }

            data.customers.Remove(customer);

            return customer;
        }

        public async Task<Customer> UpdateAsync(Guid id, Customer entity)
        {
            var customer = await data.customers.FindAsync(id);

            if (customer == null)
            {
                logger.LogError(nameof(customer) + " Customer with id not found!");
                throw new KeyNotFoundException(nameof(customer) + " Customer with id not found!");
            }

            if (entity == null)
            {
                logger.LogError(nameof(entity) + " Customer cannot be null!");
                throw new ArgumentNullException(nameof(entity) + " Customer cannot be null");
            }

            data.customers.Update(entity);

            return entity;
        }
    }
}
