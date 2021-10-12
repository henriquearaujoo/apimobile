using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using Refit;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.Data
{
    public interface IKeyDataService
    {
        [Post("/")]
        Task<NewKeyResponse> Add([Body] NewKeyRequest newKeyRequest);
        [Get("/")]
        Task<KeyListResponse> List(KeyListRequest keyListRequest);
    }
}
