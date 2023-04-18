using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints;

namespace BookTouristRoutes.Tests.Helpers;

public class ImageHelper
{
  private readonly ImageApi _imageApi;

  public ImageHelper()
  {
    _imageApi = new ImageApi();
  }

  public async Task<Image?> Get(string url) =>
    (await _imageApi.GetImageByUrl(url)).Data;
}
