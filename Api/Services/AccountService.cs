using System.Threading.Tasks;
using Api.Entities;
using Api.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class AccountService : IAccountService
{
    private readonly UserManager<AppUser> _userManager;
    public AccountService(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<IdentityResult> AddToRoleAsync(AppUser user, string role)
    {
        return await _userManager.AddToRoleAsync(user, role);
    }

    public async Task<bool> CheckEmailExistedAsync(string email)
    {
        return await _userManager.Users.AnyAsync(u => u.NormalizedEmail == email.ToUpper());
    }

    public async Task<bool> CheckUsernameExistedAsync(string userName)
    {
        return await _userManager.Users.AnyAsync(u => u.NormalizedUserName == userName.ToUpper());
    }

    public async Task<IdentityResult> CreateAccountAsync(AppUser user, string password)
    {
        return await _userManager.CreateAsync(user, password);
    }

    public async Task<AppUser> GetUserByIdAsync(int userId)
    {
        return await _userManager.Users.FirstAsync(x => x.Id == userId);
    }

    public async Task<AppUser> GetUserByUserNameAsync(string userName)
    {
        return await _userManager.Users.FirstAsync(x => x.UserName == userName);
    }
}