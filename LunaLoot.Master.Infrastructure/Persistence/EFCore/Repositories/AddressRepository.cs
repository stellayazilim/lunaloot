using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Aggregates.AddressAggregate;
using LunaLoot.Master.Domain.Aggregates.AddressAggregate.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public class AddressRepository(DbContext dbContext) :Repository<Address, AddressId>(dbContext), IAddressRepository
{
    
}