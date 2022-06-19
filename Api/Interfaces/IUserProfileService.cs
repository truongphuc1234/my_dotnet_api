
using System.Threading.Tasks;
using Api.Entities;

namespace Api.Interfaces;

public interface IUserProfileService
{
    Task<UserProfile?> GetByAppUserId(int appUserId);
    Task<UserProfile?> CreateUserProfile(AppUser appUser);
}