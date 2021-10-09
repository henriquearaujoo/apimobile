using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Ailos.ApiMobile.Controllers.v2
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ExceptionController : ControllerBase
    {
        private readonly ILogger<ExceptionController> _logger;

        public ExceptionController(ILogger<ExceptionController> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Gera uma exceção
        /// </summary>
        [HttpPost("throw")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public void Throw()
        {
            try
            {
                throw new Exception("Deu ruim proposital!");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro!");
                throw;
            }
        }
    }
}
