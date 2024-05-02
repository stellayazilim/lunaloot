using ErrorOr;

namespace LunaLoot.Master.Domain.Common.Errors;

public static partial class Errors
{
    public static class Generic<T>
    {
        public static Error DuplicateError
            => Error.Conflict(code: $"{nameof(T)}.Duplicate", description: $"{nameof(T)} already exists");
        public static Error DoesNotExistError()
            => Error.NotFound(code:  $"{nameof(T)}.NotFound", description: $"{nameof(T)} does not exist");
    }
}