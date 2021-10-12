using Ailos.ApiMobile.Filters;
using Ailos.Pix.Chave.Application;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.v1.Pix
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ServiceFilter(typeof(Wso2AuthenticationFilter))]
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
        /// <returns></returns>
        [HttpPost("Add")]
        [ProducesResponseType(typeof(NewKeyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> Add(NewKeyRequest newKeyRequest)
        {
            _logger.LogInformation("Adicionando nova chave");
            return Ok(await _keyService.Add(newKeyRequest));
        }

        /// <summary>
        /// Lista as chaves pix de um cooperado
        /// </summary>
        /// <param name="keyListRequest"></param>
        /// <returns></returns>
        [HttpPost("List")]
        [ProducesResponseType(typeof(KeyListResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> List(KeyListRequest keyListRequest)
        {
            _logger.LogInformation("Listando chaves");
            return Ok(await _keyService.List(keyListRequest));
        }
    }
}
