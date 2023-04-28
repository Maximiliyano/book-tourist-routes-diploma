namespace BookTouristRoutes.Tests.Common.StringFormats;

public static class BookingApiStringFormat
{
  public const string Create = "new";
  public const string Delete = "remove/{0}";
  public const string GetByUser = "allByUserId/{0}";
  public const string GetAll = "all";
  public const string Get = "details/{0}";
  public const string CalculatePrice = "calculatePrice";
}
