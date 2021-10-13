using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.Autentication.Application
{
    public interface IAuthenticationService
    {
        Task<Token> Authenticate(AuthenticationRequest request);
    }
}
