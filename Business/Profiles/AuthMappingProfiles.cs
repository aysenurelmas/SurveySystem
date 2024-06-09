using AutoMapper;
using Business.Dtos.Auths;
using Core.DataAccess.Security.Entities;

namespace Business.Profiles;

public class AuthMappingProfiles : Profile
{
    public AuthMappingProfiles()
    {
        CreateMap<LoginResponse, User>().ReverseMap();
        CreateMap<RegisterRequest, User>().ReverseMap();
    }
}
