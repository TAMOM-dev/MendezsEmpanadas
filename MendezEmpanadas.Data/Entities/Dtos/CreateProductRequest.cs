
namespace MendezEmpanadas.Data.Entities.Dtos
{
    public record CreateProductRequest(
        string Name,
        decimal Price,
        string Description,
        string StockQuantity
    );
    
}
