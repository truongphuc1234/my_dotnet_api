using Api.Dtos;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;
    public AuthController(IAccountService accountService)
    {
        _accountService = accountService;

    }
    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginRequestDto loginRequest)
    {
        var user = await _accountService.GetUserByUserNameAsync(loginRequest.UserName);

        if (user == null)
        {
            return BadRequest("User is not existed");
        }
        
    }

    [HttpPost("Logout")]
    public ActionResult Logout()
    {
        return Ok();
    }
}
