using Ailos.Pix.Chave.Application;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.v1.Pix
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    public class KeysController : ControllerBase
    {
        private readonly ILogger<KeysController> _logger;
        private readonly IKeyService _keyService;

        public KeysController(ILogger<KeysController> logger, IKeyService keyService)
        {
            _logger = logger;
            _keyService = keyService;
        }

        /// <summary>
        /// Adiciona uma nova chave
        /// </summary>
        /// <param name="newKeyRequest">Objeto de requisição</param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(NewKeyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(NewKeyRequest newKeyRequest, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Adicionando nova chave");
            return Ok(await _keyService.AddKeyAsync(newKeyRequest, cancellationToken));
        }

        /// <summary>
        /// Lista as chaves pix de um cooperado
        /// </summary>
        /// <param name="keyListRequest"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpPost("List")]
        [ProducesResponseType(typeof(KeyListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(KeyListRequest keyListRequest, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Listando chaves");
            return Ok(await _keyService.ListKeysAsync(keyListRequest, cancellationToken));
        }
    }
}
