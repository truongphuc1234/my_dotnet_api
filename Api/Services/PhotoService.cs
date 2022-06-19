using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data;
using Api.Dtos;
using Api.Entities;
using Api.Interfaces;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace Api.Services;

public class PhotoService : IPhotoService
{
    private readonly UserManager<AppUser> _userManager;
    private readonly ApplicationDbContext _context;
    private readonly Cloudinary _cloudinary;

    public PhotoService(IConfiguration config, UserManager<AppUser> userManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _context = context;
        _cloudinary = new Cloudinary(new Account(config["CloudinaryUrl"]));
    }
    public async Task<int> UploadPhotoAsync(IFormFile file, UserProfile user)
    {
        var results = new List<Dictionary<string, string>>();

        if (file == null || file.Length == 0)
        {
            return 0;
        }

        var result = await _cloudinary.UploadAsync(new ImageUploadParams
        {
            File = new FileDescription(file.FileName, file.OpenReadStream()),
        });

        if (result == null)
        {
            return 0;
        }

        var image = new Image
        {
            PublicId = result.PublicId,
            Title = file.FileName,
            Url = result.Url.AbsoluteUri,
            IsAvatar = false,
            IsBackGround = false,
            UserId = user.UserId
        };

        _context.Images.Add(image);
        return await _context.SaveChangesAsync();
    }
}