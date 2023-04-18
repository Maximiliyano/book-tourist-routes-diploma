using BookTouristRoutes.Tests.Common.Helpers;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints.Base;

public class AppBaseApi : BaseApi
{
  public AppBaseApi(string serviceUrl)
    : base(ConfigurationHelper.AppUrl, serviceUrl)
  {
  }
}
