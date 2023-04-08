using System.Net;

namespace BookTouristRoutes.Common.Extensions;

public class CustomException : Exception
{
  public static readonly string EntityNotFoundMessage = "{0} with id: {1} not found";

  public CustomException(string message, HttpStatusCode httpStatusCode, object data = null)
    : this( message, null, httpStatusCode, data ?? message) { }

  public CustomException(string message, Exception innerException, HttpStatusCode httpStatusCode, object data = null)
    : base(message, innerException)
  {
    StatusCode = httpStatusCode;
    Data = data;
  }

  public static CustomException EntityNotFound<TKey>(string entityName, TKey key) =>
    new(string.Format(EntityNotFoundMessage, entityName, key), HttpStatusCode.NotFound);

  public HttpStatusCode StatusCode { get; set;}

  public new object Data { get; set; }
}
