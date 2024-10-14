using AutoMapper;
using HikingInforamtionSystemCore.Interfaces;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Point;
using HikingInforamtionSystemCore.Responses.Point;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemDomain.Exceptions;

namespace HikingInforamtionSystemCore.Services;

public class PointService : IPointService
{
    private readonly IPointRepository _pointRepository;
    private readonly IRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public PointService(IPointRepository pointRepository, IMapper mapper, IRouteRepository routeRepository)
    {
        _pointRepository = pointRepository;
        _mapper = mapper;
        _routeRepository = routeRepository;
    }

    public PointResponse GetPointById(Guid id)
    {
        var pointEntity = _pointRepository.GetPointById(id);
        if (pointEntity == null)
        {
            throw new NotFoundException($"Point with Id: {id} was not found");
        }

        var pointResponse = _mapper.Map<PointResponse>(pointEntity);
        return pointResponse;
    }

    public IEnumerable<PointResponse> GetPoints()
    {
        var pointEntities = _pointRepository.GetPoints();
        var pointResponses = _mapper.Map<IEnumerable<PointResponse>>(pointEntities);
        return pointResponses;
    }

    public Guid AddPoint(PointRequest pointRequest)
    {
        var routeExists = _routeRepository.RouteExists(pointRequest.RouteId);
        if (!routeExists)
        {
            throw new NotFoundException($"Route with Id: {pointRequest.RouteId} was not found");
        }
        
        var pointEntity = _mapper.Map<Point>(pointRequest);
        var pointId = _pointRepository.AddPoint(pointEntity);
        return pointId;
    }

    public bool UpdatePoint(Guid id, PointRequest pointRequest)
    {
        var pointExists = _pointRepository.PointExists(id);
        if (!pointExists)
        {
            throw new NotFoundException($"Point with Id: {id} was not found");
        }
        
        var routeExists = _routeRepository.RouteExists(pointRequest.RouteId);
        if (!routeExists)
        {
            throw new NotFoundException($"Route with Id: {pointRequest.RouteId} was not found");
        }

        var pointEntity = _mapper.Map<Point>(pointRequest);
        pointEntity.Id = id;

        var result = _pointRepository.UpdatePoint(pointEntity);
        return result;
    }

    public bool DeletePoint(Guid id)
    {
        var pointExists = _pointRepository.PointExists(id);
        if (!pointExists)
        {
            throw new NotFoundException($"Point with Id: {id} was not found");
        }

        var result = _pointRepository.DeletePoint(id);
        return result;
    }
}