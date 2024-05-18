namespace LunaLoot.Master.Infrastructure.Identity.Configuration;

public class OpaqueSettings
{
    public const string SectionName = "Identity:RefreshToken";
    
    public int ExpiryInMinutes { get; init; }
}