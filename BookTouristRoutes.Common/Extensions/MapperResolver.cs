using AutoMapper;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Common.Models.User;

namespace BookTouristRoutes.Common.Extensions;

public static class MapperResolver
{
  public static Mapper InitiateMapping()
  {
    var config = new MapperConfiguration(cfg =>
    {
      cfg.CreateMap<User, UserDto>();
      cfg.CreateMap<UserDto, User>();
      cfg.CreateMap<RegisterUser, UserDto>();
    });

    var mapper = new Mapper(config);
    return mapper;
  }
}
