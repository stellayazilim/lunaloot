using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.IdentityConfiguration;

public class IdentityUserRoleConfiguration: IEntityTypeConfiguration<IdentityUserRole>
{

    public void Configure(EntityTypeBuilder<IdentityUserRole> builder)
    {
        
        builder.ToTable($"{nameof(IdentityUserRole)}s");
        builder.HasKey(x => x.Id);
        builder.HasKey(x => new { x.IdentityUserId, x.IdentityRoleId });

        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd()
            .HasDefaultValue(IdentityUserRoleId.CreateNew())
            .HasConversion(x => x.Value, value => IdentityUserRoleId.Parse(value));
        
        builder.Property(x => x.IdentityRoleId)
            .HasConversion(
                id => id.Value,
                value => IdentityRoleId.Parse(value)
            );
        builder.Property(x => x.IdentityUserId)
            .HasConversion(
                id => id.Value,
                value => IdentityUserId.Parse(value)
            );

        
  
    }
}