using ErrorOr;
using MediatR;

namespace LunaLoot.Master.Application.User.Queries.ListUsers;

public record ListUsersQuery(): IRequest<ErrorOr<ListUsersQueryResult>>;