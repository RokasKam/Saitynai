using System.Security.Claims;
using HikingInforamtionSystemCore.Helpers.Auth;
using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Point;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class PointsController : BaseController
{
    private readonly IPointService _pointService;

    public PointsController(IPointService pointService)
    {
        _pointService = pointService;
    }
    
    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet("{id}")]
    public IActionResult GetPointById(Guid id)
    {
        var point = _pointService.GetPointById(id);
        return Ok(point);
    }

    [Authorize(Policy = PolicyNames.HikerRole)]
    [HttpGet]
    public IActionResult GetPoints()
    {
        var points = _pointService.GetPoints();
        return Ok(points);
    }

    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpPost]
    public IActionResult AddPoint([FromBody] PointRequest pointRequest)
    {
        var createdPointId = _pointService.AddPoint(pointRequest);
        return CreatedAtAction(nameof(GetPointById), new { id = createdPointId }, createdPointId);
    }

    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpPut("{id}")]
    public IActionResult UpdatePoint(Guid id, [FromBody] PointRequest pointRequest)
    {
        var result = _pointService.UpdatePoint(id, pointRequest, User.FindFirstValue(ClaimTypes.NameIdentifier)!);
        return Ok(result);
    }
    [Authorize(Policy = PolicyNames.OrganizerRole)]
    [HttpDelete("{id}")]
    public IActionResult DeletePoint(Guid id)
    {
        return Ok(_pointService.DeletePoint(id, User.FindFirstValue(ClaimTypes.NameIdentifier)!));
    }
}