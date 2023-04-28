namespace BookTouristRoutes.Common.Dtos;

public class BookingFilterDto
{
  public DateTime StartDate { get; set; }

  public DateTime EndDate { get; set; }

  public int Seats { get; set; }

  public decimal Price { get; set; }
}
