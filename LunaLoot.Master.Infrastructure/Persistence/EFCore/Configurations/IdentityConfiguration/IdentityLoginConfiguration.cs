using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.IdentityConfiguration;

public class IdentityLoginConfiguration: IEntityTypeConfiguration<IdentityLogin>
{
    public void Configure(EntityTypeBuilder<IdentityLogin> builder)
    {
        builder.ToTable($"{nameof(IdentityLogin)}s");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => IdentityLoginId.Parse(value)
            );

        builder.Property(x => x.ValidUntil);

        builder.Property(x => x.IsConsumed).HasDefaultValue(false);
        builder.HasOne(x => x.User).WithMany(x => x.Logins).HasForeignKey(x => x.UserId);
    }
}