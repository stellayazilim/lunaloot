using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Identity;
using LunaLoot.Master.Domain.Identity.Entities;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Application.Common.Persistence;

public interface ILunaLootMasterDbContext
{
    public DbSet<IdentityUser> IdentityUsers { get; }

    public DbSet<IdentityRole> IdentityRoles { get; }
    
    public DbSet<IdentityUserRole> IdentityUserRoles { get;  }
    
    public DbSet<Address> Addresses { get;  }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}