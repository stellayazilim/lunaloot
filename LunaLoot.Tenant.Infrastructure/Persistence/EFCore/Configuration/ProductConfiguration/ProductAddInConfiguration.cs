using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Configuration.ProductConfiguration;

public class ProductAddInConfiguration: IEntityTypeConfiguration<ProductAddIn>
{
    public void Configure(EntityTypeBuilder<ProductAddIn> builder)
    {
        builder.ToTable($"{nameof(ProductAddIn)}s");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => new(value)
            );
        builder.Property(x => x.Price);
        builder.Property(x => x.Tax);
        builder.Property(x => x.Name);
        builder.Property(x => x.Description);
        builder.HasMany(x => x.Products).WithMany(x => x.ProductAddIns);

    }
}