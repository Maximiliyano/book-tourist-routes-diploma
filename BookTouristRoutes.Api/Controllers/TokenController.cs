using BookTouristRoutes.Api.Extensions;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.Common.Auth;
using BookTouristRoutes.Common.BaseEntities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/token")]
public class TokenController : BaseController
{
  private readonly IAuthService _authService;

  public TokenController(IAuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("refresh")]
  [AllowAnonymous]
  public async Task<IActionResult> Refresh([FromBody] RefreshTokenDto refreshTokenDto)
  {
    return Ok(await _authService.RefreshToken(refreshTokenDto));
  }

  [HttpPost("revoke")]
  public async Task<IActionResult> RevokeRefreshToken([FromBody] RevokeRefreshTokenDto revokeRefreshTokenDto)
  {
    var userId = this.GetUserIdFromToken();
    await _authService.RevokeRefreshToken(revokeRefreshTokenDto.RefreshToken, userId);

    return Ok();
  }
}
