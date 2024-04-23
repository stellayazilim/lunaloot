using LunaLoot.Master.Domain.Common.Primitives;

namespace LunaLoot.Master.Domain.Auth.ValueObjects;

public class ApplicationRolePerm: ValueObject
{

    private ApplicationRolePerm(string readType, string perm)
    {
        ReadType = readType;
        Perm = perm;
    }
    
    private ApplicationRolePerm() {}
    
    public string ReadType { get; private set; }
    
    public string Perm { get; private set; }
    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return ReadType;
        yield return Perm;
    }

    public static ApplicationRolePerm CreateNew(
        string readType,
        string perm
        ) => new(readType, perm);
}