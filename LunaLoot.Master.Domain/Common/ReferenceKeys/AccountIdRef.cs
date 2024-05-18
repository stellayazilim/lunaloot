using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public sealed class AccountIdRef: ValueObject
{
    public Guid Value { get;  set; }
    
    public AccountIdRef() {}

    public AccountIdRef(Guid value)
    {
        Value = value;
    }
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        // ReSharper disable once HeapView.BoxingAllocation
        yield return Value;
    }
}