using LunaLoot.Master.Domain.Identity;

namespace LunaLoot.Master.Application.Features.Identity.Interfaces;

/// <summary>
/// The login model
/// </summary>
public record LoginResult(
    IdentityUser User,
    LoginResultTokens Tokens
    );

/// <summary>
/// The login token model
/// </summary>
public record LoginResultTokens(
    string AccessToken,
    string RefreshToken);