using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/booking")]
public class BookingController : BaseController
{
  private readonly IBookingService _bookingService;

  public BookingController(IBookingService bookingService)
  {
    _bookingService = bookingService;
  }

  [HttpPost("new")]
  public async Task<IActionResult> Create([FromBody] Booking bookingEntity)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var result = await _bookingService.CreateBooking(bookingEntity);
    return CreatedAtAction(nameof(Create), result);
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] Booking bookingEntity)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    return Ok(await _bookingService.UpdateBooking(bookingEntity));
  }

  [HttpGet("allByUserId/{userId:int}")]
  public async Task<IActionResult> GetBookingsByUser([FromRoute] int userId)
  {
    return Ok(await _bookingService.GetBookingsByUser(userId));
  }

  [HttpGet("all")]
  public async Task<IActionResult> GetAllBookings()
  {
    return Ok(await _bookingService.GetAllBookings());
  }

  [HttpGet("details/{bookingId:int}")]
  public async Task<IActionResult> GetBooking([FromRoute] int bookingId)
  {
    return Ok(await _bookingService.GetBooking(bookingId));
  }

  [HttpDelete("remove/{bookingId:int}")]
  public async Task<IActionResult> Delete([FromRoute] int bookingId)
  {
    await _bookingService.Delete(bookingId);
    return NoContent();
  }

  [HttpGet]
  public async Task<IActionResult> CalculatePrice(BookingFilterDto bookingFilterDto)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var value = await _bookingService.CalculatePrice(
      bookingFilterDto.StartDate, bookingFilterDto.EndDate,
      bookingFilterDto.Seats, bookingFilterDto.Price);

    return Ok(value);
  }
}
