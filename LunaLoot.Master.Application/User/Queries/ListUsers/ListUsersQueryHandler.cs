using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;
using MediatR;

namespace LunaLoot.Master.Application.User.Queries.ListUsers;

public class ListUsersQueryHandler
    (
        IUnitOfWork unitOfWork
        ): IRequestHandler<
    ListUsersQuery, ErrorOr<ListUsersQueryResult>
>
{
    public async Task<ErrorOr<ListUsersQueryResult>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.AccountRepository.GetAllAsync();
        throw new NotImplementedException();
    }
}