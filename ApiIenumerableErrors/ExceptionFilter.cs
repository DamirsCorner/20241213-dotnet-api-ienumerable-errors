using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ApiIenumerableErrors;

public class ExceptionFilter : IActionFilter
{
    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            context.Result = new ObjectResult(new { context.Exception.Message })
            {
                StatusCode = 500
            };
            context.ExceptionHandled = true;
        }
    }

    public void OnActionExecuting(ActionExecutingContext context) { }
}
