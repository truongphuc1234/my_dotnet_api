using Api.Dtos;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Api.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> _userManager;
    public AuthService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }
    public Task<UserDto> Login(string username, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Logout()
    {
        _userManager.
    }
}