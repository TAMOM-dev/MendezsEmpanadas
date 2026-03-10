

using MendezEmpanadas.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace MendezEmpanadas.Data.Context
{
    public class EmpanadasContext : DbContext
    {
        public EmpanadasContext(DbContextOptions<EmpanadasContext> options) : base(options)
        {

        }


        public DbSet<Product> Products => Set<Product>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(200);
                entity.Property(e => e.Price).HasPrecision(18, 2);
            });

            base.OnModelCreating(modelBuilder);
        }

       
    }
}
