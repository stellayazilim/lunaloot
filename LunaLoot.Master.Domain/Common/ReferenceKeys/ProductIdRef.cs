using LunaLoot.Master.Domain.Common.Primitives;
// ReSharper disable MemberCanBePrivate.Global

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class ProductIdRef: ValueObject
{
    public Guid Value { get; private init; }
    
    public ProductIdRef() {}

    public ProductIdRef(Guid id)
    {
        Value = id;
        
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}