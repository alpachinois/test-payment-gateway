using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace PaymentGateway.Api.Controllers
{
    public class ExceptionFilterAttribute : Microsoft.AspNetCore.Mvc.Filters.ExceptionFilterAttribute
    {
        public override Task OnExceptionAsync(ExceptionContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<ExceptionFilterAttribute>>();

            switch (context.Exception)
            {
                case KeyNotFoundException:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                    context.Result = new JsonResult(context.Exception.Message);
                    logger.LogError(context.Exception, context.Exception.Message);
                    break;
                default:
                    context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                    context.Result = new JsonResult(context.Exception.Message);
                    logger.LogError(context.Exception, context.Exception.Message);
                    break;
            }

            return Task.CompletedTask;
        }
    }
}
