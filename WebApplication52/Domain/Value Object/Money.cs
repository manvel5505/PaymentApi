using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication52.Domain.Value_Object
{
    public sealed class Money
    {
        public string Currency { get; private set; } = "USD";
        [Column(TypeName = "decimal(12,2)")]
        public decimal Amount { get; private set; }
        public Money() { }
        public Money(string Currency, decimal Amount)
        {
            if (string.IsNullOrWhiteSpace(Currency))
            {
                throw new ArgumentNullException(nameof(Currency) + " Cant be null or white space!");
            }
            if (Amount < 00.1m)
            {
                throw new ArgumentOutOfRangeException(nameof(Amount) + " should be bigger then 0.01" + Currency);
            }
            this.Currency = Currency;
            this.Amount = Amount;
        }
        public override string ToString()
        {
            return $"Money: {Amount} {Currency}";
        }
    }
}
