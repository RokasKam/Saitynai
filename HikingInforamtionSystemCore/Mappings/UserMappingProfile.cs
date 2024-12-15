using AutoMapper;
using HikingInforamtionSystemCore.Requests.Auth;
using HikingInforamtionSystemCore.Responses.Auth;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Mappings;

public class UserMappingProfile : Profile
{
    public UserMappingProfile()
    {
        CreateMap<RegisterRequest, User>();
        CreateMap<User, UserResponse>();
    }
}