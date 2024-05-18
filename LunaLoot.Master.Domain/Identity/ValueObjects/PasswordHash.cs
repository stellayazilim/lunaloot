
using System.Security.Cryptography;
using DevOne.Security.Cryptography.BCrypt;
using LunaLoot.Master.Domain.Common.Interfaces;
using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Identity.ValueObjects;

public class PasswordHash: ValueObject, IPasswordHasher
{
    private const int SaltSize =  8;
    private string Salt => BCryptHelper.GenerateSalt(SaltSize);
    
    public string Value { get; protected set; }
    
    protected PasswordHash() {}
    
    protected PasswordHash(string value)
    {
        Hash(value);
    }

    public static PasswordHash GenerateHashedPassword(string value) => new(value);
    
    public static PasswordHash Parse(string value) => new PasswordHash()
    {
        Value = value
    };
    
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }


    public void Hash(string password)
    {
        Value = BCryptHelper.HashPassword(password, Salt);
    }

    public bool Verify(string password)
    {
        return BCryptHelper.CheckPassword(password, Value);
    }
}