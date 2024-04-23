using System.ComponentModel;
using System.Runtime.Serialization;

namespace LunaLoot.Master.Infrastructure.Auth;


public static class Permissions
{
    public enum User 
    {
        [EnumMember(Value = "user.read.email")]
        UserReadEmail,
        [EnumMember(Value = "user.write.email")]
        UserWriteEmail,
        [EnumMember(Value = "user.read.name")]
        UserReadName,
        [EnumMember(Value = "user.write.name")]
        UserWriteName,
        [EnumMember(Value = "user.read.phone")]
        UserReadPhoneNumber,
        [EnumMember(Value = "user.write.phone")]
        UserWritePhoneNumber,
    }
}
