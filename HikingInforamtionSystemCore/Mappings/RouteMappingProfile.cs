using AutoMapper;
using HikingInforamtionSystemCore.Requests.Route;
using HikingInforamtionSystemCore.Responses.Route;
using HikingInformationSystemDomain.Entities;

namespace HikingInforamtionSystemCore.Mappings;

public class RouteMappingProfile : Profile
{
    public RouteMappingProfile()
    {
        CreateMap<Route, RouteResponse>();
        CreateMap<Route, RouteWithPointsResponse>();
        CreateMap<RouteRequest, Route>();
    }
}