using BookTouristRoutes.BLL.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Extensions;
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
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var registeredUserIdResponse = await _userService.Create(registerUser);
    return CreatedAtAction(nameof(Create), registeredUserIdResponse);
  }

  [HttpGet("all")]
  public async Task<IActionResult> GetAll()
  {
    return Ok(await _userService.GetAll());
  }

  [HttpGet("details/{userId:int}")]
  public async Task<IActionResult> GetById([FromRoute] int userId)
  {
    var response = await _userService.Get(userId);

    if (response is null)
      return BadRequest();

    return Ok(response);
  }

  [HttpGet("details")]
  public async Task<IActionResult> GetByName([FromQuery] string userName)
  {
    var response = await _userService.Get(userName);

    if (response is null)
      return BadRequest();

    return Ok(response);
  }

  [HttpPut]
  public async Task<IActionResult> Update([FromBody] User user)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var response = await _userService.Update(user);
    return Ok(response);
  }

  [HttpDelete("remove/{userId:int}")]
  public async Task<IActionResult> Delete([FromRoute] int userId)
  {
    await _userService.Delete(userId);
    return NoContent();
  }
}
