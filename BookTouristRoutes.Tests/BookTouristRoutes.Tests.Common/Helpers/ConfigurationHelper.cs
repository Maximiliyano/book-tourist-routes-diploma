using Microsoft.Extensions.Configuration;

namespace BookTouristRoutes.Tests.Common.Helpers;

public static class ConfigurationHelper
{
  private static IConfiguration _configuration;

  public static IConfiguration Configuration => _configuration ??= new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", false, false)
    .Build();

  public static string AppUrl => GetAppSetting("Url");

  public static string GetAppSetting(string name)
  {
    return Configuration?.GetSection("AppSettings")?[name];
  }
}
