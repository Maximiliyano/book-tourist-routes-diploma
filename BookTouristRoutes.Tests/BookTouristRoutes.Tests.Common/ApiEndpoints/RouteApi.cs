using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using BookTouristRoutes.Tests.Common.StringFormats;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class RouteApi : BaseApi
{
  public RouteApi() : base("api/route")
  {
  }

  public async Task<RestResponse<RouteEntity>> Create(RouteEntity route)
  {
    var request = CreatePostRequest(RouteApiStringFormat.Create, route);
    return await ExecuteRequest<RouteEntity>(request);
  }

  public async Task<RestResponse<RouteEntity>> Update(RouteEntity route)
  {
    var request = CreatePutRequest(string.Empty, route);
    return await ExecuteRequest<RouteEntity>(request);
  }

  public async Task<RestResponse> Delete(int routeId)
  {
    var request = CreateDeleteRequest(string.Format(RouteApiStringFormat.Delete, routeId));
    return await ExecuteRequest(request);
  }

  public async Task<RestResponse<IEnumerable<RouteEntity>>> Search(string destination, DateTime? startDate, decimal? price)
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.Search, destination));

    if (startDate.HasValue)
    {
      request.AddQueryParameter(nameof(startDate.Value), startDate.Value);
    }
    if (price.HasValue)
    {
      request.AddQueryParameter(nameof(price.Value), price.Value);
    }

    return await ExecuteRequest<IEnumerable<RouteEntity>>(request);
  }

  public async Task<RestResponse<int>> GetAvailableSeats(int routeId)
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.GetAvailableSeats, routeId));
    return await ExecuteRequest<int>(request);
  }

  public async Task<RestResponse<int>> GetBookedSeats(int routeId)
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.GetBookedSeats, routeId));
    return await ExecuteRequest<int>(request);
  }

  public async Task<RestResponse<int>> GetSeatsCapacity(int routeId)
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.GetSeatsCapacity, routeId));
    return await ExecuteRequest<int>(request);
  }

  public async Task<RestResponse<IEnumerable<RouteEntity>>> GetAll()
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.GetAll));
    return await ExecuteRequest<IEnumerable<RouteEntity>>(request);
  }

  public async Task<RestResponse<RouteEntity>> GetById(int routeId)
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.Get, routeId));
    return await ExecuteRequest<RouteEntity>(request);
  }

  public async Task<RestResponse<RouteEntity>> GetByName(string routeName)
  {
    var request = CreateGetRequest(string.Format(RouteApiStringFormat.Get, routeName));
    return await ExecuteRequest<RouteEntity>(request);
  }
}
