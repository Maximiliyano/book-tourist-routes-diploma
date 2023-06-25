namespace BookTouristRoutes.Common.Exceptions;

public sealed class InvalidUserCredentialsException : Exception
{
  public InvalidUserCredentialsException()
    : base("Invalid password or username")
  {
  }
}
