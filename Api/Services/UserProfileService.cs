
using System.Threading.Tasks;
using Api.Data;
using Api.Entities;
using Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Api.Services;

public class UserProfileService : IUserProfileService
{
    private readonly ApplicationDbContext _context;

    public UserProfileService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<UserProfile?> GetByAppUserId(int appUserId)
    {
        return await _context.UserProfiles.FirstOrDefaultAsync(up => up.UserId == appUserId);
    }

    public async Task<UserProfile?> CreateUserProfile(AppUser appUser)
    {
        var profileIsExisted = await _context.UserProfiles.AnyAsync(up => up.UserId == appUser.Id);
        
        if (profileIsExisted)
        {
            return null;
        }

        await _context.AddAsync(new UserProfile
        {
            UserId = appUser.Id
        });

        await _context.SaveChangesAsync();

        return await GetByAppUserId(appUser.Id);
    }
}
