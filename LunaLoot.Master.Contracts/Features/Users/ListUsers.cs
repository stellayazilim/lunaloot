using LunaLoot.Master.Application.Features.Identity.Queries.ListUsers;
using Microsoft.AspNetCore.Mvc;


namespace LunaLoot.Master.Contracts.Features.Users;


public record ListUsersResponse
{
    public required List<ListUsersResponseUserItem> Users { get; init; }
    public static IActionResult ToActionResult(ListUsersQueryResult result)
    {
        return new OkObjectResult(new
        {
            Users = result.Users.ConvertAll(x => new ListUsersResponseUserItem
            {
                Email = x.Email
            })
        });
    }
}

public record ListUsersResponseUserItem
{
    // ReSharper disable once NullableWarningSuppressionIsUsed
    public string Email { get; set; } = null!;
}
