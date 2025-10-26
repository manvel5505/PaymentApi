using System.ComponentModel.DataAnnotations;

namespace WebApplication52.Application.Dto
{
    public class CustomerDto
    {
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CustomerEmailAddress { get; set; }
        [Required]
        public string CustomerAddress { get; set; }
        public DateTime TransactionTime { get; set; }
        public List<string> CustomerTransactionHistory { get; set; }
    }
}
