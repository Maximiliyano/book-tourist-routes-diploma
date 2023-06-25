namespace BookTouristRoutes.Common.Exceptions;

public sealed class ExpiredRefreshTokenException : Exception
{
  public ExpiredRefreshTokenException()
    : base("Refresh token expired.")
  {
  }
}
