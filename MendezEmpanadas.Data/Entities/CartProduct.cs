

namespace MendezEmpanadas.Data.Entities
{
    public class CartProduct
    {
        public Guid ProductId { get; private set; }
        public decimal Price { get; private set; }
        public decimal Quantity { get; private set; }

        private CartProduct() { }

        public CartProduct(Guid productId, decimal price, decimal quantity)
        {
            ProductId = productId;
            Price = price;
            Quantity = quantity;
        }

        public void IncreaseQuantity(int quantity)
        {
            Quantity += quantity;
        }

    }
}
