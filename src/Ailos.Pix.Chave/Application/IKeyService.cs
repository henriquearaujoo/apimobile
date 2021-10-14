using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.Application
{
    public interface IKeyService
    {
        Task<NewKeyResponse> AddKeyAsync(NewKeyRequest newKeyRequest, CancellationToken cancellationToken);
        Task<KeyListResponse> ListKeysAsync(KeyListRequest keyListRequest, CancellationToken cancellationToken);
    }
}
