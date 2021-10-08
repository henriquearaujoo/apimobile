﻿using Ailos.Pix.Application.Refit;
using Ailos.Pix.DTO.Key;
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

        public KeysController(ILogger<KeysController> logger, IKeyService keyService)
        {
            _logger = logger;
            _keyService = keyService;
        }

        /// <summary>
        /// Adiciona uma nova chave
        /// </summary>
        /// <param name="request">Objeto de requisição</param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(NewKeyResponse), StatusCodes.Status200OK)]
        public async Task<IActionResult> AddKey(NewKeyRequest request)
        {
            _logger.LogInformation("Adicionando nova chave");

            return Ok(await _keyService.AddKey(request));
        }
    }
}
