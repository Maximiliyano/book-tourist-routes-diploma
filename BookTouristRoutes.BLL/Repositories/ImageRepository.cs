using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;

namespace BookTouristRoutes.BLL.Repositories;

public class ImageRepository : Repository<Image>, IImageRepository
{
  public ImageRepository(BookTouristRoutesContext context) : base(context)
  {
  }
}
