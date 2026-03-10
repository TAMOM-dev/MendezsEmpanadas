

namespace MendezEmpanadas.Data.Entities
{
    public class Cart
    {
        public Guid Id { get; private set; }
        private readonly List<CartProduct> productsList = new List<CartProduct>();
        public DateTime CreatedAt { get; private set; }

        public Cart() {
            Id = Guid.NewGuid();
            CreatedAt = DateTime.UtcNow;
        }
    }
}
