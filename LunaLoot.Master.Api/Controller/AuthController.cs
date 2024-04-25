using LunaLoot.Master.Api.Common;
using Microsoft.AspNetCore.Mvc;

namespace LunaLoot.Master.Api.Controller;

[Route("auth")]
public class AuthController: ApiController
{

    [HttpPost("login")]
    public async Task<IActionResult> Login()
    {
        await Task.CompletedTask;
        return Ok();
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register()
    {
        await Task.CompletedTask;
        return Ok();
    }
}