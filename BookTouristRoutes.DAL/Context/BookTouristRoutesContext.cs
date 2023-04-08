using BookTouristRoutes.Common.Dtos;
using BookTouristRoutes.Common.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.DAL.Context;

public class BookTouristRoutesContext : DbContext
{
  public BookTouristRoutesContext(DbContextOptions options) : base(options) { }

  public DbSet<UserDto> Users { get; set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Configure();
    modelBuilder.Seed();
  }
}
