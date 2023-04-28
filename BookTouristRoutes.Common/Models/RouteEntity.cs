using BookTouristRoutes.Common.BaseEntities;

namespace BookTouristRoutes.Common.Models;

public class RouteEntity : BaseModel
{
  public string Name { get; set; }

  public string Description { get; set; }

  public DateTime StartDate { get; set; }

  public DateTime EndDate { get; set; }

  public int Seats { get; set; }

  public int BookedSeats { get; set; }

  public decimal Price { get; set; }

  public string Destination { get; set; }
}
