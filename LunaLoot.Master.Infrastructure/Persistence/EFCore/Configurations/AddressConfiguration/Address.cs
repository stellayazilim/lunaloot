using LunaLoot.Master.Domain.Aggregates.AddressAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.AddressConfiguration;

public class Address: IEntityTypeConfiguration<Domain.Aggregates.AddressAggregate.Address>
{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.AddressAggregate.Address> builder)
    {
        builder.ToTable($"{nameof(Domain.Aggregates.AddressAggregate.Address)}es");
        builder.HasKey(a => a.Id);
        builder.Property(a => a.Id)
            .ValueGeneratedNever()
            .HasConversion(
                a => a.Value,
                value => AddressId.Parse(value)
            );
        builder.Property(u => u.CreatedAt)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(DateTime.UtcNow);
        builder.Property(u => u.UpdatedAt)
            .ValueGeneratedOnUpdate()
            .HasDefaultValue(DateTime.UtcNow);
        
        builder.Property(u => u.DeletedAt)
            .ValueGeneratedNever();
        builder.Property(a => a.Country)
            .HasMaxLength(64);

        builder.Property(a => a.City)
            .HasMaxLength(64);

        builder.Property(a => a.Province)
            .HasMaxLength(64);

        builder.Property(a => a.Town)
            .HasMaxLength(64);

        builder.Property(a => a.Street)
            .HasMaxLength(64);

        builder.Property(a => a.PostCode)
            .HasMaxLength(8);

        builder.Property(a => a.Name)
            .HasMaxLength(64);

        builder.Property(a => a.Description)
            .HasMaxLength(255);
    }
}