using Ailos.Pix.DTO.Key;
using Ailos.Pix.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.API.Controllers.v1.Pix
{
    [ApiController]
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class KeysController : ControllerBase
    {
        private readonly ILogger<KeysController> _logger;
        private readonly IKeyService _keyService;

        public KeysController(IKeyService keyService, ILogger<KeysController> logger)
        {
            _keyService = keyService;
            _logger = logger;
        }

        /// <summary>
        /// Adiciona uma nova chave
        /// </summary>
        /// <param name="newKeyRequest">Objeto de requisição</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(NewKeyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddKey(NewKeyRequest newKeyRequest)
        {
            _logger.LogInformation("Adicionando nova chave");

            return Ok(await _keyService.AddKey(newKeyRequest));
        }
    }
}
