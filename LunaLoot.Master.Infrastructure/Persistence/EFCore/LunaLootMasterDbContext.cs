using System.Reflection;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
using Microsoft.EntityFrameworkCore;
// ReSharper disable NullableWarningSuppressionIsUsed

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

public class LunaLootMasterDbContext(
    DbContextOptions<LunaLootMasterDbContext> options) : DbContext(options)
{
    public DbSet<ApplicationUser> ApplicationUsers { get; init; } = null!;
    public DbSet<ApplicationRole> ApplicationRoles { get; init; } = null!;
    public DbSet<Address> Addresses { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}