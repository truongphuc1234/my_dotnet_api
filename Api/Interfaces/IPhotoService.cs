
using System.Threading.Tasks;
using Api.Dtos;
using Api.Entities;
using Microsoft.AspNetCore.Http;

namespace Api.Interfaces;

public interface IPhotoService
{
    Task<int> UploadPhotoAsync(IFormFile files, UserProfile userProfile);
}