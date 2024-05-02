using Microsoft.AspNetCore.Mvc;
using EmptyResult = LunaLoot.Master.Application.Common.Models.EmptyResult;

namespace LunaLoot.Master.Contracts.Common.General;

public record EmptyResponse
{
    public static IActionResult ToActionResult(EmptyResult result)
    {
        return new OkObjectResult(new EmptyResponse());
    }
};