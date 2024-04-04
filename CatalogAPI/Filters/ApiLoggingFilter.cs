using Microsoft.AspNetCore.Mvc.Filters;

namespace CatalogAPI.Filters
{
    public class ApiLoggingFilter : IActionFilter
    {
        private readonly ILogger<ApiLoggingFilter> _logger;

        public ApiLoggingFilter(ILogger<ApiLoggingFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation(" ### Executando -> OnExecuting");
            _logger.LogInformation(" ###############################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString}");
            _logger.LogInformation($"{context.ModelState.IsValid}");
            _logger.LogInformation(" ###############################");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            _logger.LogInformation(" ### Executando -> OnExecuted");
            _logger.LogInformation(" ###############################");
            _logger.LogInformation($"{DateTime.Now.ToLongTimeString}");
            _logger.LogInformation($"{context.HttpContext.Response.StatusCode}");
            _logger.LogInformation(" ###############################");
        }
    }
}
