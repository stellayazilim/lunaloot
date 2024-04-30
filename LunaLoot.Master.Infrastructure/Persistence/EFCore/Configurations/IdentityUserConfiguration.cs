using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;
using LunaLoot.Master.Domain.Identity.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations;

public class IdentityUserConfiguration: IEntityTypeConfiguration<IdentityUser>
{
    public void Configure(EntityTypeBuilder<IdentityUser> builder)
    {
        builder.ToTable(nameof(IdentityUser));

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => IdentityUserId.Parse(value)
            );

        builder.Property(x => x.Password)
            .HasConversion(
                password => password.Value,
                value => PasswordHash.Parse(value)
            );
        builder
            .HasMany(x => x.Roles)
            .WithMany(x => x.Users).UsingEntity<IdentityUserRole>(
                l => l.HasOne<IdentityRole>().WithMany().HasForeignKey( e => e.IdentityRoleId),
                r => r.HasOne<IdentityUser>().WithMany().HasForeignKey( e => e.IdentityUserId));

        builder.HasMany(x => x.Logins).WithOne(x => x.User).HasForeignKey(x => x.UserId);

    }
}