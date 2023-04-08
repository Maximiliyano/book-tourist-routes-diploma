using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace BookTouristRoutes.Common.Extensions;

public class CustomExceptionHandlerMiddleware
{
  private readonly RequestDelegate _next;

  public CustomExceptionHandlerMiddleware(RequestDelegate next)
  {
    _next = next;
  }

  public async Task InvokeAsync(HttpContext context)
  {
    try
    {
      await _next(context);
    }
    catch (CustomException ex)
    {
      context.Response.ContentType = "application/json";
      context.Response.StatusCode = (int)ex.StatusCode;
      await context.Response.WriteAsync(JsonConvert.SerializeObject(new { error = ex.Message }));
    }
  }
}
