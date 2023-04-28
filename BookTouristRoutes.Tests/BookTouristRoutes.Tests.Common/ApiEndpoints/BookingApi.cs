using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints.Base;
using BookTouristRoutes.Tests.Common.StringFormats;
using RestSharp;

namespace BookTouristRoutes.Tests.Common.ApiEndpoints;

public class BookingApi : BaseApi
{
  public BookingApi() : base("api/booking")
  {
  }

  public async Task<RestResponse<int>> Create(Booking bookingEntity)
  {
    var request = CreatePostRequest(BookingApiStringFormat.Create, bookingEntity);
    return await ExecuteRequest<int>(request);
  }

  public async Task<RestResponse<Booking>> Update(Booking bookingEntity)
  {
    var request = CreatePutRequest(string.Empty, bookingEntity);
    return await ExecuteRequest<Booking>(request);
  }

  public async Task<RestResponse<IEnumerable<Booking>>> GetByUser(int userId)
  {
    var request = CreateGetRequest(string.Format(BookingApiStringFormat.GetByUser, userId));
    return await ExecuteRequest<IEnumerable<Booking>>(request);
  }

  public async Task<RestResponse<IEnumerable<Booking>>> GetAll()
  {
    var request = CreateGetRequest(BookingApiStringFormat.GetAll);
    return await ExecuteRequest<IEnumerable<Booking>>(request);
  }

  public async Task<RestResponse<Booking>> Get(int bookingId)
  {
    var request = CreateGetRequest(string.Format(BookingApiStringFormat.Get, bookingId));
    return await ExecuteRequest<Booking>(request);
  }

  public async Task<RestResponse> Delete(int bookingId)
  {
    var request = CreateDeleteRequest(string.Format(BookingApiStringFormat.Delete, bookingId));
    return await ExecuteRequest(request);
  }

  public async Task<RestResponse<decimal>> CalculatePrice(BookingFilterDto bookingFilterDto)
  {
    var request = CreatePostRequest(BookingApiStringFormat.CalculatePrice, bookingFilterDto);
    return await ExecuteRequest<decimal>(request);
  }
}
