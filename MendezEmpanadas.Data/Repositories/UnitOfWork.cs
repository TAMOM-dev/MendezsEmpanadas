

using MendezEmpanadas.Data.Context;
using MendezEmpanadas.Data.Interfaces;

namespace MendezEmpanadas.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EmpanadasContext _context;

        public UnitOfWork(EmpanadasContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
            => await _context.SaveChangesAsync(ct);
    }
}
