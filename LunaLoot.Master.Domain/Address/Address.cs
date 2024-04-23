using LunaLoot.Master.Domain.Address.ValueObjects;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Address;

public class Address: AggregateRoot<AddressId>
{
    public Country Country { get; private set; }
    
    public string City { get; private set; }
    
    public string Province { get; private set; }
    
    public string Town { get; private set; }
    
    public string Street { get; private set; }
    
    public string PostCode { get; private set; }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }

}