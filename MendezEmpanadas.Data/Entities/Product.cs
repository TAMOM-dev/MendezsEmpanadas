

namespace MendezEmpanadas.Data.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public decimal Price { get; private set; }
        public int StockQuantity { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime? UpdatedAt { get; private set; }

        // Private constructor for EF Core
        private Product() { }

        public Product(string name, string description, decimal price, int stockQuantity)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? string.Empty;
            Price = price > 0 ? price : throw new ArgumentException("Price must be positive.", nameof(price));
            StockQuantity = stockQuantity >= 0? stockQuantity : throw new ArgumentException("Stock can't be negative.", nameof(stockQuantity));
            CreatedAt = DateTime.UtcNow;
        }

        public void UpdatePrice(decimal newPrice)
        {
            if (newPrice <= 0)
                throw new ArgumentException("Price must be positive.", nameof(newPrice));
            Price = newPrice;
            UpdatedAt = DateTime.UtcNow;
        }

        public void ReduceStock(int quantity)
        {
            if (quantity > StockQuantity)
                throw new InvalidOperationException("Not enough stock available.");

            StockQuantity -= quantity;
            UpdatedAt = DateTime.UtcNow;
        }

    }


}
