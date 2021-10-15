using Ailos.Autentication.Application;
using Ailos.Autentication.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers
{
    [ApiController]
    [Route("api/Seguranca")]
    public class AuthenticationController : ControllerBase
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationViewModel request, CancellationToken cancellationToken)
        {
            var token = await _authenticationService.AuthenticateAsync(request, cancellationToken);
            return Ok(token);
        }
    }
}
