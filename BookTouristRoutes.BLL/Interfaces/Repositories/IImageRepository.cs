using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IImageRepository : IRepository<Image>
{
  Task RemoveImageAsync(Image image);
}
