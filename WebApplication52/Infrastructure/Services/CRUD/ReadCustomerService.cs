using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Infrastructure.Database;

namespace WebApplication52.Infrastructure.Services.CRUD
{
    public class ReadCustomerService : IReadServices<Customer, Guid>
    {
        private readonly MainDatabase data;
        private readonly ILogger<ReadCustomerService> logger;
        public ReadCustomerService(MainDatabase data, ILogger<ReadCustomerService> logger)
        {
            this.data = data;
            this.logger = logger;
        }
        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var customers = await data.customers.ToListAsync();
            logger.LogInformation(nameof(customers) + " successfully received");

            return customers;
        }

        public async Task<Customer> GetByIdAsync(Guid id)
        {
            var customer = await data.customers.FindAsync(id);

            if (customer == null)
            {
                logger.LogError(nameof(customer) + " Customer with id not found!");
                throw new KeyNotFoundException(nameof(customer) + " Customer with id not found!");
            }

            logger.LogInformation(nameof(customer) + " successfully received");

            return customer;
        }
    }
}
