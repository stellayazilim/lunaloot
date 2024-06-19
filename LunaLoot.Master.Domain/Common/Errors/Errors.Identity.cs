using ErrorOr;

namespace LunaLoot.Master.Domain.Common.Errors;

public static partial class Errors
{
    public static class Identity
    {
        public static Error DuplicateEmailError(string email)
            => Error.Conflict(code: "Products.DuplicateEmail", description: $"{email} already exists");
        public static Error UserDoesNotExistError
            => Error.NotFound(code: "Products.UserDoesNotExist", description: "User does not exist");

        public static Error InvalidCredentials
            => Error.Validation(code: "Products.InvalidCredentials", description: "Provided credentials are invalid");

        public static Error RoleTenantDoesNotExistError
            => Error.NotFound(code: "Itentity.RoleDoesNotExist", description: "Role \"Tenant\" does not exist");
    }
}