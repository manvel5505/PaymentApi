using AutoMapper;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Infrastructure.Database;

namespace WebApplication52.Infrastructure.Services.CRUD
{
    public class WriteProductService : IWriteService<Product, int>
    {
        private readonly MainDatabase data;
        private readonly ILogger<WriteProductService> logger;
        public WriteProductService(MainDatabase data, ILogger<WriteProductService> logger)
        {
            this.data = data;
            this.logger = logger;
        }

        public async Task<Product> AddAsync(Product entity)
        {
            if (entity == null)
            {
                logger.LogError(nameof(entity) + " Product cannot be null!");
                throw new ArgumentNullException(nameof(entity) + " Product cannot be null");
            }

            await data.products.AddAsync(entity);

            return entity;
        }

        public async Task<Product> DeleteAsync(int id)
        {
            var product = await data.products.FindAsync(id);

            if (product == null)
            {
                logger.LogError(nameof(product) + " Product with id not found!");
                throw new KeyNotFoundException(nameof(product) + " Product with id not found!");
            }

            data.products.Remove(product);

            return product;
        }

        public async Task<Product> UpdateAsync(int id, Product entity)
        {
            var product = await data.products.FindAsync(id);

            if (product == null)
            {
                logger.LogError(nameof(product) + " Product with id not found!");
                throw new KeyNotFoundException(nameof(product) + " Product with id not found!");
            }

            if (entity == null)
            {
                logger.LogError(nameof(entity) + " Product cannot be null!");
                throw new ArgumentNullException(nameof(entity) + " Product cannot be null");
            }

            data.products.Update(entity);

            return entity;
        }
    }
}
