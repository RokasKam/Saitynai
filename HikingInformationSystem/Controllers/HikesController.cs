using System.Security.Claims;
using HikingInforamtionSystemCore.Helpers.Auth;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Hike;
using HikingInformationSystemDomain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class HikesController : BaseController
{
    private readonly IHikeService _hikeService;

    public HikesController(IHikeService hikeService)
    {
        _hikeService = hikeService;
    }
    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet("{id}")]
    public IActionResult GetHikeById(Guid id)
    {
        var hike = _hikeService.GetHikeById(id);
        return Ok(hike);
    }

    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet]
    public IActionResult GetHikes()
    {
        var hikes = _hikeService.GetHikes();
        return Ok(hikes);
    }
    
    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpGet("/{hikeId}/Routes/{routeId}/Points")]
    public IActionResult GetHike(Guid hikeId, Guid routeId)
    {
        var hikes = _hikeService.GetHikeWithSpecificRouteAndPoints(routeId, hikeId);
        return Ok(hikes);
    }

    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpPost]
    public IActionResult AddHike([FromBody] HikeRequest hikeRequest)
    {
        if (User.IsInRole(UserRoles.Hiker))
        {
            return Forbid();
        }
        var createdHikeId = _hikeService.AddHike(hikeRequest, User.FindFirstValue(ClaimTypes.NameIdentifier));
        return CreatedAtAction(nameof(GetHikeById), new { id = createdHikeId }, createdHikeId);
    }

    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpPut("{id}")]
    public IActionResult UpdateHike(Guid id, [FromBody] HikeRequest hikeRequest)
    {
        var result = _hikeService.UpdateHike(id, hikeRequest);
        return Ok(result);
    }
    [Authorize(Policy = PolicyNames.AdminRole)]
    [HttpDelete("{id}")]
    public IActionResult DeleteHike(Guid id)
    {
        return Ok(_hikeService.DeleteHike(id));
    }
}