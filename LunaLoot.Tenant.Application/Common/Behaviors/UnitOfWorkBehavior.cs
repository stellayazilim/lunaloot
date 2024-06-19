using System.Transactions;
using ErrorOr;
using LunaLoot.Tenant.Application.Common.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LunaLoot.Tenant.Application.Common.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork unitOfWork,
    ILogger<UnitOfWorkBehavior<TRequest, TResponse>> logger): IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
    where TResponse: IErrorOr 
{
    
    /// <exception cref="DbLoggerCategory.Infrastructure.Persistence.EFCore.Exceptions"></exception>
    /// <inheritdoc cref="DbLoggerCategory.Infrastructure.Persistence.EFCore.UnitOfWork#SaveChangesAsync"/>
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
            
            logger.Log(LogLevel.Debug,"transaction");
            return changes.IsError ? (dynamic)changes.Errors : result;
            
        }
    }
}