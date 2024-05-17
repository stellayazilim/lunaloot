using MediatR;
using ErrorOr;
using LunaLoot.Master.Domain.Identity;
namespace LunaLoot.Master.Application.Features.Identity.Queries.ListUsers;

public record ListUsersQuery: IRequest<ErrorOr<ListUsersQueryResult>>;


public record ListUsersQueryResult(
    List<IdentityUser> Users
    );