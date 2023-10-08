using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace BookTouristRoutes.Api.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
  public override void OnException(ExceptionContext context)
  {
    var statusCode = context.Exception.ParseException();

    context.HttpContext.Response.ContentType = "application/json";
    context.HttpContext.Response.StatusCode = (int)statusCode;
    context.Result = new JsonResult(new
    {
      error = context.Exception.Message
    });
  }
}