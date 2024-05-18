using LunaLoot.Master.Domain.Aggregates.ProductAggregate.Enum;
using LunaLoot.Master.Domain.Aggregates.ProductAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.ProductConfiguration;

public class Product: IEntityTypeConfiguration<Domain.Aggregates.ProductAggregate.Product>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.ProductAggregate.Product> builder)
    {
        builder.ToTable($"{nameof(Domain.Aggregates.ProductAggregate.Product)}s");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                value => new ProductId(value)
            );

        builder.HasMany(x => x.Variants).WithOne(x => x.Parent).HasPrincipalKey(x => x.ParentRef);

        builder.Property(x => x.ParentRef)
            .HasConversion(
                x => x.Value,
                value => new ProductIdRef(value)
            );
        builder.Property(x => x.Price)
            .HasConversion(
                x => $"{x.Value}|{x.CurrencyType}",
                value => ParsePrice(value)
            );
    }

    private Price ParsePrice(string value)
    {
        var parsed = value.Split(',', StringSplitOptions.RemoveEmptyEntries);
        return new Price(decimal.Parse(parsed[0]), (CurrencyType)int.Parse(parsed[1]));
    }
}