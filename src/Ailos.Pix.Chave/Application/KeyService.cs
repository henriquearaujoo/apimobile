using Ailos.Http.Data;
using Ailos.Pix.Chave.Data;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.Application
{
    public class KeyService : IKeyService
    {
        private readonly IKeyDataService _service;

        public KeyService(IKeyDataService service)
        {
            _service = service;
        }

        public async Task<NewKeyResponse> Add(NewKeyRequest newKeyRequest)
        {
            return await _service.Add(newKeyRequest);
        }

        public async Task<KeyListResponse> List(KeyListRequest keyListRequest)
        {
            return await _service.List(keyListRequest);
        }
    }
}
