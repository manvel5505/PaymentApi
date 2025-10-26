using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication52.Domain.Value_Object;

namespace WebApplication52.Domain.Entity
{
    [Table("CustomerTable")]
    public class Customer
    {
        [Key]
        public Guid CustomerId { get; set; } = Guid.NewGuid();
        private string customerName;
        public string CustomerName 
        {
            get => customerName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(customerName) + "Customer cannot be null or white space");
                }
                customerName = value;
            }
        }
        private string customerEmailAddress;
        public string CustomerEmailAddress
        {
            get => customerEmailAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(customerEmailAddress) + " Customer cannot be null or white space");
                }
                customerEmailAddress = value;
            }
        }
        private string customerAddress;
        public string CustomerAddress 
        {
            get => customerAddress;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(customerAddress) + " Customer cannot be null or white space");
                }
                customerAddress = value;
            }
        }
        private DateTime transactionTime;
        public DateTime TransactionTime 
        {
            get => transactionTime;
            set
            {
                if (value > DateTime.UtcNow)
                {
                    throw new ArgumentOutOfRangeException(nameof(transactionTime) + " invalid date was set!");
                }
                transactionTime = value;
            }
        }
        public List<string> CustomerTransactionHistory { get; set; }
        public Money Money { get; set; }
        public Customer() { }
        public Customer(string CustomerName, string CustomerEmailAddress, string CustomerAddress, DateTime TransactionTime, List<string> CustomerTransactionHistory, Money Money)
        {
            this.CustomerName = CustomerName;
            this.CustomerEmailAddress = CustomerEmailAddress;
            this.CustomerAddress = CustomerAddress;
            this.TransactionTime = TransactionTime;
            this.CustomerTransactionHistory = CustomerTransactionHistory;
            this.Money = Money;
        }
    }
}
