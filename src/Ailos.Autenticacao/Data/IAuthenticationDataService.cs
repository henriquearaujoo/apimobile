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
        [Get("/ailos/autenticacao/api/v1/comun/autenticar")]
        Task<ApiResponse<Token>> Authenticate(AuthenticationRequest request);
    }
}
