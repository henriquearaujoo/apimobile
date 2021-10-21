using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ailos.Autentication.Data
{
    public interface IAuthenticationDataService
    {
        [Post("/ailos/autenticacao/api/v1/comum/autenticar")]
        Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
    }
}
