using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class TariffIdRef: ValueObject
{
    public Guid Value { get; private init; }
    
    public TariffIdRef() {}

    public TariffIdRef(Guid id)
    {
        Value = id; 
    }
    public override IEnumerable<object> GetEqualityComponents()
    {
        throw new NotImplementedException();
    }
}