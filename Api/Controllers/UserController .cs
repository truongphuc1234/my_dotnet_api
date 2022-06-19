using System.Threading.Tasks;
using Api.Dtos;
using Api.Entities;
using Api.Interfaces;
using Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Api.Data;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserProfileService _userProfileService;
    private readonly IMapper _mapper;
    private readonly ITokenService _tokenService;
    private readonly UserManager<AppUser> _userManager;
    private readonly IPhotoService _photoService;
    public UserController(IUserProfileService userProfileService, IPhotoService photoService, IMapper mapper, ITokenService tokenService, UserManager<AppUser> userManager)
    {
        _userProfileService = userProfileService;
        _mapper = mapper;
        _tokenService = tokenService;
        _userManager = userManager;
        _photoService = photoService;
    }

    [HttpPut("update-status")]
    public ActionResult UpdateStatus(string status)
    {
        return Ok();
    }

    [HttpPut("change-avatar")]
    public ActionResult UpdateAvatar(string avatarUrl)
    {
        return Ok();
    }

    [HttpPut("change-backgroud")]
    public ActionResult UpdateBackground(string avatarUrl)
    {
        return Ok();
    }

    [HttpPost("upload-photo")]
    public async Task<ActionResult> UploadPhotoAsync(IFormFile file)
    {
        var user = await _userManager.GetUserAsync(User);
        var userProfile = await _userProfileService.GetByAppUserId(user.Id);
        var uploadResult = await _photoService.UploadPhotoAsync(file, userProfile!);
        
        if (uploadResult == 0)
        {
            return BadRequest("Unable to upload");
        }
        return Ok();
    }
}
