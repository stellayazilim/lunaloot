
using Ardalis.SmartEnum;

namespace LunaLoot.Master.Domain.Identity.Enums;


[Flags]
public  enum Permissions
{

   None = 0,
   ReadUser,
   EditUser,
   ReadRole,
   EditRole,
   All = ~None
}