using AutoMapper;
using HikingInforamtionSystemCore.Interfaces;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;
using HikingInformationSystemDomain.Entities;
using HikingInformationSystemDomain.Exceptions;

namespace HikingInforamtionSystemCore.Services;

public class HikeService : IHikeService
{
    private readonly IHikeRepository _hikeRepository;
    private readonly IMapper _mapper;

    public HikeService(IHikeRepository hikeRepository, IMapper mapper)
    {
        _hikeRepository = hikeRepository;
        _mapper = mapper;
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

    public Guid AddHike(HikeRequest hikeRequest)
    {
        var hikeEntity = _mapper.Map<Hike>(hikeRequest);
        var hikeId = _hikeRepository.AddHike(hikeEntity);
        return hikeId;
    }

    public bool UpdateHike(Guid id, HikeRequest hikeRequest)
    {
        var hikeExists = _hikeRepository.HikeExists(id);
        if (!hikeExists)
        {
            throw new NotFoundException($"Hike with Id: {id} was not found");
        }

        var hikeEntity = _mapper.Map<Hike>(hikeRequest);
        hikeEntity.Id = id;

        var result = _hikeRepository.UpdateHike(hikeEntity);
        return result;
    }

    public bool DeleteHike(Guid id)
    {
        var hikeExists = _hikeRepository.HikeExists(id);
        if (!hikeExists)
        {
            throw new NotFoundException($"Hike with Id: {id} was not found");
        }

        var result = _hikeRepository.DeleteHike(id);
        return result;
    }
}