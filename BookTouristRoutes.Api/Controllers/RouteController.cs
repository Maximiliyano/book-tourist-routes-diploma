using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/route")]
public class RouteController : BaseController
{
  private readonly IRouteService _routeService;
  private readonly IBookingService _bookingService;

  public RouteController(
    IRouteService routeService,
    IBookingService bookingService)
  {
    _routeService = routeService;
    _bookingService = bookingService;
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
  public async Task<IActionResult> Search(
    [FromRoute] string destination,
    [FromQuery] DateTime? startDate,
    [FromQuery] decimal? price,
    [FromQuery] WorldParts? worldParts)
  {
    return Ok(await _routeService.Search(destination, startDate, price, worldParts));
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

  [HttpGet("popular-routes")]
  public async Task<IActionResult> GetPopularRoutes([FromQuery] WorldParts? worldPart) // TODO GetPopularRoutes
  {
    return Ok(await _bookingService.GetPopularBookings(worldPart));
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
