using Bogus;
using BookTouristRoutes.Common.Builders;
using BookTouristRoutes.Common.Enums;
using BookTouristRoutes.Common.Helpers;
using BookTouristRoutes.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.Common.Extensions;

public static class ModelBuilderExtensions
{
  private const int EntityCount = 20;

  public static void Configure(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<RefreshToken>().Ignore(t => t.IsActive);

    modelBuilder.Entity<RouteEntity>()
      .Property(b => b.Price)
      .HasPrecision(10, 2);

    modelBuilder.Entity<Booking>()
      .Property(b => b.Price)
      .HasPrecision(10, 2);
  }

  public static void Seed(this ModelBuilder modelBuilder)
  {
    var avatars = GenerateRandomAvatars(out var lastImageId);
    var previewImages = GenerateRandomPreviewImages(lastImageId);

    var users = GenerateRandomUsers(avatars);
    var routes = GenerateRandomRoutes(previewImages);
    var bookings = GenerateRandomBookings(routes, users);

    modelBuilder.Entity<Image>().HasData(avatars.Concat(previewImages));
    modelBuilder.Entity<User>().HasData(users);
    modelBuilder.Entity<RouteEntity>().HasData(routes);
    modelBuilder.Entity<Booking>().HasData(bookings);
  }

  private static IEnumerable<Booking> GenerateRandomBookings(IEnumerable<RouteEntity> routeEntities, IEnumerable<User> users)
  {
    var bookingId = 1;

    var bookingFake = new Faker<Booking>()
      .RuleFor(bo => bo.Id, () => bookingId++)
      .RuleFor(bo => bo.Price, f => f.Random.Decimal(1, 10000))
      .RuleFor(bo => bo.CreatedAt, DateTime.Now)
      .RuleFor(bo => bo.UpdatedAt, DateTime.Now)
      .RuleFor(bo => bo.StartDate, DateTime.Now.AddDays(3))
      .RuleFor(bo => bo.EndDate, DateTime.Now.AddDays(6))
      .RuleFor(bo => bo.Status, f => f.PickRandom<BookingStatus>())
      .RuleFor(bo => bo.Uid, Guid.NewGuid)
      .RuleFor(bo => bo.RouteId, f => f.PickRandom(routeEntities).Id)
      .RuleFor(bo => bo.UserId, f => f.PickRandom(users).Id);

    var bookings = bookingFake.Generate(EntityCount * 2);
    return bookings;
  }

  private static ICollection<Image> GenerateRandomAvatars(out int lastImageId)
  {
      var avatarImageId = 1;

      var avatarImagesFake = new Faker<Image>()
         .RuleFor(pi => pi.Id, () => avatarImageId++)
         .RuleFor(pi => pi.URL, f => f.Internet.Avatar())
         .RuleFor(pi => pi.CreatedAt, DateTime.Now)
         .RuleFor(pi => pi.UpdatedAt, DateTime.Now);

      var avatarImages = avatarImagesFake.Generate(EntityCount);
      lastImageId = avatarImageId;

      return avatarImages;
  }

  private static IEnumerable<Image> GenerateRandomPreviewImages(int lastImageId)
  {
      var previewImagesFake = new Faker<Image>()
          .RuleFor(pi => pi.Id, f => lastImageId++)
          .RuleFor(pi => pi.URL, f => f.Image.PicsumUrl())
          .RuleFor(pi => pi.CreatedAt, f => DateTime.Now)
          .RuleFor(pi => pi.UpdatedAt, f => DateTime.Now);

      return previewImagesFake.Generate(EntityCount);
  }

  private static IEnumerable<RouteEntity> GenerateRandomRoutes(IEnumerable<Image> images)
  {
    var routeId = 1;
    var seats = AppHelper.GenerateRandomNumber(1, 10);
    var imageList = new List<int>();

    var testRouteFake = new Faker<RouteEntity>()
      .RuleFor(r => r.Id, () => routeId++)
      .RuleFor(r => r.Name, f => f.Address.City())
      .RuleFor(r => r.Description, f => f.Commerce.ProductDescription())
      .RuleFor(r => r.StartDate, DateTime.Now)
      .RuleFor(r => r.EndDate, DateTime.Now.AddDays(5))
      .RuleFor(r => r.Seats, seats)
      .RuleFor(r => r.BookedSeats, f => f.Random.Int(0, seats))
      .RuleFor(r => r.Price, f => f.Random.Decimal(1, 10000))
      .RuleFor(r => r.Destination, f => f.Address.City())
      .RuleFor(r => r.WorldPart, f => f.PickRandom<WorldParts>());

    var generatedRoutes = testRouteFake.Generate(EntityCount);
    return generatedRoutes;
  }

  private static IEnumerable<User> GenerateRandomUsers(ICollection<Image> avatars)
  {
      var userId = 1;

      var testUsersFake = new Faker<User>()
          .RuleFor(u => u.Id, () => userId++)
          .RuleFor(u => u.Name, f => f.Internet.UserName())
          .RuleFor(u => u.Email, f => f.Internet.Email())
          .RuleFor(u => u.Salt, f => Convert.ToBase64String(SecurityHelper.GetRandomBytes()))
          .RuleFor(u => u.Password, (f, u) => SecurityHelper.HashPassword(f.Internet.Password(12), Convert.FromBase64String(u.Salt)))
          .RuleFor(u => u.AvatarId, f => f.PickRandom(avatars).Id)
          .RuleFor(u => u.Role, f => f.PickRandom<UserRoles>())
          .RuleFor(pi => pi.CreatedAt, DateTime.Now)
          .RuleFor(pi => pi.UpdatedAt, DateTime.Now);

      var generatedUsers = testUsersFake.Generate(EntityCount);

      var salt = Convert.ToBase64String(SecurityHelper.GetRandomBytes());
      var hashedPassword = SecurityHelper.HashPassword("passw0rd", Convert.FromBase64String(salt));

      var myUser = GlobalBuilder.BuildUser(userId, "test@gmail.com", hashedPassword, salt, "testUser");

      generatedUsers.Add(myUser);

      return generatedUsers;
  }
}
