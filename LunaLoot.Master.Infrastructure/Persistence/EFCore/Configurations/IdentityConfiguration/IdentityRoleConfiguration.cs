using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations.IdentityConfiguration;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable($"{nameof(IdentityRole)}s");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => IdentityRoleId.Parse(value)
            );

        builder.Property(x => x.Permissions)
            .HasConversion(
                x => (int)x,
                value => (Permissions)value);

        builder.HasMany(x => x.Users).WithMany(x => x.Roles);
    }



}