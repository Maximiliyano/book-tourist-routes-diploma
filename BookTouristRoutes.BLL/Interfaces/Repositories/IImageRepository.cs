using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Repositories;

public interface IImageRepository
{
  Task RemoveImage(Image image);
}
