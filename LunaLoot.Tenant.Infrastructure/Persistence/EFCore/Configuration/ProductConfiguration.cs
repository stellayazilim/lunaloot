using LunaLoot.Tenant.Domain.Aggregates.Product;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Configuration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable($"{nameof(Product)}s");

        builder.HasKey(x => x.Id);

        builder.ComplexProperty(x => x.Price, pb =>
        {
            pb.Property( x => x.Amount);
            pb.Property( x => x.Currency);
        });
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value));

        builder.HasMany(x => x.Variants)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}

