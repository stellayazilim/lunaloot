namespace LunaLoot.Master.Application.Common.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get;  }
}