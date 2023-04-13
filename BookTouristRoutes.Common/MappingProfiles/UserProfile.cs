using AutoMapper;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.Common.MappingProfiles;

public sealed class UserProfile : Profile
{
  public UserProfile()
  {
    CreateMap<User, UserDto>()
      .ForMember(dest => dest.Avatar, src => src
        .MapFrom(s => s.Avatar.URL));

    CreateMap<UserDto, User>()
      .ForMember(dest => dest.Avatar, opt => opt
        .MapFrom(src => new Image
        {
          URL = src.Avatar
        }));


    CreateMap<RegisterUserDto, User>()
      .ForMember(dest => dest.Avatar, src => src
        .MapFrom(s => string.IsNullOrEmpty(s.Avatar)
          ? null
          : new Image
          {
            URL = s.Avatar
          }));
  }
}
