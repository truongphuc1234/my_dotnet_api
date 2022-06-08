using Api.Dtos;
using Api.Entities;
using Microsoft.AspNetCore.Identity;

namespace Api.Interfaces;

public interface IAuthService
{
    public Task<SignInResult> Login(AppUser user, string password);
}