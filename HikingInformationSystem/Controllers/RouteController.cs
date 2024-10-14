using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Route;
using HikingInforamtionSystemCore.Responses.Route;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class RouteController : BaseController
{
    private readonly IRouteService _routeService;

    public RouteController(IRouteService routeService)
    {
        _routeService = routeService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetRouteById(Guid id)
    {
        var route = _routeService.GetRouteById(id);
        return Ok(route);
    }
    
    [HttpGet("{id}")]
    public IActionResult GetRouteWithPointsById(Guid id)
    {
        var route = _routeService.GetRouteWithPointsById(id);
        return Ok(route);
    }

    [HttpGet]
    public IActionResult GetRoutes()
    {
        var routes = _routeService.GetRoutes();
        return Ok(routes);
    }

    [HttpPost]
    public IActionResult AddRoute([FromBody] RouteRequest routeRequest)
    {
        var createdRouteId = _routeService.AddRoute(routeRequest);
        return CreatedAtAction(nameof(GetRouteById), new { id = createdRouteId }, createdRouteId);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateRoute(Guid id, [FromBody] RouteRequest routeRequest)
    {
        var result = _routeService.UpdateRoute(id, routeRequest);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteRoute(Guid id)
    {
        return Ok(_routeService.DeleteRoute(id));
    }
}