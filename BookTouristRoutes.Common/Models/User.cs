using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Enums;

namespace BookTouristRoutes.Common.Models;

public sealed class User : BaseModel
{
  public string Name { get; set; }

  public string Email { get; set; }

  public string Password { get; set; }

  public string Salt { get; set; }

  public UserRoles Role { get; set; }

  public Image Avatar { get; set; }

  public int? AvatarId { get; set; }
}
