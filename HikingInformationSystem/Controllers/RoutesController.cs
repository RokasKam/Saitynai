using System.Security.Claims;
using HikingInforamtionSystemCore.Helpers.Auth;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Route;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class RoutesController : BaseController
{
    private readonly IRouteService _routeService;

    public RoutesController(IRouteService routeService)
    {
        _routeService = routeService;
    }
    
    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet("{id}")]
    public IActionResult GetRouteById(Guid id)
    {
        var route = _routeService.GetRouteById(id);
        return Ok(route);
    }
    
    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet]
    public IActionResult GetRoutes()
    {
        var routes = _routeService.GetRoutes();
        return Ok(routes);
    }
    
    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet("{id}/Points")]
    public IActionResult GetRouteWithPoints(Guid id)
    {
        var routes = _routeService.GetRouteWithPoints(id);
        return Ok(routes);
    }

    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpPost]
    public IActionResult AddRoute([FromBody] RouteRequest routeRequest)
    {
        var createdRouteId = _routeService.AddRoute(routeRequest);
        return CreatedAtAction(nameof(GetRouteById), new { id = createdRouteId }, createdRouteId);
    }
    
    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpPut("{id}")]
    public IActionResult UpdateRoute(Guid id, [FromBody] RouteRequest routeRequest)
    {
        var result = _routeService.UpdateRoute(id, routeRequest, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return Ok(result);
    }

    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpDelete("{id}")]
    public IActionResult DeleteRoute(Guid id)
    {
        return Ok(_routeService.DeleteRoute(id, User.FindFirstValue(ClaimTypes.NameIdentifier)!));
    }
}