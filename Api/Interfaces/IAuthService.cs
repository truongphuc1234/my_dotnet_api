using Api.Dtos;

namespace Api.Interfaces;

public interface IAuthService
{
    Task<UserDto> Login(string username, string password);
    Task<bool> Logout();
}