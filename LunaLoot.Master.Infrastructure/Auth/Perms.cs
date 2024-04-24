using System.ComponentModel;
using System.Runtime.Serialization;

namespace LunaLoot.Master.Infrastructure.Auth;


public static class Permissions
{
    public static class User
    {
        public const string All = "user.all";
        public const string UserReadEmail = "user.read.email";
        public const string UserWriteEmail = "user.write.email";
        public const string UserReadName = "user.read.name";
        public const string UserWriteName = "user.write.name";
        public const string UserReadPhoneNumber = "user.read.phone";
        public const string UserWritePhoneNumber = "user.write.phone";
    }

    public static class Role
    {
        public const string All = "role.all";
        
        [Description("actor can read perms of role")]
        [EnumMember(Value = "role.read.perms")]
        public const string RoleReadPerms = "role.read.perms";

        [Description("Update perms of role if actor has higher weight than the role")]
        [EnumMember(Value = "role.write.perms")]
        public const string RoleWritePerms = "role.write.perms";

        [Description("Created role must have lesser weight than actor")] 
        [EnumMember(Value = "role.add.role")]
        public const string RoleAddRole = "role.add.role";

        [Description("Actor can delete role if has higher weight than role")] 
        [EnumMember(Value = "role.remove.role")]
        public const string RoleRemoveRole = "role.remove.role";
    }
}
