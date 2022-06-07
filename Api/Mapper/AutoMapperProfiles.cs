using Api.Dtos;
using Api.Entities;
using AutoMapper;

namespace Api.Mapper;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<AccountSignUpDto, AppUser>();
    }
}