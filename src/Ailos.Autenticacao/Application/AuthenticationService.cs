using Ailos.Autentication.Data;
using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using Ailos.Autentication.ViewModel;
using Ailos.Common.Data;
using Ailos.Common.DTO.Request;
using Ailos.Utils;
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

        public async Task<TokenViewModel> AuthenticateAsync(AuthenticationViewModel request)
        {
            var cooperado = await _cooperadoDataService.GetData(new CooperadoRequest
            {
                CodigoCooperativa = request.Dispositivo.CooperativaId,
                NumeroConta = request.Dispositivo.NumeroConta,
                CodigoCanal = 10,
                IpAcionamento = "127.0.0.1"
            }, 1);

            string frase = request.SenhasAutenticacao.Frase.ToUpper();

            var authResult = await _authenticationDataService.Authenticate(new AuthenticationRequest
            {
                CodigoCooperativa = request.Dispositivo.CooperativaId,
                NumeroConta = request.Dispositivo.NumeroConta,
                SequencialTitular = request.Dispositivo.TitularId,
                Frase = frase,
                Senha = PasswordUtil.CypherPassword(request.SenhasAutenticacao.Senha)
            });

            return authResult;
        }
    }
}
