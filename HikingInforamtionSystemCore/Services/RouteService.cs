using AutoMapper;
using HikingInforamtionSystemCore.Interfaces;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Route;
using HikingInforamtionSystemCore.Responses.Point;
using HikingInforamtionSystemCore.Responses.Route;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemDomain.Exceptions;

namespace HikingInforamtionSystemCore.Services;

public class RouteService : IRouteService
{
    private readonly IRouteRepository _routeRepository;
    private readonly IHikeRepository _hikeRepository;
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;

    public RouteService(IRouteRepository routeRepository, IMapper mapper, IHikeRepository hikeRepository, IPointRepository pointRepository)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
        _hikeRepository = hikeRepository;
        _pointRepository = pointRepository;
    }

    public RouteResponse GetRouteById(Guid id)
    {
        var routeEntity = _routeRepository.GetRouteById(id);
        if (routeEntity == null)
        {
            throw new NotFoundException($"Route with Id: {id} was not found");
        }

        var routeResponse = _mapper.Map<RouteResponse>(routeEntity);
        return routeResponse;
    }

    public IEnumerable<RouteResponse> GetRoutes()
    {
        var routeEntities = _routeRepository.GetRoutes();
        var routeResponses = _mapper.Map<IEnumerable<RouteResponse>>(routeEntities);
        return routeResponses;
    }

    public Guid AddRoute(RouteRequest routeRequest)
    {
        var hikeExists = _hikeRepository.HikeExists(routeRequest.HikeId);
        if (!hikeExists)
        {
            throw new NotFoundException($"Hike with Id: {routeRequest.HikeId} was not found");
        }
        
        var routeEntity = _mapper.Map<Route>(routeRequest);
        var routeId = _routeRepository.AddRoute(routeEntity);
        return routeId;
    }

    public bool UpdateRoute(Guid id, RouteRequest routeRequest)
    {
        var routeExists = _routeRepository.RouteExists(id);
        if (!routeExists)
        {
            throw new NotFoundException($"Route with Id: {id} was not found");
        }
        
        var hikeExists = _hikeRepository.HikeExists(routeRequest.HikeId);
        if (!hikeExists)
        {
            throw new NotFoundException($"Hike with Id: {routeRequest.HikeId} was not found");
        }

        var routeEntity = _mapper.Map<Route>(routeRequest);
        routeEntity.Id = id;

        var result = _routeRepository.UpdateRoute(routeEntity);
        return result;
    }

    public bool DeleteRoute(Guid id)
    {
        var routeExists = _routeRepository.RouteExists(id);
        if (!routeExists)
        {
            throw new NotFoundException($"Route with Id: {id} was not found");
        }

        var result = _routeRepository.DeleteRoute(id);
        return result;
    }
}