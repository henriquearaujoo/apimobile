using Ailos.Autentication.Data;
using Ailos.Autentication.DTO.Request;
using Ailos.Autentication.DTO.Response;
using Ailos.Autentication.ViewModel;
using Ailos.Common.Data;
using Ailos.Common.DTO.Request;
using Ailos.Utils;
using System.Threading;
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

        public async Task<Token> AuthenticateAsync(AuthenticationViewModel request, CancellationToken cancellationToken)
        {
            var cooperadoRequest = new CooperadoRequest
            {
                CodigoCooperativa = request.Dispositivo.CooperativaId,
                NumeroConta = request.Dispositivo.NumeroConta,
                CodigoCanal = 10,
                IpAcionamento = "127.0.0.1"
            };

            var cooperado = await _cooperadoDataService.GetDataAsync(cooperadoRequest, 1, cancellationToken);

            var frase = request.SenhasAutenticacao.Frase.ToUpper();

            var authRequest = new AuthenticationRequest
            {
                CodigoCooperativa = request.Dispositivo.CooperativaId,
                NumeroConta = request.Dispositivo.NumeroConta,
                SequencialTitular = request.Dispositivo.TitularId,
                Frase = frase,
                Senha = PasswordUtil.CypherPassword(request.SenhasAutenticacao.Senha)
            };

            var authResult = await _authenticationDataService.AuthenticateAsync(authRequest, cancellationToken);

            return new Token
            {
                Autorizacao = "sas"
            };
        }
    }
}
