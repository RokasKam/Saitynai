using AutoMapper;
using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Mappings;

public class HikeMappingProfile : Profile
{
    public HikeMappingProfile()
    {
        CreateMap<Hike, HikeResponse>();
        CreateMap<HikeRequest, Hike>();
    }
}