using LunaLoot.Master.Application.Common.Persistence.Repositories;
using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Address.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Repositories;

public class AddressRepository(DbContext dbContext) :Repository<Address, AddressId>(dbContext), IAddressRepository
{
    
}