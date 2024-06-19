using System.Text.Json.Serialization;
using LunaLoot.Tenant.Domain.Aggregates.Products;
using LunaLoot.Tenant.Domain.Aggregates.Products.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

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

        builder.Property(x => x.Specifications)
            .HasConversion(
                x => JsonConvert.SerializeObject(x, Formatting.Indented),
                value => JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(value)!);
        
        builder.HasMany(x => x.Variants)
            .WithOne(x => x.Product)
            .HasForeignKey(x => x.ProductId);
    }
}

