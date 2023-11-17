using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaretProject.Application.Extention
{
    
    public class LogFilter : Attribute,IAsyncActionFilter
    {
        private readonly ILogger<LogFilter> _logger;
        public LogFilter(ILogger<LogFilter> logger)
        {
            _logger = logger;
        }
        //public void OnActionExecuted(ActionExecutedContext context)
        //{
        //    _logger.LogInformation(context.ActionDescriptor.DisplayName + "Executed");
        //}

        //public void OnActionExecuting(ActionExecutingContext context)
        //{
        //    _logger.LogInformation(context.ActionDescriptor.DisplayName + "Executing");
        //}
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            _logger.LogInformation(context.ActionDescriptor.DisplayName + " Executing");

            var result = await next();

            _logger.LogInformation(context.ActionDescriptor.DisplayName + "is Executed");
        }
    }
}
