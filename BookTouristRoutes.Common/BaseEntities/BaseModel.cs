namespace BookTouristRoutes.Common.BaseEntities;

public class BaseModel
{
  private DateTime _createdAt;

  public BaseModel()
  {
    CreatedAt = UpdatedAt = DateTime.Now;
  }

  public int Id { get; set; }

  public DateTime CreatedAt
  {
    get => _createdAt;
    set => _createdAt = (value == DateTime.MinValue) ? DateTime.Now : value;
  }

  public DateTime UpdatedAt { get; set; }
}
