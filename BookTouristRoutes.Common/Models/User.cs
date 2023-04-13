using BookTouristRoutes.Common.BaseEntities;
using BookTouristRoutes.Common.Enums;

namespace BookTouristRoutes.Common.Models;

public class User : BaseModel
{
  public string Name { get; set; }

  public string Email { get; set; }

  public string Password { get; set; }

  public UserRoles Roles { get; set; }

  public Image Avatar { get; set; }

  public int? AvatarId { get; set; }
}
