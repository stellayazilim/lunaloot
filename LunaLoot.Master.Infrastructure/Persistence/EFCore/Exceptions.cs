using ErrorOr;

namespace LunaLoot.Master.Infrastructure.Persistence.EFCore;

public static  partial class Errors
{
    public static class EfCore
    {
        public static Error DuplicateException => Error.Conflict(
            code: "Duplicate constraint",
            description: "Violates duplicate constraint"
            );
    }
}