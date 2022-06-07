using Microsoft.AspNetCore.Identity;

namespace Api.Entities;
public class AppUserRole : IdentityUserRole<int>
{
    public AppRole? Role { get; set; }
    public AppUser? User { get; set; }
}