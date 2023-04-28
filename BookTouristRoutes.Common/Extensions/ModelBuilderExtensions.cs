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
    var avatars = GenerateRandomAvatars(out int lastImageId);
    var previewImages = GenerateRandomPreviewImages(lastImageId);

    var users = GenerateRandomUsers(avatars);

    modelBuilder.Entity<Image>().HasData(avatars.Concat(previewImages));
    modelBuilder.Entity<User>().HasData(users);
  }

  private static ICollection<Image> GenerateRandomAvatars(out int lastImageId)
  {
      var avatarImageId = 1;

      var avatarImagesFake = new Faker<Image>()
         .RuleFor(pi => pi.Id, f => avatarImageId++)
         .RuleFor(pi => pi.URL, f => f.Internet.Avatar())
         .RuleFor(pi => pi.CreatedAt, f => DateTime.Now)
         .RuleFor(pi => pi.UpdatedAt, f => DateTime.Now);

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

  private static IEnumerable<User> GenerateRandomUsers(ICollection<Image> avatars)
  {
      var userId = 1;

      var testUsersFake = new Faker<User>()
          .RuleFor(u => u.Id, f => userId++)
          .RuleFor(u => u.Name, f => f.Internet.UserName())
          .RuleFor(u => u.Email, f => f.Internet.Email())
          .RuleFor(u => u.Salt, f => Convert.ToBase64String(SecurityHelper.GetRandomBytes()))
          .RuleFor(u => u.Password, (f, u) => SecurityHelper.HashPassword(f.Internet.Password(12), Convert.FromBase64String(u.Salt)))
          .RuleFor(u => u.AvatarId, f => f.PickRandom(avatars).Id)
          .RuleFor(u => u.Role, f => f.PickRandom<UserRoles>())
          .RuleFor(pi => pi.CreatedAt, f => DateTime.Now)
          .RuleFor(pi => pi.UpdatedAt, f => DateTime.Now);

      var generatedUsers = testUsersFake.Generate(EntityCount);

      var salt = Convert.ToBase64String(SecurityHelper.GetRandomBytes());
      var hashedPassword = SecurityHelper.HashPassword("passw0rd", Convert.FromBase64String(salt));

      var myUser = GlobalBuilder.BuildUser(userId, "test@gmail.com", hashedPassword, salt, "testUser");

      generatedUsers.Add(myUser);

      return generatedUsers;
  }
}
