namespace LunaLoot.Master.Domain.Common.Primitives;


public abstract class Entity<TId>: IEquatable<Entity<TId>>
{
    public TId Id { get; protected init;}

    public DateTime CreatedAt { get; protected init; }
    
    public DateTime UpdatedAt { get; protected init; }
    
    public DateTime DeletedAt { get; protected init; }
    
    public string DeleteReason { get; protected init; }
    
    protected Entity(TId id) {
        Id = id;
    }

    protected Entity() {  }

    public override bool Equals(object? obj)
    {
        return obj is Entity<TId> entity && Id.Equals(entity.Id);
    }


    public static bool operator ==(Entity<TId> left, Entity<TId> right) {
        return Equals(left, right);
    }


    public static bool operator !=(Entity<TId> left, Entity<TId> right) {
        return !Equals(left, right);
    }

    public override int GetHashCode() {
        return Id.GetHashCode();
    }

    public bool Equals(Entity<TId>? other) {
        return Equals((object?)other);
    }
}