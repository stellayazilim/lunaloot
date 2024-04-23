
using LunaLoot.Master.Domain.Auth.Entities;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Configurations;

public class AppliacationRoleConfiguration: IEntityTypeConfiguration<ApplicationRole>
{
    public void Configure(EntityTypeBuilder<ApplicationRole> builder)
    {
        builder.ToTable("ApplicationRoles");
        builder.HasKey(r => r.Id);
        builder.Property(r => r.Id)
            .ValueGeneratedNever()
            .HasConversion(
                r => r.Value,
                value => ApplicationRoleId.Parse(value)
            );

        builder.Property(r => r.Perms)
            .HasConversion(
                r => string.Join(',', r), 
                value => value.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList());
        builder.Property(r => r.Name).IsRequired();
        
    }
}