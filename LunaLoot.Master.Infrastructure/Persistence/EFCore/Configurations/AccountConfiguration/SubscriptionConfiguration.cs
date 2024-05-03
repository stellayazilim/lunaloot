using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.Entities;
using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.AccountConfiguration;

public class SubscriptionConfiguration: IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable($"{nameof(Subscription)}s");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                value => new SubscriptionId(value)
            );

        builder.Property(x => x.InvoiceId)
            .HasConversion(
                x => x.Value,
                value => new InvoiceIdRef(value)
            );

        builder.HasOne(x => x.Account).WithMany(x => x.Subscriptions).HasForeignKey(x => x.AccountId);
        
    }
}