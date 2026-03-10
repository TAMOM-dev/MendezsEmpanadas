

using MendezEmpanadas.Data.Context;
using MendezEmpanadas.Data.Entities;
using MendezEmpanadas.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MendezEmpanadas.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly EmpanadasContext _context;

        public ProductRepository(EmpanadasContext context)
        {
            _context = context;
        }

        public async Task<Product?> GetByIdAsync(Guid id, CancellationToken ct = default)
            => await _context.Products.FindAsync(new object[] { id }, ct);

        public async Task<IEnumerable<Product>> GetAllAsync(CancellationToken ct = default)
            => await _context.Products.ToListAsync(ct);

        public async Task AddAsync(Product product, CancellationToken ct = default)
            => await _context.Products.AddAsync(product, ct);

        public async Task UpdateAsync(Product product, CancellationToken ct = default)
        {
            _context.Products.Update(product);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id, CancellationToken ct = default)
        {
            var product = await _context.Products.FindAsync(new object[] { id }, ct);
            if(product is not null)
                _context.Products.Remove(product);

        }

    }
}
