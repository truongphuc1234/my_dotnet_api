using Api.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Interfaces;

public interface IAccountService
{
    Task<bool> CheckEmailExistedAsync(string email);
    Task<bool> CheckUsernameExistedAsync(string userName);
    Task<IdentityResult> AddToRoleAsync(AppUser user, string role);
    Task<IdentityResult> CreateAccountAsync(AppUser user, string password);
    Task<AppUser> GetUserByUserNameAsync(string userName);
    Task<AppUser> GetUserByIdAsync(int userId);
}