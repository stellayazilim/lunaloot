using LunaLoot.Master.Domain.Aggregates.AccountAggregateRoot.ValueObjects;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.AccountConfiguration;

public class Account: IEntityTypeConfiguration<Domain.Aggregates.AccountAggregateRoot.Account>

{
    public void Configure(EntityTypeBuilder<Domain.Aggregates.AccountAggregateRoot.Account> builder)
    {
        builder.ToTable($"{nameof(Domain.Aggregates.AccountAggregateRoot.Account)}s");
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                x => x.Value,
                value => AccountId.Parse(value)
            );

        builder.Property(x => x.AccountUserRef)
            .HasConversion(x => x.Value, value => new IdentityUserIdRef(value))
            .IsRequired();
        
        
        builder.Property(x => x.Subscriptions)
            .HasConversion(
                x => string.Join(',', x.Select( x => x.Value)),
                value => 
                    value.Split(
                        ',', 
                         StringSplitOptions.RemoveEmptyEntries
                        ).ToList().ConvertAll(
                        x => new SubscriptionIdRef(Guid.Parse(x))
                    )
                );
        
        builder.Property(x => x.Addresses)
            .HasConversion(
                x => string.Join(',', x),
                values => values.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ConvertAll(x => new AddressIdRef(Guid.Parse(x)))
            );
        

    }

}