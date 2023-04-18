using System.Net;
using AutoMapper;
using BookTouristRoutes.BLL.Interfaces.Repositories;
using BookTouristRoutes.BLL.Interfaces.Services;
using BookTouristRoutes.BLL.Services.Base;
using BookTouristRoutes.Common.Exceptions;
using BookTouristRoutes.Common.Models;

namespace BookTouristRoutes.BLL.Services;

public class ImageService : BaseService<IImageRepository, Image>, IImageService
{
  public ImageService(IImageRepository imageRepository, IMapper mapper) : base(imageRepository, mapper)
  {
  }

  public async Task CreateImage(Image image)
  {
    await ValidateImageIsExistByUrl(image.URL);

    await _repository.CreateAsync(image);
  }

  public async Task UpdateImage(Image image)
  {
    await ValidateImageIsNotExistById(image.Id);

    await _repository.UpdateAsync(image);
  }

  public async Task Remove(Image image)
  {
    await _repository.RemoveImageAsync(image);
  }

  public async Task<Image> GetEntityByUrl(string url) =>
    await _repository.FirstAsync(x => x.URL == url);

  public async Task<Image?> GetByUrl(string url) =>
    await _repository.FirstOrDefaultAsync(x => x.URL == url);

  public async Task<Image?> GetById(int imageId) =>
    await _repository.FirstOrDefaultAsync(x => x.Id == imageId);

  private async Task ValidateImageIsExistByUrl(string url)
  {
    var user = await GetByUrl(url);

    if (user is not null)
      throw new CustomException("Image with the same email is exist in system!", HttpStatusCode.BadRequest);
  }

  public async Task ValidateImageIsNotExistById(int userId)
  {
    var image = await GetById(userId);

    if (image is null)
      throw CustomException.EntityNotFound(nameof(image), userId);
  }
}
