using ErrorOr;
using MediatR;

namespace LunaLoot.Master.Application.Features.Identity.Queries.ListPerms;

public record ListPermsQuery: IRequest<ErrorOr<ListPermsQueryResult>>;



public record ListPermsQueryResult(
    List<KeyValuePair<string, int>> Perms,
    int Count
    );