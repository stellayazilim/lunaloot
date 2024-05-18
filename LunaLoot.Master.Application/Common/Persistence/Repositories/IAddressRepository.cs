using LunaLoot.Master.Domain.Aggregates.AddressAggregate;
using LunaLoot.Master.Domain.Aggregates.AddressAggregate.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

/// <summary>
/// The address repository interface
/// </summary>
/// <seealso cref="IRepository{Address, AddressId}"/>
public interface IAddressRepository: IRepository<Address, AddressId>
{
        
}