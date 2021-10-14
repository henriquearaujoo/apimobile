using Ailos.Pix.Chave.Data;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using System.Threading;
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

        public async Task<NewKeyResponse> AddKeyAsync(NewKeyRequest newKeyRequest, CancellationToken cancellationToken)
        {
            return await _service.AddAsync(newKeyRequest, cancellationToken);
        }

        public async Task<KeyListResponse> ListKeysAsync(KeyListRequest keyListRequest, CancellationToken cancellationToken)
        {
            return await _service.ListAsync(keyListRequest, cancellationToken);
        }
    }
}
