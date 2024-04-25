
namespace LunaLoot.Master.Domain.Common.Enums;

/// <summary>
/// Applying the attribute indicates the enum can be treated as a bit field, i.e. a set of flags.
/// Note: Values are powers of 2, e.g. 2, 4, 8, 16, ...
/// ~None - The operator ~ produces a complement of its operand by reversing each bit,
/// So ~00000 = 11111 = A, B, C, D, E
/// var userPermissions = Permissions.A | Permissions.C     => 00001 + 00100 = 00101 = 5
/// var requiredPermissions = Permissions.A | Permissions.B => 00001 + 00010 = 00011 = 3
/// </summary>
[Flags]
public enum Permissions {
    None = 0,            // 00000
    ReadMember = 1,      // 00001
    ManageMember = 2,    // 00010
    DeleteMember = 4,    // 00100
    All = ~None          // 11111
    
}
