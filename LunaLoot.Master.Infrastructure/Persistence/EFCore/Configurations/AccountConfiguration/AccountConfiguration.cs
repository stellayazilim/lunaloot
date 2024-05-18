using LunaLoot.Master.Domain.Aggregates.AccountAggregate;
using LunaLoot.Master.Domain.Aggregates.AccountAggregate.ValueObjects;
using LunaLoot.Master.Domain.Common.ReferenceKeys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.AccountConfiguration;

public class AccountConfiguration: IEntityTypeConfiguration<Account>

{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable($"{nameof(Account)}s");
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


        builder.HasMany(x => x.Subscriptions).WithOne(x => x.Account).HasForeignKey(x => x.AccountId);
        
        builder.Property(x => x.Addresses)
            .HasConversion(
                x => string.Join(',', x),
                values => values.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .ToList()
                    .ConvertAll(x => new AddressIdRef(Guid.Parse(x)))
            );
        

    }

}