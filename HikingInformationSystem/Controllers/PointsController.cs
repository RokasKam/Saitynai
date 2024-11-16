using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Point;
using HikingInforamtionSystemCore.Responses.Point;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class PointsController : BaseController
{
    private readonly IPointService _pointService;

    public PointsController(IPointService pointService)
    {
        _pointService = pointService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetPointById(Guid id)
    {
        var point = _pointService.GetPointById(id);
        return Ok(point);
    }

    [HttpGet]
    public IActionResult GetPoints()
    {
        var points = _pointService.GetPoints();
        return Ok(points);
    }

    [HttpPost]
    public IActionResult AddPoint([FromBody] PointRequest pointRequest)
    {
        var createdPointId = _pointService.AddPoint(pointRequest);
        return CreatedAtAction(nameof(GetPointById), new { id = createdPointId }, createdPointId);
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePoint(Guid id, [FromBody] PointRequest pointRequest)
    {
        var result = _pointService.UpdatePoint(id, pointRequest);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeletePoint(Guid id)
    {
        return Ok(_pointService.DeletePoint(id));
    }
}