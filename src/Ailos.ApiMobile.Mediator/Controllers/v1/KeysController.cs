using Ailos.ApiMobile.Mediator.Contracts.v1.Commands;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Mediator.Controllers.v1
{
    [Route("api/[controller]")]
    public class KeysController : ControllerBase
    {
        private readonly ILogger<KeysController> _logger;
        private readonly IMediator _mediator;

        public KeysController(IMediator mediator, ILogger<KeysController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        /// <summary>
        /// Adiciona uma nova chave
        /// </summary>
        /// <param name="request">Objeto de requisição</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(NewKeyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(NewKeyCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adicionando nova chave");

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }

        /// <summary>
        /// Lista as chaves pix de um cooperado
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(KeyListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(KeyListCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Listando chaves");

            var result = await _mediator.Send(request, cancellationToken);

            return Ok(result);
        }
    }
}
