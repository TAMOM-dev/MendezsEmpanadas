using MendezEmpanadas.Data.Entities.Dtos;
using MendezEmpanadas.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace MendezEmpanadas.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts(CancellationToken ct)
        {
            var products = await _productService.GetAllProductsAsync(ct);
            return Ok(products);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetProductById(Guid id, CancellationToken ct)
        {
            var product = await _productService.GetProductByIdAsync(id, ct);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductRequest request, CancellationToken ct)
        {
            var product = await _productService.CreateProductAsync(request, ct);
            return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
        }
    }
}
