using Ailos.Autentication.Data;
using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using Ailos.Common.Data;
using Ailos.Common.DTO.Request;
using System;
using System.Threading.Tasks;

namespace Ailos.Autentication.Application
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IAuthenticationDataService _authenticationDataService;
        private readonly ICooperadoDataService _cooperadoDataService;

        public AuthenticationService(IAuthenticationDataService authenticationDataService, ICooperadoDataService cooperadoDataService)
        {
            _authenticationDataService = authenticationDataService;
            _cooperadoDataService = cooperadoDataService;
        }

        public async Task<Token> Authenticate(AuthenticationRequest authenticationRequest)
        {
            var cooperadoRequest = new CooperadoRequest
            {
                CodigoCooperativa = authenticationRequest.Dispositivo.CooperativaId,
                NumeroConta = authenticationRequest.Dispositivo.NumeroConta,
                CodigoCanal = 10,
                IpAcionamento = "127.0.0.1"
            };

            var cooperado = await _cooperadoDataService.GetData(cooperadoRequest, 1);

            return new Token
            {
                Autorizacao = "sas"
            };
        }
    }
}
