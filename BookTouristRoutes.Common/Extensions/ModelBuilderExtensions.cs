using BookTouristRoutes.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.Common.Extensions;

public static class ModelBuilderExtensions
{
  public static void Configure(this ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<RefreshToken>().Ignore(t => t.IsActive);
  }

  public static void Seed(this ModelBuilder modelBuilder)
  {
  }
}
