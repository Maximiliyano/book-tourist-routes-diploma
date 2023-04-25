﻿using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Common.ApiEndpoints;

namespace BookTouristRoutes.Tests.Helpers;

public class RouteHelper
{
  private readonly RouteApi _routeApi;

  public RouteHelper()
  {
    _routeApi = new RouteApi();
  }

  public async Task<Route?> Create(
    string? name = null, string? description = null,
    DateTime? startDate = null, DateTime? endDate = null,
    int? seats = null, int? bookedSeats = null,
    decimal? price = null, string? destination = null)
  {
    var buildRouteModel = GlobalBuilder.BuildRouteDto(name, description, startDate, endDate, seats, bookedSeats, price, destination);
    return (await _routeApi.Create(buildRouteModel)).Data;
  }

  public async Task<Route> Update(RouteDto route)
  {
    return (await _routeApi.Update(route)).Data;
  }

  public async Task<IEnumerable<Route>> Search(string destination, DateTime? startDate = null, decimal? price = null)
  {
    return (await _routeApi.Search(destination, startDate, price)).Data;
  }

  public async Task<int> GetAvailableSeats(int routeId)
  {
    return (await _routeApi.GetAvailableSeats(routeId)).Data;
  }

  public async Task<int> GetBookedSeats(int routeId)
  {
    return (await _routeApi.GetBookedSeats(routeId)).Data;
  }

  public async Task<int> GetSeatsCapacity(int routeId)
  {
    return (await _routeApi.GetSeatsCapacity(routeId)).Data;
  }

  public async Task<IEnumerable<Route>> GetAll()
  {
    return (await _routeApi.GetAll()).Data;
  }

  public async Task<Route> GetById(int routeId)
  {
    return (await _routeApi.GetById(routeId)).Data;
  }

  public async Task<Route> GetByName(string routeName)
  {
    return (await _routeApi.GetByName(routeName)).Data;
  }

  public async Task Delete(int routeId) =>
    await _routeApi.Delete(routeId);
}
