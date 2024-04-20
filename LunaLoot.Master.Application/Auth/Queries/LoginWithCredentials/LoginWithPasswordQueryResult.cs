using LunaLoot.Master.Domain.Auth;

namespace LunaLoot.Master.Application.Auth.Queries.Login;

public record LoginWithPasswordQueryResult(
    ApplicationUser User,
    string Token);