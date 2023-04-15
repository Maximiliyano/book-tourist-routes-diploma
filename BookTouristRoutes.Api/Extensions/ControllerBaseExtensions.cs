using BookTouristRoutes.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Extensions;

public static class ControllerBaseExtensions
{
  public static int GetUserIdFromToken(this ControllerBase controller)
  {
    var claimsUserId = controller.User.Claims.FirstOrDefault(x => x.Type == "id")?.Value;

    if (string.IsNullOrEmpty(claimsUserId))
    {
      throw CustomException.InvalidTokenException("access", claimsUserId);
    }

    return int.Parse(claimsUserId);
  }
}
