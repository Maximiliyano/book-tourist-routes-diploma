using System.Net;

namespace BookTouristRoutes.Common.Exceptions;

public class CustomException : Exception
{
  private const string EntityNotFoundMessage = "{0} with id: {1} not found";
  private const string InvalidTokenMessage = "Invalid {0} token {1}";

  public CustomException(string message, HttpStatusCode httpStatusCode, object data = null)
    : this( message, null, httpStatusCode, data ?? message) { }

  public CustomException(string message, Exception? innerException, HttpStatusCode httpStatusCode, object data = null)
    : base(message, innerException)
  {
    StatusCode = httpStatusCode;
    Data = data;
  }

  public static CustomException EntityNotFound<TKey>(string entityName, TKey key) =>
    new(string.Format(EntityNotFoundMessage, entityName, key), HttpStatusCode.NotFound);

  public static CustomException InvalidUsernameOrPasswordException() =>
    new("Invalid password or username", HttpStatusCode.BadRequest);

  public static CustomException RepeatPasswordException() =>
    new("Password is already use", HttpStatusCode.BadRequest);

  public static CustomException InvalidTokenException<TKey>(string entityName, TKey key) =>
    new(string.Format(InvalidTokenMessage, entityName, key), HttpStatusCode.BadRequest);

  public static CustomException ExpiredRefreshTokenException() =>
    new ("Refresh token expired.", HttpStatusCode.Forbidden);

  public HttpStatusCode StatusCode { get; set;}

  public new object Data { get; set; }
}
