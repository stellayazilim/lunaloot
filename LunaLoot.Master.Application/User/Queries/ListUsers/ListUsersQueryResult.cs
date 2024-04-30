using LunaLoot.Master.Domain.Identity;

namespace LunaLoot.Master.Application.User.Queries.ListUsers;

public record ListUsersQueryResult(
        List<IdentityUser> Users,
        uint Count
    );