using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebApplication52.Domain.Value_Object;

namespace WebApplication52.Domain.Entity
{
    [Table("ProductTable")]
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        private string productName; 
        public string ProductName
        {
            get => productName;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(productName) + " Product cannot be null or white space");
                }
                productName = value;
            }
        }
        private string productDescription;
        public string ProductDescription
        {
            get => productDescription;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(nameof(productDescription) + " Product cannot be null or white space");
                }
                productDescription = value;
            }
        }
        private int productQuantity;
        public int ProductQuantity
        {
            get => productQuantity;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(productQuantity) + " count should be more then 1");
                }
                productQuantity = value; 
            }
        }
        public Money Money { get; set; }
        public Product() { }
        public Product(string ProductName, string ProductDescription, int ProductQuantity, Money Money)
        {
            this.Money = Money;
            this.ProductName = ProductName;
            this.ProductDescription = ProductDescription;
            this.ProductQuantity = ProductQuantity;
        }
    }
}
