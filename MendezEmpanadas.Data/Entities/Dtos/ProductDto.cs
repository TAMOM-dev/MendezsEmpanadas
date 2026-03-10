

namespace MendezEmpanadas.Data.Entities.Dtos
{
    public class ProductDto
    {
       
        public record CreateProductRequest(
        
            string Name,
            decimal Price,
            string Description,
            string StockQuantity
        );
       
        public record ProductResponse(

            Guid Id,
            string Name,
            decimal Price,
            string Description,
            string StockQuantity,
            DateTime CreatedAt
        );

    }
}
