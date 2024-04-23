namespace LunaLoot.Master.Application.Common.Services;

public interface IOtpGenerator
{
    string Generate();
    Task<string> GenerateAsync();

    /// <summary>
    /// Generates otp code that valid for same identifier
    /// </summary>
    /// <returns> otp code </returns>
    string GenerateOnIdentifier();
    Task<string> GenerateOnIdentifierAsync<TIdentifier>(TIdentifier identifier);
}