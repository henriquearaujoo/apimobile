using Ailos.Pix.DTO.Key;
using System.Threading.Tasks;

namespace Ailos.Pix.Services
{
    public interface IKeyService
    {
        Task<NewKeyResponse> AddKey(NewKeyRequest newKeyRequest);
    }
}