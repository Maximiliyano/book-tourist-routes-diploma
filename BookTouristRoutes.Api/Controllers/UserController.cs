using System.Net;
using BookTouristRoutes.BLL.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Extensions;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Common.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : BaseController
{
  private readonly UserService _userService;

  public UserController(UserService userService)
  {
    _userService = userService;
  }


  [HttpPost("new")]
  public async Task<IActionResult> Create([FromBody] RegisterUser registerUser)
  {
    try
    {
      if (!ModelState.IsValid)
      {
        return BadRequest();
      }

      var registeredUserIdResponse = await _userService.Create(registerUser);
      return CreatedAtAction(nameof(Create), registeredUserIdResponse);
    }
    catch (CustomException e)
    {
      return BadRequest(e.Message);
    }
  }

  [HttpGet("details/{userId:int}")]
  public async Task<IActionResult> GetById([FromRoute] int userId)
  {
    var response = await _userService.GetById(userId);

    if (response is null)
      return BadRequest();

    return Ok(response);
  }

  [HttpGet("details")]
  public async Task<IActionResult> GetByName([FromQuery] string userName)
  {
    var response = await _userService.GetByName(userName);

    if (response is null)
      return BadRequest();

    return Ok(response);
  }

  [HttpDelete("remove/{userId:int}")]
  public async Task<IActionResult> Delete([FromRoute] int userId)
  {
    try
    {
      await _userService.Delete(userId);
      return NoContent();
    }
    catch (CustomException e)
    {
      return NotFound(e.Message);
    }
  }
}
