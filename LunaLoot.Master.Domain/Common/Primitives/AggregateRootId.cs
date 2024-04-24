namespace LunaLoot.Master.Domain.Common.Primitives;

public abstract class AggregateRootId<TId>: ValueObject
{
    public abstract TId Value { get; protected set; }
}