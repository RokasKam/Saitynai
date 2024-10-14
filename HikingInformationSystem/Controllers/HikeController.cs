using HikingInforamtionSystemCore.Interfaces.Service;
using HikingInforamtionSystemCore.Requests.Hike;
using HikingInforamtionSystemCore.Responses.Hike;
using Microsoft.AspNetCore.Mvc;

namespace HikingInformationSystem.Controllers;

public class HikeController : BaseController
{
    private readonly IHikeService _hikeService;

    public HikeController(IHikeService hikeService)
    {
        _hikeService = hikeService;
    }
    
    [HttpGet("{id}")]
    public IActionResult GetHikeById(Guid id)
    {
        var hike = _hikeService.GetHikeById(id);
        return Ok(hike);
    }

    [HttpGet]
    public IActionResult GetHikes()
    {
        var hikes = _hikeService.GetHikes();
        return Ok(hikes);
    }

    [HttpPost]
    public IActionResult AddHike([FromBody] HikeRequest hikeRequest)
    {
        var createdHikeId = _hikeService.AddHike(hikeRequest);
        return CreatedAtAction(nameof(GetHikeById), new { id = createdHikeId }, createdHikeId);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateHike(Guid id, [FromBody] HikeRequest hikeRequest)
    {
        var result = _hikeService.UpdateHike(id, hikeRequest);
        return Ok(result);
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> DeleteHike(Guid id)
    {
        return Ok(_hikeService.DeleteHike(id));
    }
}