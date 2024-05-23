// using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.Entities;
// using LunaLoot.Tenant.Domain.Aggregates.ProductAggregate.ValueObjects;
// using LunaLoot.Tenant.Domain.Common.References;
// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
//
// namespace LunaLoot.Tenant.Infrastructure.Persistence.EFCore.Configuration.ProductConfiguration;
//
// public class ProductVariantConfiguration: IEntityTypeConfiguration<ProductVariant>
// {
//     public void Configure(EntityTypeBuilder<ProductVariant> builder)
//     {
//         builder.ToTable($"{nameof(ProductVariant)}s");
//         builder.HasKey(x => x.Id);
//         builder.HasKey(x => new { x.ProductId, x.VariantId});
//
//         builder.Property(x => x.ProductId)
//             .HasConversion(
//                 x => x.Value,
//                 value => new (value));
//         builder.Property(x => x.VariantId)
//             .HasConversion(
//                 x => x.Value,
//                 value => new(value)
//             );
//
//         builder.Property(x => x.Id)
//             .ValueGeneratedNever()
//             .HasConversion(
//                 id => id.Value,
//                 value => new ProductVariantId(value));
//         
//     
//     }
// }