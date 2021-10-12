using Ailos.ApiMobile.Filters;
using Ailos.Pix.Cadastro.Application;
using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Pix
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : BasePixController
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IRegistrationService _registrationService;

        public RegistrationController(ILogger<RegistrationController> logger, IRegistrationService registrationService)
        {
            _logger = logger;
            _registrationService = registrationService;
        }


        /// <summary>
        /// Lista os parâmetros pix
        /// </summary>
        /// <returns></returns>
        [HttpPost("parameters")]
        [ProducesResponseType(typeof(ParametersResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetParameters()
        {
            _logger.LogInformation("Listando parâmetros pix");
            return Ok(await _registrationService.ParametersList(new ParametersRequest()
            {
                CodigoCooperativa = 1,
                CodigoCanal = 10,
                IpAcionamento = "127.0.0.1"
            }));
        }
    }
}
