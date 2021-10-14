using Ailos.Pix.Chave.DTO.Request;
using Ailos.Pix.Chave.DTO.Response;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Pix.Chave.Data
{
    public interface IKeyDataService
    {
        [Post("/")]
        Task<NewKeyResponse> AddAsync([Body] NewKeyRequest request, CancellationToken cancellationToken);
        
        [Get("/")]
        Task<KeyListResponse> ListAsync(KeyListRequest request, CancellationToken cancellationToken);
    }
}
