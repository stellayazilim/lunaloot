namespace LunaLoot.Master.Application.Features.Identity.Models;

public record TokenResult(
    DateTime ExpiredAt,
    string Token
    );