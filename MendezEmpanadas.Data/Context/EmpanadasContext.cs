

using Microsoft.EntityFrameworkCore;

namespace MendezEmpanadas.Data.Context
{
    public class EmpanadasContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("EmpanadasDb");
        }

    }
}
