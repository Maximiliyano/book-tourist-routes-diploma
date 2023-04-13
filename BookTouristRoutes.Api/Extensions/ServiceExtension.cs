using System.Reflection;
using BookTouristRoutes.BLL.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.BLL.Services;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.MappingProfiles;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.Api.Extensions;

public static class ServiceExtension
{
  public static void RegisterCustomServices(this IServiceCollection service)
  {
    service.AddScoped<UserService>();
    service.AddScoped<ImageService>();
  }

  public static void RegisterRepositories(this IServiceCollection service)
  {
    service.AddScoped<UserRepository>();
    service.AddScoped<ImageRepository>();

    service.AddScoped<Repository<UserDto>>();
    service.AddScoped<Repository<Image>>();
  }

  public static void RegisterAutoMapper(this IServiceCollection services)
  {
    services.AddAutoMapper(cfg =>
    {
      cfg.AddProfile<UserProfile>();
    },
    Assembly.GetExecutingAssembly());
  }
}
