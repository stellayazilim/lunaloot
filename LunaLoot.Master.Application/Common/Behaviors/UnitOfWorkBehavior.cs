using System.Transactions;
using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using MediatR;

namespace LunaLoot.Master.Application.Common.Behaviors;


/// <summary>
/// Calls IUnitOfWork.SaveChangesAsync() after every IRequestHandler invocation
/// Transactions commit after exection request handlers
/// or rollback if error occours within transaction
/// </summary>
/// <param name="unitOfWork"> <see cref="IUnitOfWork"/></param>
/// <typeparam name="TRequest"> <see cref="IRequest"/></typeparam>
/// <typeparam name="TResponse"> <see cref="ErrorOr{TValue}"/> </typeparam>
public sealed class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork unitOfWork
    ): IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
    where TResponse: IErrorOr 
{
    
    /// <exception cref="LunaLoot.Infrastructure.Persistence.EFCore.Exceptions"></exception>
    /// <inheritdoc cref="LunaLoot.Infrastructure.Persistence.EFCore.UnitOfWork#SaveChangesAsync"/>
    /// </summary>
    /// <param name="request"> RequestEvent: IRequest </param>
    /// <param name="next"> Excecuted RequestHandler: IRequestHandler </param>
    /// <param name="cancellationToken"> Cancelation token </param>
    /// <returns></returns>
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!typeof(TRequest).Name.EndsWith("Command")) return await next();

        // ReSharper disable once ConvertToUsingDeclaration
        // ReSharper disable once HeapView.ObjectAllocation.Evident
        using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled)) 
        {
            var result = await next();
            var changes = await unitOfWork.SaveChangesAsync(cancellationToken);
            transactionScope.Complete();
            // ReSharper disable once HeapView.PossibleBoxingAllocation
            // @todo rid of (dynamic) casting
            return changes.IsError ? (dynamic)changes.Errors : result;
        }
    }
}