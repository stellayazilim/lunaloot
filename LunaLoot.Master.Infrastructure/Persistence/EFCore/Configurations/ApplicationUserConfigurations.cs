using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations;

public class ApplicationUserConfigurations: IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        ConfigureApplicationUserTable(builder);
    }



    private void ConfigureApplicationUserTable(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.ToTable("ApplicationUsers");
        builder.HasKey(u => u.Id);
        builder.Property(u => u.Id)
            .ValueGeneratedNever()
            .HasConversion(
                id => id.Value,
                value => ApplicationUserId.Parse(value)
                );
        builder.Property(u => u.Email)
            .HasMaxLength(64);
        builder.Property(u => u.Password)
            .HasMaxLength(255);
        builder.Property(u => u.FirstName)
            .HasMaxLength(64);
        builder.Property(u => u.LastName)
            .HasMaxLength(64);
        builder.Property(u => u.PhoneNumber)
            .HasMaxLength(11);
        builder.HasMany(u => u.Roles);

    }
}