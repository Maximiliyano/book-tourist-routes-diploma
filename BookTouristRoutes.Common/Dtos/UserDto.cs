using System.ComponentModel.DataAnnotations;
using BookTouristRoutes.Common.BaseEntities;

namespace BookTouristRoutes.Common.Dtos;

public class UserDto : BaseModel
{
  [RegularExpression(@"^[a-zA-Z]+(([',. -][a-zA-Z ])?[a-zA-Z]*)*$", ErrorMessage = "Invalid name format")]
  [MaxLength(32)]
  public string Name { get; set; }

  [RegularExpression(@"^(https?:\/\/)?([\da-z\.-]+)\.([a-z\.]{2,6})([\/\w\.-]*)*\/?$", ErrorMessage = "Invalid image URL!")]
  public string? Avatar { get; set; }

  [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "Invalid email format")]
  [MaxLength(64)]
  public string Email { get; set; }
}
