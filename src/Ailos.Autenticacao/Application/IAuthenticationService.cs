using Ailos.Autentication.DTO.Response;
using Ailos.Autentication.ViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace Ailos.Autentication.Application
{
    public interface IAuthenticationService
    {
        Task<TokenViewModel> AuthenticateAsync(AuthenticationViewModel request, CancellationToken cancellationToken);
    }
}
