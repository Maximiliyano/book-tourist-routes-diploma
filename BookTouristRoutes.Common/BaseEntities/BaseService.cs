using AutoMapper;
using BookTouristRoutes.Common.Extensions;

namespace BookTouristRoutes.Common.BaseEntities;

public abstract class BaseService
{
  protected readonly IMapper _mapper;

  protected BaseService()
  {
    _mapper = MapperResolver.InitiateMapping();
  }
}
