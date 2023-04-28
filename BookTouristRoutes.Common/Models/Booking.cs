using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Enums;

namespace BookTouristRoutes.Common.Models;

public class Booking : BaseModel
{
  public Guid Uid { get; set; }

  public int UserId { get; set; }

  public int RouteId { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime EndDate { get; set; }

  public decimal Price { get; set; }

  public BookingStatus Status { get; set; }
};
