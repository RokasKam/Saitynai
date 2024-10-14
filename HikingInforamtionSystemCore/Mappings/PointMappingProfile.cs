using AutoMapper;
using HikingInforamtionSystemCore.Requests.Point;
using HikingInforamtionSystemCore.Responses.Point;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Mappings;

public class PointMappingProfile : Profile
{
    public PointMappingProfile()
    {
        CreateMap<Point, PointResponse>();
        CreateMap<PointRequest, Point>();
    }
}