
using LunaLoot.Tenant.Domain.Aggregates.Product.Entities;
using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Configuration;

public class ProductVariantConfiguration: IEntityTypeConfiguration<ProductVariant>
{

    public void Configure(EntityTypeBuilder<ProductVariant> builder)
    {
        builder.ToTable($"{nameof(ProductVariant)}s");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ProductVariantId.Create(value)
            );

        builder.Property(x => x.ProductId)
            .HasConversion(
                id => id.Value,
                value => ProductId.Create(value)
            );

        builder.HasOne(x => x.Product)
            .WithMany(x => x.Variants)
            .HasForeignKey(x => x.ProductId)
            .HasPrincipalKey(x => x.Id);
    }
}