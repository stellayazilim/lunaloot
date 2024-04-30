namespace LunaLoot.Master.Domain.Common.Interfaces;

public interface IPasswordHasher
{
    void Hash(string password);
    bool Verify(string password);
}