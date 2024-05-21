namespace LunaLoot.Tenant.Domain.Common.Interfaces;

/// <summary>
/// The has domain events interface
/// </summary>
public interface IHasDomainEvents
{
    /// <summary>
    /// Gets the value of the domain events
    /// </summary>
    public IReadOnlyList<IDomainEvent> DomainEvents { get; }
    /// <summary>
    /// Clears the domain events
    /// </summary>
    public void ClearDomainEvents();
}