using System.Transactions;
using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using MediatR;

namespace LunaLoot.Master.Application.Common.Behaviors;

public sealed class UnitOfWorkBehavior<TRequest, TResponse>(
    IUnitOfWork unitOfWork
    ): IPipelineBehavior<TRequest, TResponse>
    where TRequest: IRequest<TResponse>
    where TResponse: IErrorOr 
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!typeof(TRequest).Name.EndsWith("Command")) return await next();

        // ReSharper disable once ConvertToUsingDeclaration
        using (var transactionScope = new TransactionScope()) 
        {
            var result = await next();

            await unitOfWork.SaveChangesAsync(cancellationToken);
            
            transactionScope.Complete();
            return result;
        }
       
    }
}