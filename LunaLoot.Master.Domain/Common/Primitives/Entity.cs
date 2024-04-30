using LunaLoot.Master.Domain.Common.Interfaces;

namespace LunaLoot.Master.Domain.Common.Primitives;


/// <summary>
/// The entity class
/// </summary>
/// <seealso cref="IEquatable{Entity{TId}}"/>
public abstract class Entity<TId>: IEquatable<Entity<TId>>, IHasDomainEvents
{
    /// <summary>
    /// Gets or inits the value of the id
    /// </summary>
    // ReSharper disable once NullableWarningSuppressionIsUsed
    public TId Id { get; protected set; } = default!;

    /// <summary>
    /// The domain events
    /// </summary>
    private readonly List<IDomainEvent> _domainEvents = new();
    /// <summary>
    /// Gets the value of the domain events
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    /// <summary>
    /// Gets or inits the value of the created at
    /// </summary>
    public DateTime CreatedAt { get; protected set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or inits the value of the updated at
    /// </summary>
    public DateTime UpdatedAt { get; protected set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Gets or inits the value of the deleted at
    /// </summary>
    public DateTime? DeletedAt { get; protected set; } 
    
    /// <summary>
    /// Gets or inits the value of the delete reason
    /// </summary>
    public string? DeleteReason { get; protected init; }
    
    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class
    /// </summary>
    /// <param name="id">The id</param>
    protected Entity(TId id) {
        Id = id;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Entity{TId}"/> class
    /// </summary>
    protected Entity() {  }
    
    
    // ReSharper disable once MemberCanBeProtected.Global
    /// <summary>
    /// Adds the domain event using the specified domain event
    /// </summary>
    /// <param name="domainEvent">The domain event</param>
    public void AddDomainEvent(IDomainEvent domainEvent) {
        
        _domainEvents.Add(domainEvent);
    }

    /// <summary>
    /// Clears the domain events
    /// </summary>
    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
    
    /// <summary>
    /// Equalses the obj
    /// </summary>
    /// <param name="obj">The obj</param>
    /// <returns>The bool</returns>
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

    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>The int</returns>
    public override int GetHashCode() {
        return Id.GetHashCode();
    }

    /// <summary>
    /// Check if two entity is equal
    /// </summary>
    /// <param name="other">The other</param>
    /// <returns>The bool</returns>
    public bool Equals(Entity<TId>? other) {
        return Equals((object?)other);
    }
}