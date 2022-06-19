using System.Threading.Tasks;
using Api.Dtos;
using Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IAuthService _authService;
    private readonly ITokenService _tokenService;
    private readonly IUserProfileService _userProfileService;

    public AuthController(IAccountService accountService, IAuthService authService, ITokenService tokenService, IUserProfileService userProfileService)
    {
        _accountService = accountService;
        _authService = authService;
        _tokenService = tokenService;
        _userProfileService = userProfileService;
    }

    [HttpPost("Login")]
    public async Task<ActionResult> Login(LoginRequestDto loginRequest)
    {
        var user = await _accountService.GetUserByUserNameAsync(loginRequest.UserName);

        if (user == null)
        {
            return BadRequest("User is not existed");
        }

        var loginResult = await _authService.Login(user, loginRequest.Password);
        if (!loginResult.Succeeded)
        {
            return Unauthorized();
        }

        return Ok(
            new UserDto
            {
                UserId = user.Id,
                UserName = user.UserName,
                Token = await _tokenService.CreateTokenAsync(user)
            }
        );
    }
}
