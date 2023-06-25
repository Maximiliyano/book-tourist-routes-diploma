using System.Net;
using BookTouristRoutes.Common.Exceptions;

namespace BookTouristRoutes.Api.Filters;

public static class ExceptionFilterExtensions
{
  public static HttpStatusCode ParseException(this Exception exception)
  {
    return exception switch
    {
      NotFoundException _ => HttpStatusCode.NotFound,
      RepeatException _ => HttpStatusCode.Conflict,
      InvalidUserCredentialsException _ => HttpStatusCode.Unauthorized,
      InvalidTokenException _ => HttpStatusCode.Unauthorized,
      ExpiredRefreshTokenException _ => HttpStatusCode.Unauthorized,
      _ => HttpStatusCode.InternalServerError,
    };
  }
}
