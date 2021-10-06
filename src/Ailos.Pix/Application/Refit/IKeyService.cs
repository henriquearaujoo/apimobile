using Ailos.Pix.DTO.Key;
using Refit;
using System.Threading.Tasks;

namespace Ailos.Pix.Application.Refit
{
    public interface IKeyService
    {
        [Post("/")]
        Task<NewKeyResponse> AddKey([Body] NewKeyRequest newKeyRequest);
    }
}
