using WebApplication52.Domain.Entity;

namespace WebApplication52.Application.Dto
{
    public class OrderProductDto
    { 
        public Guid OrderId { get; set; }
        public List<Product> Product { get; set; }
        public Customer Customer { get; set; }
    }
}
