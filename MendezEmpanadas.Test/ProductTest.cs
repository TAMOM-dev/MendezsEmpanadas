using MendezEmpanadas.Data.Entities;

namespace MendezEmpanadas.Test
{
    public class ProductTest
    {
        [Fact]
        public void Constructor_WithValidData_CreateProduct()
        {
            var product = new Product("Empanada Queso", "Una empanada con queso", 34.99m, 20);

            Assert.Equal("Empanada Queso", product.Name);
            Assert.Equal("Una empanada con queso", product.Description);
            Assert.Equal(34.99m, product.Price);
            Assert.Equal(20, product.StockQuantity);
        }

        [Fact]
        public void Constructor_WithNullName_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new Product(null!, "Empanada con queso", 34.99m, 20)
            );
        }

        [Fact]
        public void Constructor_WithNegativePrice_ThrowsArgumentException()
        {
            Assert.Throws<ArgumentException>(() => 
                new Product("Empanada Jamón", "Una empanada con jamón", -10m, 20));
        }

        [Fact]
        public void ReduceStock_WithInsufficienceQuantity_ThrowException()
        {
            var product = new Product("Empanada Queso", "Una empanada con queso", 30m, 20);

            Assert.Throws<InvalidOperationException>(() =>
                product.ReduceStock(30));
        }

        [Fact]
        public void ReduceStock_WithSufficientQuantity_ReduceStock()
        {
            var product = new Product("Empanada Queso", "Una empanada con queso", 30m, 20);
            product.ReduceStock(5);
            Assert.Equal(15, product.StockQuantity);
        }
    }
}
