using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Interfaces.Services;

public interface IImageService
{
  Task CreateImage(Image image);
  Task UpdateImage(Image image);
  Task Remove(Image image);
  Task<Image?> GetByUrl(string imageUrl);
  Task<Image?> GetById(int imageId);
  Task<Image> GetEntityByUrl(string url);
}
