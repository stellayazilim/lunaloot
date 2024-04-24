using LunaLoot.Master.Domain.Address;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Application.Common.Persistence;

public interface ILunaLootMasterDbContext
{
    DbSet<Address> Addresses { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}