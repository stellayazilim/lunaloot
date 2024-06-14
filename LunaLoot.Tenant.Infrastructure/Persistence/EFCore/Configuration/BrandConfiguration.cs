using LunaLoot.Tenant.Domain.Aggregates.Product.ValueObjects;
using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Configuration;

public class BrandConfiguration: IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.ToTable($"{nameof(Brand)}s");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => BrandId.Create(value)
            );
        builder.HasMany(x => x.Products)
            .WithOne(x => x.Brand)
            .HasForeignKey(x => x.BrandId)
            .HasPrincipalKey(x => x.Id);
    }
}