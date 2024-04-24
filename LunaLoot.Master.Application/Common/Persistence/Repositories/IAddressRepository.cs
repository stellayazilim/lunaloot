using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Address.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

/// <summary>
/// The address repository interface
/// </summary>
/// <seealso cref="IRepository{Address, AddressId}"/>
public interface IAddressRepository: IRepository<Address, AddressId>
{
        
}