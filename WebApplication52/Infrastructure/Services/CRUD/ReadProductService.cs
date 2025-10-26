using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Infrastructure.Database;

namespace WebApplication52.Infrastructure.Services.CRUD
{
    public class ReadProductService : IReadServices<Product, int>
    {
        private readonly MainDatabase data;
        private readonly ILogger<ReadProductService> logger;
        public ReadProductService(MainDatabase data, ILogger<ReadProductService> logger)
        {
            this.data = data;
            this.logger = logger;
        }
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            var products = await data.products.ToListAsync();
            logger.LogInformation(nameof(products) + " successfully received");
            
            return products;
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = await data.products.FindAsync(id);

            if (product == null)
            {
                logger.LogError(nameof(product) + " Product with id not found!");
                throw new KeyNotFoundException(nameof(product) + " Product with id not found!");
            }

            logger.LogInformation(nameof(product) + " successfully received");

            return product;
        }
    }
}
