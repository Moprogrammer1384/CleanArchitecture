using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.API.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        
        builder.HasKey(u => u.Id);
       
        builder.Property(u => u.Id).UseHiLo();

        builder.Property(u => u.FullName).IsRequired().IsUnicode().HasMaxLength(100);
        builder.Property(u => u.Email).IsRequired(false).IsUnicode(false).HasMaxLength(250);
    }
}
