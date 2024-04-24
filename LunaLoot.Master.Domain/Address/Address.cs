using LunaLoot.Master.Domain.Address.ValueObjects;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Address;

public class Address: AggregateRoot<AddressId, Guid>
{
    public string Country { get; private set; }
    
    public string City { get; private set; }
    
    public string Province { get; private set; }
    
    public string Town { get; private set; }
    
    public string Street { get; private set; }
    
    public string PostCode { get; private set; }
    
    public string Name { get; private set; }
    
    public string Description { get; private set; }

    private Address(
        AddressId id,
        string country,
        string city,
        string province,
        string town,
        string street,
        string postCode,
        string name,
        string description
    ) : base(id)
    {
        Country = country;
        City = city;
        Province = province;
        Town = town;
        Street = street;
        PostCode = postCode;
        Name = name;
        Description = description;
    }
    
    #pragma warning disable CS8618 
    private Address() {}
    #pragma warning restore CS8618

    public static Address CreateNew(
        string country,
        string city,
        string province,
        string town,
        string street,
        string postCode,
        string name,
        string description
        ) => new(
            AddressId.CreateNew(),
            country,
            city,
            province,
            town,
            street,
            postCode,
            name,
            description
        );
}