using Ailos.Pix.DTO.Key;
using Ailos.Pix.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.API.Controllers.v1.Pix
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeysController : ControllerBase
    {
        private readonly IKeyService _keyService;

        public KeysController(IKeyService keyService)
        {
            _keyService = keyService;
        }

        [HttpPost]
        public async Task<NewKeyResponse> AddKey(NewKeyRequest newKeyRequest)
        {
            return await _keyService.AddKey(newKeyRequest);
        }

        [HttpGet("throwing-exception")]
        public void ThrowException()
        {
            throw new System.Exception("Deu ruim proposital!");
        }
    }
}
