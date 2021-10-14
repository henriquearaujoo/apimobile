using Ailos.ApiMobile.Controllers.Pix;
using Ailos.Autentication.Application;
using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using Ailos.Autentication.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers
{
    [Route("api/Seguranca")]
    public class AuthenticationController : BasePixController
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthenticationService authenticationService)
        {
            _logger = logger;
            _authenticationService = authenticationService;
        }

        [HttpPost("Autenticar")]
        public async Task<IActionResult> AuthenticateAsync(AuthenticationViewModel request)
        {
            var token = await _authenticationService.AuthenticateAsync(request);
            return Ok(token);
        }
    }
}
