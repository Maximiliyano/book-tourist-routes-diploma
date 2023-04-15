using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Repositories.Base;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.DAL.Context;

namespace BookTouristRoutes.BLL.Repositories;

public class ImageRepository : Repository<Image>, IImageRepository
{
  private readonly BookTouristRoutesContext _context;

  public ImageRepository(BookTouristRoutesContext context) : base(context)
  {
    _context = context;
  }

  public async Task RemoveImageAsync(Image image) =>
    _context.Images.Remove(image);
}
