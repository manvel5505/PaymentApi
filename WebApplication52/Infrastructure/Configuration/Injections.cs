using Microsoft.EntityFrameworkCore;
using WebApplication52.Application.AutoMapper;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;
using WebApplication52.Domain.Interfaces;
using WebApplication52.Domain.Logic;
using WebApplication52.Infrastructure.Database;
using WebApplication52.Infrastructure.Services;
using WebApplication52.Infrastructure.Services.CRUD;

namespace WebApplication52.Infrastructure.Configuration
{
    public static class Injections
    {
        public static IServiceCollection DIContainerAdder(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAutoMapper(typeof(MainAutoMapper).Assembly);

            var connection = configuration.GetConnectionString(nameof(MainDatabase));
            service.AddDbContext<MainDatabase>(opt => opt.UseSqlServer(connection));

            service.AddScoped<ILogicService<Customer>, LogicService>();
            service.AddScoped<ITransactionActions, TransactionService>();

            service.AddScoped<IReadServices<Customer, Guid>, ReadCustomerService>();
            service.AddScoped<IReadServices<Product, int>, ReadProductService>();
            service.AddScoped<IWriteService<Customer, Guid>, WriteCustomerService>();
            service.AddScoped<IWriteService<Product, int>, WriteProductService>();

            return service;
        }
        public static IServiceCollection AddCORSPolicy(this IServiceCollection service)
        {
            service.AddCors(Foundation =>
            {
                Foundation.AddPolicy("AllowFew", build =>
                {
                    build.AllowAnyHeader();
                    build.AllowAnyMethod();
                    build.AllowAnyOrigin();
                });
            });

            return service;
        }
    }
}
