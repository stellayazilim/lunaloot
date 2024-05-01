using LunaLoot.Master.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Api.Controller;

[Route("user")]
public class UserController: ApiController
{

    [HttpGet("")]
    public IActionResult GetUsers(CancellationToken cancellationToken)
    {
        return Ok();
    }
}