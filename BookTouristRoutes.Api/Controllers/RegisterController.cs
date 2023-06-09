using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Route("api/register")]
[AllowAnonymous]
public class RegisterController : BaseController
{
  private readonly IUserService _userService;
  private readonly IAuthService _authService;

  public RegisterController(
    IUserService userService,
    IAuthService authService)
  {
    _userService = userService;
    _authService = authService;
  }

  [HttpPost("new")]
  public async Task<IActionResult> Create([FromBody] RegisterUserDto registerUser)
  {
    if (!ModelState.IsValid)
    {
      return BadRequest();
    }

    var createdUserDto = await _userService.CreateUser(registerUser);
    var token = await _authService.GenerateAccessToken(createdUserDto.Id, createdUserDto.Name, createdUserDto.Email);

    var result = GlobalBuilder.BuildAuthUserDto(createdUserDto, token);
    return CreatedAtAction(nameof(Create), result);
  }
}
