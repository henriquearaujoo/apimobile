using Ailos.Pix.Cadastro.Application;
using Ailos.Pix.Cadastro.DTO.Request;
using Ailos.Pix.Cadastro.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Pix
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
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
        [HttpPost("ListarParametrosPix")]
        [ProducesResponseType(typeof(ParametersResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetParameters(CancellationToken camcellationToken)
        {
            _logger.LogInformation("Listando parâmetros pix");

            var request = new ParametersRequest
            {
                CodigoCooperativa = 1,
                CodigoCanal = 10,
                IpAcionamento = "127.0.0.1"
            };

            return Ok(await _registrationService.ParametersListAsync(request, camcellationToken));
        }
    }
}
