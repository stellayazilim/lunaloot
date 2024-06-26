﻿using LunaLoot.Master.Domain.Common.Primitives;
using LunaLoot.Master.Domain.Identity.ValueObjects;

namespace LunaLoot.Master.Domain.Common.ReferenceKeys;

public class IdentityRoleIdRef: ValueObject
{
    public Guid Value { get; private init; }
    
    public IdentityRoleIdRef() {}

    public IdentityRoleIdRef(Guid id)
    {
        Value = id;
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;

    }
}