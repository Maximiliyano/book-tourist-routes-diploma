

using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/route")]
public class RouteController : BaseController
{
  private readonly IRouteService _routeService;

  public RouteController(IRouteService routeService)
  {
    _routeService = routeService;
  }

  [HttpPost("new")]
  public async Task<IActionResult> Create([FromBody] RouteEntity routeEntity)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var result = await _routeService.CreateRoute(routeEntity);
    return CreatedAtAction(nameof(Create), result);
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] RouteEntity routeEntity)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    return Ok(await _routeService.UpdateRoute(routeEntity));
  }

  [HttpGet("search/{destination}")]
  public async Task<IActionResult> Search([FromRoute] string destination, [FromQuery] DateTime? startDate, [FromQuery] decimal? price)
  {
    return Ok(await _routeService.Search(destination, startDate, price));
  }

  [HttpGet("availableSeats/{routeId:int}")]
  public async Task<IActionResult> GetAvailableSeats([FromRoute] int routeId)
  {
    return Ok(await _routeService.GetAvailableSeats(routeId));
  }

  [HttpGet("bookedSeats/{routeId:int}")]
  public async Task<IActionResult> GetBookedSeats([FromRoute] int routeId)
  {
    return Ok(await _routeService.GetBookedSeats(routeId));
  }

  [HttpGet("totalSeats/{routeId:int}")]
  public async Task<IActionResult> GetSeatsCapacity([FromRoute] int routeId)
  {
    return Ok(await _routeService.GetSeatsCapacity(routeId));
  }

  [HttpGet("all")]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _routeService.GetAll());
  }

  [HttpGet("details/{routeId:int}")]
  public async Task<IActionResult> GetById([FromRoute] int routeId)
  {
    return Ok(await _routeService.Get(routeId));
  }

  [HttpGet("details/{routeName}")]
  public async Task<IActionResult> GetByName([FromRoute] string routeName)
  {
    return Ok(await _routeService.Get(routeName));
  }

  [HttpDelete("remove/{routeId:int}")]
  public async Task<IActionResult> Delete([FromRoute] int routeId)
  {
    await _routeService.DeleteRoute(routeId);
    return NoContent();
  }
}
