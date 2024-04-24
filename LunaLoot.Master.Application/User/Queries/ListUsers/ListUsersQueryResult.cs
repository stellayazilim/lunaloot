using LunaLoot.Master.Domain.Auth;

namespace LunaLoot.Master.Application.User.Queries.ListUsers;

public record ListUsersQueryResult(
        List<ApplicationUser> Users,
        uint Count
    );