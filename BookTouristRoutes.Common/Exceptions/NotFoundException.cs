namespace BookTouristRoutes.Common.Exceptions;

public sealed class NotFoundException : Exception
{
  private const string EntityWithKeyNotFound = "Entity {0} with id ({1}) was not found.";

  public NotFoundException(string name, int id)
    : base(string.Format(EntityWithKeyNotFound, name, id))
  {
  }

  public NotFoundException(string name, string key)
    : base(string.Format(EntityWithKeyNotFound, name, key))
  {
  }

  public NotFoundException(string name) : base($"Entity {name} was not found.") { }
}
