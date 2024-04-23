using LunaLoot.Master.Domain.Auth;

namespace LunaLoot.Master.Application.Auth.Queries.LoginWithCredentials;

public record LoginWithPasswordQueryResult(
    ApplicationUser User,
    string Token);