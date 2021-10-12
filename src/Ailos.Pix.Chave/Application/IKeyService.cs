using Ailos.Http.Data;
using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.Application
{
    public interface IKeyService
    {
        Task<NewKeyResponse> Add(NewKeyRequest newKeyRequest);
        Task<KeyListResponse> List(KeyListRequest keyListRequest);
    }
}
