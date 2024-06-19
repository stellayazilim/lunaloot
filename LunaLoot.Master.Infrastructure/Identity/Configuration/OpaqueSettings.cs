namespace LunaLoot.Master.Infrastructure.Identity.Configuration;

public class OpaqueSettings
{
    public const string SectionName = "Products:RefreshToken";
    
    public int ExpiryInMinutes { get; init; }
}