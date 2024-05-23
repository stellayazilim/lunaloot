using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate;
using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Configuration.ProductConfiguration;

public class ProductConfiguration: IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable(nameof(Product));
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                productId => productId.Value,
                value => new ProductId(value)
            );

        builder.Property(x => x.BrandId)
            .HasConversion(
                id => id.Value,
                value => new BrandId(value));

        builder.Property(x => x.ParentId)
            .HasConversion(
                id => id.Value,
                value => new(value)
            );
        builder.HasOne(x => x.Brand).WithMany(x => x.Products).HasForeignKey( x=> x.BrandId);
 
        builder.HasMany(x => x.ProductAddIns).WithMany(x => x.Products);

        builder.HasMany(x => x.Variants).WithOne(x => x.Parent).HasPrincipalKey(x => x.ParentId);

        builder.HasOne(x => x.Parent).WithMany(x => x.Variants).HasForeignKey(x => x.ParentId);


    }
}