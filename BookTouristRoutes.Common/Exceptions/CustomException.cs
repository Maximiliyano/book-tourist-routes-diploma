using System.Net;

namespace BookTouristRoutes.Common.Exceptions;

public class CustomException : Exception
{
  public CustomException(string message, HttpStatusCode httpStatusCode, object data = null)
    : this( message, null, httpStatusCode, data ?? message) { }

  public CustomException(string message, Exception? innerException, HttpStatusCode httpStatusCode, object data = null)
    : base(message, innerException)
  {
    StatusCode = httpStatusCode;
    Data = data;
  }

  public static CustomException RepeatPasswordException() =>
    new("Password is already use", HttpStatusCode.BadRequest);

  public HttpStatusCode StatusCode { get; set;}

  public new object Data { get; set; }
}
