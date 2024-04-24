using LunaLoot.Master.Domain.Address;
using LunaLoot.Master.Domain.Auth;
using LunaLoot.Master.Domain.Auth.Entities;
using LunaLoot.Master.Domain.Auth.ValueObjects;
using LunaLoot.Master.Infrastructure.Auth;
using LunaLoot.Master.Infrastructure.Persistence.EFCore;
using LunaLoot.Master.Infrastructure.Persistence.EFCore.Interceptors;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LunaLoot.Master.Seed;

public static class Program
{
    public static void Main()
    {
        
        var opb = new DbContextOptionsBuilder<LunaLootMasterDbContext>();

        opb.UseNpgsql("Server=127.0.0.1;Port=5432;Database=LunaLootMaster;User Id=postgres;Password=postgres;");
        var dbContext = new LunaLootMasterDbContext(
            new PublishDomainEventInterceptor(new Mediator(null)),
            opb.Options);



        var administratorRole = ApplicationRole.CreateNew(
            "Administrator",
            1,
            new()
            {
                Permissions.User.All,
                Permissions.Role.All
            }
        );

        var  administratorAddress = Address.CreateNew(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty
            );

        var administratorUser = ApplicationUser.CreateNew(
                    string.Empty,
                    string.Empty,
                    "administrator2@master.lunaloot.com",
                    "05555555555",
                    "administrator",
                    string.Empty,
                new ()
                {
                    administratorAddress.Id
                },
                new()
                {
                    dbContext.ApplicationRoles.Find(ApplicationRoleId.Parse(Guid.Parse("2ee48831-739b-48ab-943c-47b94719d59f"))) ?? administratorRole
                }
            );


        
        dbContext.Addresses.Add(administratorAddress);
        dbContext.ApplicationUsers.Add(administratorUser);
        dbContext.SaveChanges();
    }
}