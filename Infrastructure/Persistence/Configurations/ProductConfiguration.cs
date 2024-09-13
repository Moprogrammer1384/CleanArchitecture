using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("Products");
        
        builder.HasKey(p => p.Id);
        
        builder.Property(p => p.Id).UseHiLo();

        builder.Property(p => p.Name).IsRequired().IsUnicode().HasMaxLength(100);
        builder.Property(p => p.Description).IsRequired(false).IsUnicode().HasMaxLength(250);

    }
}
