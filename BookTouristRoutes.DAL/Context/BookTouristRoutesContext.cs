using BookTouristRoutes.Common.Extensions;
using BookTouristRoutes.Common.Models;
using Microsoft.EntityFrameworkCore;

namespace BookTouristRoutes.DAL.Context;

public class BookTouristRoutesContext : DbContext
{
  public BookTouristRoutesContext(DbContextOptions options) : base(options) { }

  public DbSet<User> Users { get; set; }
  public DbSet<Image> Images { get; private set; }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    modelBuilder.Configure();
    modelBuilder.Seed();
  }
}
