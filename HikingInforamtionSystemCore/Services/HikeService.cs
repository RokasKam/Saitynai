using AutoMapper;
using HikingInforamtionSystemCore.Interfaces;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;
using HikingInforamtionSystemCore.Responses.Point;
using HikingInforamtionSystemCore.Responses.Route;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemDomain.Exceptions;

namespace HikingInforamtionSystemCore.Services;

public class HikeService : IHikeService
{
    private readonly IHikeRepository _hikeRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IPointRepository _pointRepository;
    private readonly IMapper _mapper;

    public HikeService(IHikeRepository hikeRepository, IMapper mapper, IPointRepository pointRepository, IRouteRepository routeRepository)
    {
        _hikeRepository = hikeRepository;
        _mapper = mapper;
        _pointRepository = pointRepository;
        _routeRepository = routeRepository;
    }

    public HikeResponse GetHikeById(Guid id)
    {
        var hikeEntity = _hikeRepository.GetHikeById(id);
        if (hikeEntity == null)
        {
            throw new NotFoundException($"Hike with Id: {id} was not found");
        }

        var hikeResponse = _mapper.Map<HikeResponse>(hikeEntity);
        return hikeResponse;
    }

    public IEnumerable<HikeResponse> GetHikes()
    {
        var hikeEntities = _hikeRepository.GetHikes();
        var hikeResponses = _mapper.Map<IEnumerable<HikeResponse>>(hikeEntities);
        return hikeResponses;
    }

    public IEnumerable<HikeResponse> GetHikesByCreatorId(string creatorId)
    {
        var hikeEntities = _hikeRepository.GetHikesByCreator(creatorId);
        var hikeResponses = _mapper.Map<IEnumerable<HikeResponse>>(hikeEntities);
        return hikeResponses;    }

    public HikeWithSpecificRouteAndPoints GetHikeWithSpecificRouteAndPoints(Guid routeId, Guid hikeId)
    {
        var hikeEntity = _hikeRepository.GetHikeById(hikeId);
        if (hikeEntity == null)
        {
            throw new NotFoundException($"Hike with Id: {hikeId} was not found");
        }
        
        var routeEntity = _routeRepository.GetRouteById(routeId);
        if (routeEntity == null)
        {
            throw new NotFoundException($"Route with Id: {routeId} was not found");
        }

        if (hikeEntity.Id != routeEntity.HikeId)
        {
            throw new NotFoundException($"Hike {hikeId} does not contain {routeId} route");
        }

        var pointsResponse = _pointRepository.GetPointsByRouteId(routeId);
        var hikeResponse = _mapper.Map<HikeWithSpecificRouteAndPoints>(hikeEntity);
        hikeResponse.RouteWithPoints = _mapper.Map<RouteWithPointsResponse>(routeEntity);
        hikeResponse.RouteWithPoints.Points = _mapper.Map<IEnumerable<PointResponse>>(pointsResponse);
        return hikeResponse;
    }

    public HikeWithRoutes GetHikeWithRoutes(Guid hikeId)
    {
        var hikeEntity = _hikeRepository.GetHikeById(hikeId);
        if (hikeEntity == null)
        {
            throw new NotFoundException($"Hike with Id: {hikeId} was not found");
        }
        var routeEntities = _routeRepository.GetRoutesByHikeId(hikeId);
        var hikeResponse = _mapper.Map<HikeWithRoutes>(hikeEntity);
        hikeResponse.Routes = _mapper.Map<IEnumerable<RouteResponse>>(routeEntities);
        return hikeResponse;
    }

    public Guid AddHike(HikeRequest hikeRequest, string userId)
    {
        var hikeEntity = _mapper.Map<Hike>(hikeRequest);
        hikeEntity.CreatorId = userId;
        var hikeId = _hikeRepository.AddHike(hikeEntity);
        return hikeId;
    }

    public bool UpdateHike(Guid id, HikeRequest hikeRequest, string userId)
    {
        var oldHikeEntity = _hikeRepository.GetHikeById(id);
        if (oldHikeEntity == null)
        {
            throw new NotFoundException($"Hike with Id: {id} was not found");
        }
        if (oldHikeEntity.CreatorId != userId)
        {
            throw new ForbbidenException($"You cannot edit the hike with Id: {id}");
        }

        var hikeEntity = _mapper.Map<Hike>(hikeRequest);
        hikeEntity.Id = id;
        hikeEntity.CreatorId = oldHikeEntity.CreatorId;

        var result = _hikeRepository.UpdateHike(hikeEntity);
        return result;
    }

    public bool DeleteHike(Guid id, string userId)
    {
        var oldHikeEntity = _hikeRepository.GetHikeById(id);
        if (oldHikeEntity == null)
        {
            throw new NotFoundException($"Hike with Id: {id} was not found");
        }
        if (oldHikeEntity.CreatorId != userId)
        {
            throw new ForbbidenException($"You cannot delete the hike with Id: {id}");
        }

        var result = _hikeRepository.DeleteHike(id);
        return result;
    }
}