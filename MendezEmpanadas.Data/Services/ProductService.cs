

using MendezEmpanadas.Data.Entities;
using MendezEmpanadas.Data.Entities.Dtos;
using MendezEmpanadas.Data.Interfaces;

namespace MendezEmpanadas.Data.Services
{
    public class ProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ProductResponse> CreateProductAsync(CreateProductRequest request, CancellationToken ct = default)
        {
            var product = new Product(
                request.Name,
                request.Description,
                request.Price,
                request.StockQuantity

            );

            await _productRepository.AddAsync(product, ct);
            await _unitOfWork.SaveChangesAsync(ct);

            return new ProductResponse(
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.StockQuantity,
                product.CreatedAt
            );

        }

        public async Task<ProductResponse?> GetProductByIdAsync(Guid id, CancellationToken ct = default)
        {
            var product = await _productRepository.GetByIdAsync(id, ct);
            if (product == null)
                return null;
            return new ProductResponse(
                product.Id,
                product.Name,
                product.Price,
                product.Description,
                product.StockQuantity,
                product.CreatedAt
            );

        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync(CancellationToken ct = default)
        {
            var products = await _productRepository.GetAllAsync(ct);
            return products.Select(p => new ProductResponse(
                p.Id,
                p.Name,
                p.Price,
                p.Description,
                p.StockQuantity,
                p.CreatedAt
            ));
        }

    }
}
