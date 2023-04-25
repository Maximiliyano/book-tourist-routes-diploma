namespace BookTouristRoutes.Tests.Common.StringFormats;

public static class RouteApiStringFormat
{
  public const string Create = "new";
  public const string Delete = "remove/{0}";
  public const string Search = "search/{0}";
  public const string GetAvailableSeats = "availableSeats/{0}";
  public const string GetBookedSeats = "bookedSeats/{0}";
  public const string GetSeatsCapacity = "totalSeats/{0}";
  public const string GetAll = "all";
  public const string Get = "details/{0}";
}
