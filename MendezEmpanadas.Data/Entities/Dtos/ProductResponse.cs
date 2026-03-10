

namespace MendezEmpanadas.Data.Entities.Dtos
{
    public record ProductResponse(

            Guid Id,
            string Name,
            decimal Price,
            string Description,
            string StockQuantity,
            DateTime CreatedAt
    );
}
