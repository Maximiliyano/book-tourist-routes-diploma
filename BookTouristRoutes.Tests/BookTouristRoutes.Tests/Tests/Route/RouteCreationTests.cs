using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.Route;

public class RouteCreationTests
{
  private readonly RouteHelper _routeHelper;

  private RouteEntity _route;

  public RouteCreationTests()
  {
    _routeHelper = new RouteHelper();
  }

  [SetUp]
  public async Task SetUp()
  {
    _route = await _routeHelper.Create();
  }

  [TearDown]
  public async Task CleanUp()
  {
    await _routeHelper.Delete(_route.Id);
  }

  [Test]
  public async Task Create_WithValidInput_ReturnsCreatedRoute()
  {
    // Assert
    using (new AssertionScope())
    {
      _route.Id.Should().NotBe(0);
    }
  }

  [Test]
  public async Task Create_WithInvalidInput_ReturnsBadRequest()
  {
    // Act
    var route = await _routeHelper.Create(name: _route.Name);

    // Assert
    using (new AssertionScope())
    {
      route.Should().BeNull();

      _route.Should().NotBeNull();
    }
  }
}
