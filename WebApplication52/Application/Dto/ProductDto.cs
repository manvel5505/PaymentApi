using System.ComponentModel.DataAnnotations;
using WebApplication52.Domain.Value_Object;

namespace WebApplication52.Application.Dto
{
    public class ProductDto
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string ProductDescription { get; set; }
        [Required]
        public int ProductQuantity { get; set; }
        [Required]
        public Money Money { get; set; }
    }
}
