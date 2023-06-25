namespace BookTouristRoutes.Common.Exceptions;

public sealed class RepeatException : Exception
{
  public RepeatException(string name, string key)
    : base($"{name} with the same {key} is exist in system!")
  {
  }
}

