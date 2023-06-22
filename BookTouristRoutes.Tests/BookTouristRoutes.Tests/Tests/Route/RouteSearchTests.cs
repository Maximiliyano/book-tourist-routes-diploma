using BookTouristRoutes.Common.Models;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.Route;

public class RouteSearchTests
{
  private readonly RouteHelper _routeHelper;

  private IEnumerable<RouteEntity> _routeEntities;

  private RouteEntity _route;

  public RouteSearchTests()
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
  public async Task AddNewRoute_GetAllRoutes_ReturnListWithNewOne()
  {
    // Act
    var routes = await _routeHelper.GetAll();

    // Assert
    using (new AssertionScope())
    {
      _route.Should().NotBeNull();

      routes.Should().NotBeEmpty();
    }
  }

  [Test]
  public async Task GetAllRoutes_ReturnEmptyList()
  {
    // Arrange
    await _routeHelper.Delete(_route.Id);

    // Act
    var routes = await _routeHelper.GetAll();

    // Assert
    using (new AssertionScope())
    {
      routes.Should().NotContain(x => x.Id == _route.Id);
    }
  }

  [TestCase(true, true)]
  [TestCase(true, false)]
  [TestCase(false, true)]
  [TestCase(false, false)]
  [Test]
  public async Task SearchRoutes_ReturnList(bool useStartDate, bool usePrice)
  {
    // Act
    if (useStartDate)
    {
      _routeEntities = await _routeHelper.Search(_route.Destination, startDate: _route.StartDate);
    }

    if (usePrice)
    {
      _routeEntities = await _routeHelper.Search(_route.Destination, price: _route.Price);
    }

    _routeEntities = useStartDate switch
    {
      true when usePrice => await _routeHelper.Search(_route.Destination, _route.StartDate, _route.Price),
      false when !usePrice => await _routeHelper.Search(_route.Destination),
      _ => _routeEntities
    };

    await _routeHelper.Delete(_route.Id);

    // Assert
    using (new AssertionScope())
    {
      _routeEntities.Should().Contain(x => x.Destination == _route.Destination)
        .And
        .Contain(x => x.StartDate == _route.StartDate)
        .And
        .Contain(x => x.Price == _route.Price);
    }
  }

  [Test]
  public async Task GetAvailableSeatsRoute_ReturnValue()
  {
    // Act
    var value = await _routeHelper.GetAvailableSeats(_route.Id);

    // Assert
    using (new AssertionScope())
    {
      value.Should().Be(_route.Seats - _route.BookedSeats);
    }
  }

  [Test]
  public async Task GetBookedSeatsRoute_ReturnValue()
  {
    // Act
    var value = await _routeHelper.GetBookedSeats(_route.Id);

    // Assert
    using (new AssertionScope())
    {
      value.Should().Be(_route.BookedSeats);
    }
  }

  [Test]
  public async Task GetSeatsCapacityRoute_ReturnValue()
  {
    // Act
    var value = await _routeHelper.GetSeatsCapacity(_route.Id);

    // Assert
    using (new AssertionScope())
    {
      value.Should().Be(_route.Seats);
    }
  }

  [Test]
  public async Task GetByIdRoute_ReturnInstance()
  {
    // Act
    var route = await _routeHelper.GetById(_route.Id);

    // Assert
    using (new AssertionScope())
    {
      route.Should().BeEquivalentTo(_route);
    }
  }

  [Test]
  public async Task GetByNameRoute_ReturnInstance()
  {
    // Act
    var route = await _routeHelper.GetByName(_route.Name);

    // Assert
    using (new AssertionScope())
    {
      route.Should().BeEquivalentTo(_route);
    }
  }
}
