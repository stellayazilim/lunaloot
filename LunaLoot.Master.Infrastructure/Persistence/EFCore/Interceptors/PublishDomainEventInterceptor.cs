using LunaLoot.Master.Domain.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;

/// <summary>
/// The publish domain event interceptor class
/// </summary>
/// <seealso cref="SaveChangesInterceptor"/>
public class PublishDomainEventInterceptor(
        IPublisher mediator
    ): SaveChangesInterceptor
{
    /// <summary>
    /// Savings the changes using the specified event data
    /// </summary>
    /// <param name="eventData">The event data</param>
    /// <param name="result">The result</param>
    /// <returns>An interception result of int</returns>
    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        PublishDomainEvents(eventData.Context).GetAwaiter().GetResult();
        
        return base.SavingChanges(eventData, result);
    }

    /// <summary>
    /// Savings the changes using the specified event data
    /// </summary>
    /// <param name="eventData">The event data</param>
    /// <param name="result">The result</param>
    /// <param name="cancellationToken">The cancellation token</param>
    /// <returns>A value task of interception result int</returns>
    public override async ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new CancellationToken())
    {
        await PublishDomainEvents(eventData.Context);
        return await base.SavingChangesAsync(eventData, result, cancellationToken);
    }


    /// <summary>
    /// Publishes the domain events using the specified db context
    /// </summary>
    /// <param name="dbContext">The db context</param>
    private async Task PublishDomainEvents(DbContext? dbContext)
    {
        
        if (dbContext is null) return;
        
        // get entities that has domain events
        var entities = dbContext.ChangeTracker.Entries<IHasDomainEvents>()
            .Where(entry => entry.Entity.DomainEvents.Any())
            .Select(entry => entry.Entity)
            .ToList();
        
        // get domain events
        var domainEvents = entities.SelectMany(entry => entry.DomainEvents).ToList();
        
        // clear domain events
        entities.ForEach( entity => entity.ClearDomainEvents());
        
        // publish events
        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent);
        }
    }
}