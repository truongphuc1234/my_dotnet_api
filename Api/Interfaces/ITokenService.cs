using Api.Entities;

namespace Api.Interfaces;

public interface ITokenService
{
    Task<string> CreateTokenAsync(AppUser user);
}