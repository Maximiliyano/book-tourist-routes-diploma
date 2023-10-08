namespace BookTouristRoutes.Common.Exceptions;

public sealed class NotFoundException : Exception
{
  private const string EntityWithKeyNotFound = "Entity {0} with id ({1}) was not found.";

  public NotFoundException(string name, object id)
    : base(string.Format(EntityWithKeyNotFound, name, id))
  {
  }

  public NotFoundException(string name) : base($"Entity {name} was not found.") { }
}
