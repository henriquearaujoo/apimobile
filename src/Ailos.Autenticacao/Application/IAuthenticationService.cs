using Ailos.Autentication.DTO.Response;
using Ailos.Autentication.ViewModel;
using System.Threading.Tasks;

namespace Ailos.Autentication.Application
{
    public interface IAuthenticationService
    {
        Task<Token> AuthenticateAsync(AuthenticationViewModel request);
    }
}
