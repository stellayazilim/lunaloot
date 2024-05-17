using MediatR;
using ErrorOr;
using LunaLoot.Master.Application.Common.Persistence;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListUsers;

public sealed class ListUsersQueryHandler(
    IUnitOfWork unitOfWork): IRequestHandler<ListUsersQuery, ErrorOr<ListUsersQueryResult>>
{
    public async Task<ErrorOr<ListUsersQueryResult>> Handle(ListUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await unitOfWork.UserRepository.GetAllAsync();

        return new ListUsersQueryResult(
            Users: users.Value);
    }
}