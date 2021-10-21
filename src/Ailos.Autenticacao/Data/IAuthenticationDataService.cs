using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using Refit;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Autentication.Data
{
    public interface IAuthenticationDataService
    {
        [Get("/ailos/autenticacao/api/v1/comum/autenticar")]
        Task<AuthenticationResponse> AuthenticateAsync(AuthenticationRequest request, CancellationToken cancellationToken);
    }
}
