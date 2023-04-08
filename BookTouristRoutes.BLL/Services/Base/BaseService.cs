using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Extensions;

namespace BookTouristRoutes.BLL.Services.Base;

public abstract class BaseService<TRepository, TEntity>
  where TEntity : BaseModel
  where TRepository : IRepository<TEntity>
{
  protected readonly IMapper _mapper;

  protected readonly TRepository _repository;

  protected BaseService(TRepository repository)
  {
    _repository = repository;
    _mapper = MapperResolver.InitiateMapping();
  }

  protected Task Create(TEntity model)
  {
    return _repository.CreateAsync(model);
  }

  protected Task Update(TEntity model)
  {
    model.UpdatedAt = DateTime.Now;

    return _repository.UpdateAsync(model);
  }

  protected Task Delete(TEntity model)
  {
    return _repository.DeleteAsync(model);
  }
}
