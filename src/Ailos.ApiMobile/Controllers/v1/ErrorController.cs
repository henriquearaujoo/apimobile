using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ailos.ApiMobile.Controllers.v1
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public IActionResult Error()
        {
            var execptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            var instance = execptionFeature.Path;
            var title = execptionFeature.Error.Message;
            var detail = execptionFeature.Error.StackTrace;

            _logger.LogError(execptionFeature.Error, "Tratando erro no endpoint");

            return Problem(detail, instance, title: title);
        }
    }
}
