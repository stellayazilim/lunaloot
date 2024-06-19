using Microsoft.AspNetCore.Mvc;
using EmptyResult = LunaLoot.Tenant.Application.Common.Models.EmptyResult;

namespace LunaLoot.Tenant.Api.Contracts.Common;

public record EmptyResponse
{
    public static IActionResult ToActionResult(EmptyResult result)
    {
        return new OkObjectResult(new EmptyResponse());
    }
};