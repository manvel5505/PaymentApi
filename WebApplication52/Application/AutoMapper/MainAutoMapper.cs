using AutoMapper;
using WebApplication52.Application.Dto;
using WebApplication52.Domain.Entity;

namespace WebApplication52.Application.AutoMapper
{
    public class MainAutoMapper : Profile
    {
        public MainAutoMapper()
        {
            CreateMap<Customer, OrderProductDto>().ReverseMap();
            CreateMap<Product, OrderProductDto>().ReverseMap();

            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<CustomerDto, Customer>().ReverseMap();
        }
    }
}
