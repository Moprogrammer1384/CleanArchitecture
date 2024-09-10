using Catalog.API.Infrastructure.Persistence.Configurations;
using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Catalog.API.Infrastructure.Persistence;

public class CatalogContext : DbContext
{
    public CatalogContext(DbContextOptions<CatalogContext> options) 
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // modelBuilder.ApplyConfiguration(new ProductConfiguration());
        // modelBuilder.ApplyConfiguration(new OtherConfiguration());

        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    public DbSet<Product> Products { get; set; }
}
