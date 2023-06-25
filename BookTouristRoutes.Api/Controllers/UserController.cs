using BookTouristRoutes.Api.Extensions;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : BaseController
{
  private readonly IUserService _userService;
  private readonly IAuthService _authService;

  public UserController(IUserService userService, IAuthService authService)
  {
    _userService = userService;
    _authService = authService;
  }

  [HttpGet("all")]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _userService.GetAll());
  }

  [HttpGet("details/{userId:int}")]
  public async Task<IActionResult> GetById([FromRoute] int userId)
  {
    return Ok(await _userService.Get(userId));
  }

  [HttpGet("details")]
  public async Task<IActionResult> GetByEmail([FromQuery] string userEmail)
  {
    return Ok(await _userService.Get(userEmail));
  }

  [HttpGet("fromToken")]
  public async Task<IActionResult> GetUserFromToken() // TODO rework GetUserIdFromToken
  {
    return Ok(await _userService.Get(await _authService.GetUserIdFromToken()));
  }

  [HttpPut("{userId:int}/change-pass")]
  public async Task<IActionResult> ChangePassword([FromRoute] int userId, [FromQuery] string newPassword)
  {
    return Ok(await _userService.ChangePassword(userId, newPassword));
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] UserDto user)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var response = await _userService.UpdateUser(user);
    return Ok(response);
  }

  [HttpDelete("remove/{userId:int}")]
  public async Task<IActionResult> Delete([FromRoute] int userId)
  {
    await _userService.Delete(userId);
    return NoContent();
  }
}
