﻿namespace LunaLoot.Tenant.Domain.Common.Primitives;




public abstract class AggregateRoot<TId> :
    Entity<TId> where TId: notnull {
    protected AggregateRoot(TId id) : base(id) {
        Id = id;
    }
    
    protected AggregateRoot() {}
}