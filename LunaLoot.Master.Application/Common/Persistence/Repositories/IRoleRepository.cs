using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
using LunaLoot.Master.Domain.Auth.ValueObjects;

namespace LunaLoot.Master.Application.Common.Persistence.Repositories;

public interface IRoleRepository: IRepository<ApplicationRole, ApplicationRoleId>
{
   
   List<ApplicationUser> GetUsersInRole(ApplicationRole role);
   
}