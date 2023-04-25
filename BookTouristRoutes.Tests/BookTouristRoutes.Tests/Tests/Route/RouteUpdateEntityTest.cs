using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.Route;

public class RouteUpdateEntityTest
{
  private readonly RouteHelper _routeHelper;

  private RouteDto _route;

  public RouteUpdateEntityTest()
  {
    _routeHelper = new RouteHelper();
  }

  [SetUp]
  public async Task SetUp()
  {
    _route = (RouteDto)await _routeHelper.Create();
  }

  [TearDown]
  public async Task TearDown()
  {
    await _routeHelper.Delete(_route.Id);
  }

  [Test]
  public async Task UpdateRouteWithNewValues_ReturnData()
  {
    // Act
    _route.Name = AppHelper.GenerateRandomName();

    var result = await _routeHelper.Update(_route);

    // Assert
    using (new AssertionScope())
    {
      result.Should().NotBeEquivalentTo(_route);
    }
  }

  [Test]
  public async Task UpdateRouteWithExistingValue_ReturnTheSameObject()
  {
    // Act
    var result = await _routeHelper.Update(_route);

    // Assert
    using (new AssertionScope())
    {
      result.Should().BeEquivalentTo(_route, o =>
        o.Excluding(x => x.UpdatedAt));
    }
  }
}
