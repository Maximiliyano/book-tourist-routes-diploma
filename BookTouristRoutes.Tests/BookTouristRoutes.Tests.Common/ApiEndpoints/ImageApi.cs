using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class ImageApi : AppBaseApi
{
  public ImageApi() : base("api/images")
  {
  }

  public async Task<RestResponse<Image?>> GetImageByUrl(string url)
  {
    var request = CreateGetRequest("details");

    request.AddQueryParameter("imageUrl", url);

    return await ExecuteRequest<Image?>(request);
  }
}
