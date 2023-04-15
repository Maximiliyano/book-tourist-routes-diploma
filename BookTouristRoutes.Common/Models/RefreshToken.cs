using BookTouristRoutes.Common.BaseEntities;

namespace BookTouristRoutes.Common.Models;

public sealed class RefreshToken : BaseModel
{
  private const int DaysToExpire = 5;

  public RefreshToken()
  {
    Expires = DateTime.UtcNow.AddDays(DaysToExpire);
  }

  public string Token { get; set; }

  public DateTime Expires { get; private set; }

  public int UserId { get; set; }
  
  public User User { get; set; }

  public bool IsActive => DateTime.UtcNow <= Expires;
}
