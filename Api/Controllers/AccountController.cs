using Api.Dtos;
using Api.Entities;
using Api.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    public AccountController(IAccountService accountService, IMapper mapper, ITokenService tokenService)
    {
        _accountService = accountService;
        _mapper = mapper;
        _tokenService = tokenService;
    }

    [HttpPost(Name = "confirm-email")]
    public ActionResult ConfirmEmail()
    {
        return Ok();
    }

    [HttpPut("change-password")]
    public ActionResult ChangePasword(ChangePasswordDto changePasswordDto)
    {
        return Ok();
    }

    [HttpPut("update-status")]
    public ActionResult UpdateStatus(string status)
    {
        return Ok();
    }

    [HttpPut("edit-avatar")]
    public ActionResult UpdateAvatar(string avatarUrl)
    {
        return Ok();
    }

    [HttpPut("edit-backgroud")]
    public ActionResult UpdateBackground(string avatarUrl)
    {
        return Ok();
    }

    [HttpPost("create")]
    public async Task<ActionResult<UserDto>> Create(AccountSignUpDto accountSignUpDto)
    {
        if (await _accountService.CheckUsernameExistedAsync(accountSignUpDto.UserName))
        {
            return BadRequest("Username is existed");
        }

        if (await _accountService.CheckEmailExistedAsync(accountSignUpDto.Email))
        {
            return BadRequest("Email is existed");
        }

        var user = _mapper.Map<AppUser>(accountSignUpDto);

        var result = await _accountService.CreateAccountAsync(user, accountSignUpDto.Password);

        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
    
        var roleResult = await _accountService.AddToRoleAsync(user, "Member");

        if (!roleResult.Succeeded)
        {
            return BadRequest(result.Errors);
        }

        user = await _accountService.GetUserByUserNameAsync(user.UserName);

        return Ok(new UserDto
        {
            UserName = user.UserName,
            Token = await _tokenService.CreateTokenAsync(user),
            UserId = user.Id
        });
    }
}
