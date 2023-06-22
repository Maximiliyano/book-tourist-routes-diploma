using System.Security.Claims;
using BookTouristRoutes.Common.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace BookTouristRoutes.Api.Extensions;

public static class ControllerBaseExtensions
{
  public static int GetUserIdFromToken(this ControllerBase controller)
  {
    var claimsUserId = controller.User.FindFirstValue("id");

    if (string.IsNullOrEmpty(claimsUserId))
    {
      throw CustomException.InvalidTokenException("access", claimsUserId);
    }

    return int.Parse(claimsUserId);
  }
}
