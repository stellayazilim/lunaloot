using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.Enums;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations;

public class IdentityRoleConfiguration : IEntityTypeConfiguration<IdentityRole>
{

    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.ToTable(nameof(IdentityRole));

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => IdentityRoleId.Parse(value)
            );

        builder.Property(x => x.Permissions)
            .HasConversion(
                permissions => string.Join(',', permissions),
                value => ParsePermissions(value)
            );

        builder.HasMany(x => x.Users).WithMany(x => x.Roles);
    }


    private List<Permissions> ParsePermissions(string value)
    {

        var permsArr = value.Split(',', StringSplitOptions.RemoveEmptyEntries);

        return permsArr.Select(x => (Permissions)Enum.Parse(typeof(Permissions), x)).ToList();
    }

}