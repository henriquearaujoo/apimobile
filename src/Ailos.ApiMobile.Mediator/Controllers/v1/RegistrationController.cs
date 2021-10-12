using Ailos.ApiMobile.Mediator.Contracts.v1.Commands;
using Ailos.Pix.Cadastro.DTO.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Mediator.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : ControllerBase
    {
        private readonly ILogger<RegistrationController> _logger;
        private readonly IMediator _mediator;

        public RegistrationController(ILogger<RegistrationController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// Lista os parâmetros pix
        /// </summary>
        /// <returns></returns>
        [HttpPost("parameters")]
        [ProducesResponseType(typeof(ParametersResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetParameters(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Listando parâmetros pix");

            var command = new ParametersCommand
            {
                CodigoCooperativa = 1,
                CodigoCanal = 10,
                IpAcionamento = "127.0.0.1"
            };

            var result = await _mediator.Send(command, cancellationToken);

            return Ok(result);
        }
    }
}
