using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.BLL.Services;
using BookTouristRoutes.Common.Dtos;

namespace BookTouristRoutes.Api.Extensions;

public static class ServiceExtension
{
  public static void RegisterCustomServices(this IServiceCollection service)
  {
    service.AddScoped<UserService>();
  }

  public static void RegisterRepositories(this IServiceCollection service)
  {
    service.AddScoped<UserRepository>();

    service.AddScoped<Repository<UserDto>>();
  }
}
