using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Tests.Common.Extensions;
using BookTouristRoutes.Tests.Helpers;
using FluentAssertions;
using FluentAssertions.Execution;

namespace BookTouristRoutes.Tests.Tests.Booking;

[TestFixture]
public class BookingApiTests
{
  private readonly BookingHelper _bookingHelper;
  private readonly RouteHelper _routeHelper;
  private readonly UserHelper _userHelper;

  private BookTouristRoutes.Common.Models.Booking _booking;

  private int _userId;
  private int _routeId;

  public BookingApiTests()
  {
    _bookingHelper = new BookingHelper();
    _routeHelper = new RouteHelper();
    _userHelper = new UserHelper();
  }

  [SetUp]
  public async Task SetUp()
  {
    _routeId = (await _routeHelper.Create()).Id;
    _userId = (await _userHelper.Create()).Id;

    var bookingEntityId = await _bookingHelper.Create(_routeId, _userId);
    _booking = await _bookingHelper.Get(bookingEntityId);
  }

  [TearDown]
  public async Task CleanUp()
  {
    await _bookingHelper.Delete(_booking.Id);
    await _userHelper.Delete(_userId);
    await _routeHelper.Delete(_routeId);
  }

  [Test]
  public async Task Create_WhenValidBookingEntity_ReturnId()
  {
    // Act
    var bookingEntityId = await _bookingHelper.Create(_routeId, _userId);

    await _bookingHelper.Delete(bookingEntityId);

    // Assert
    using (new AssertionScope())
    {
      bookingEntityId.Should().BePositive();
    }
  }

  [Test]
  public async Task Create_WhenInvalidBookingEntity_ReturnBadRequest()
  {
    // Arrange
    var routeId = AppHelper.GenerateRandomNumber(-10, 0);
    var userId = AppHelper.GenerateRandomNumber(-10, 0);

    // Act
    var bookingEntityId = await _bookingHelper.Create(routeId, userId);

    // Assert
    using (new AssertionScope())
    {
      bookingEntityId.Should().Be(0);
    }
  }

  [Test]
  public async Task Update_WhenValidBookingEntity_ReturnsRestResponseWithBooking()
  {
    // Act
    _booking.Price = 10;
    var result = await _bookingHelper.Update(_booking);

    // Assert
    using (new AssertionScope())
    {
      result.Should().NotBeNull();
      result.Should().BeEquivalentTo(_booking, o => o
        .Excluding(
          x => x.Price,
          x => x.UpdatedAt));
    }
  }

  [Test]
  public async Task GetByUser_WhenValidUserId_ReturnsRestResponseWithIEnumerableOfBooking()
  {
    // Act
    var result = await _bookingHelper.GetByUser(_userId);

    // Assert
    using (new AssertionScope())
    {
      result.Should().OnlyContain(x => x.Id == _booking.Id);
    }
  }

  [Test]
  public async Task GetAll_ReturnsRestResponseWithIEnumerableOfBooking()
  {
    // Act
    var result = await _bookingHelper.GetAll();

    // Assert
    using (new AssertionScope())
    {
      result.Should().Contain(x => x.Id == _booking.Id);
    }
  }

  [Test]
  public async Task Get_WhenValidBookingId_ReturnsRestResponseWithBooking()
  {
    // Act
    var result = await _bookingHelper.Get(_booking.Id);

    // Assert
    using (new AssertionScope())
    {
      result.Should().NotBeNull();
    }
  }

  [Test]
  public async Task Delete_WhenValidBookingId_ReturnsRestResponse()
  {
    // Act
    await _bookingHelper.Delete(_booking.Id);
    var result = await _bookingHelper.Get(_booking.Id);

    // Assert
    using (new AssertionScope())
    {
      result.Should().BeNull();
    }
  }

  [TestCase(2, 100)]
  [TestCase(1, 500)]
  [TestCase(7, 1000)]
  [Test]
  public async Task CalculatePrice_WhenValidBookingFilterDto_ReturnsRestResponseWithDecimal(int seats, int price)
  {
    // Arrange
    var bookingFilterDto = BuildBookingFilterDto(DateTime.Now, DateTime.Now.AddDays(5), price, seats);
    var days = (bookingFilterDto.EndDate - bookingFilterDto.StartDate).Days;
    var value = bookingFilterDto.Seats * bookingFilterDto.Price * days;

    // Act
    var result = await _bookingHelper.CalculatePrice(bookingFilterDto);

    // Assert
    using (new AssertionScope())
    {
      result.Should().Be(value);
    }
  }

  private static BookingFilterDto BuildBookingFilterDto(
    DateTime startDate, DateTime endDate,
    decimal price, int seats) =>
      new()
      {
        StartDate = startDate,
        EndDate = endDate,
        Price = price,
        Seats = seats
      };
}
