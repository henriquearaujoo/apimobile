using Ailos.SOA.CardAutorization.Application;
using Ailos.SOA.CardAutorization.DTO.Request;
using Ailos.SOA.CardAutorization.DTO.Response;
using Ailos.SOA.Common;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Api.SOA.Card
{
    public class AuthorizationCardController
    {
        private readonly ICardAuthorizationService _cardAuthorizationService;

        public AuthorizationCardController(ICardAuthorizationService cardAuthorizationService)
        {
            _cardAuthorizationService = cardAuthorizationService;
        }

        [HttpGet]
        [Route("api/Cartao/Autorizacao/Listar")]
        public async Task<AutorizacaoListaResponse> GetAuthorizePendencies()
        {
            return await _cardAuthorizationService.GetAuthorizePendencies();
        }

        [HttpGet]
        [Route("api/Cartao/Autorizacao/Detalhes/{numeroProposta}")]
        public async Task<DetalhesPropostaResponse> AuthorizePendancyDetails(string propouseNumber)
        {
            return await _cardAuthorizationService.AuthorizePendancyDetails(propouseNumber);
        }

        [HttpGet]
        [Route("api/Cartao/Autorizacao/Editar/{numeroProposta}")]
        public async Task<EditarCartaoResponse> AuthorizePendancyEdit(string propouseNumber)
        {
            return await _cardAuthorizationService.AuthorizePendancyEdit(propouseNumber);
        }

        [HttpPost]
        [Route("api/Cartao/Autorizacao/Aprovar")]
        public async Task<MensagemRetorno> PropouseStatusApprove(AprovarCartaoRequest request)
        {
            return await _cardAuthorizationService.PropouseStatusApprove(request);
        }

        [HttpPost]
        [Route("api/Cartao/Autorizacao/Cancelar")]
        public async Task<MensagemRetorno> PropouseStatusCancel(CancelarCartaoRequest request)
        {
            return await _cardAuthorizationService.PropouseStatusCancel(request);
        }

        [HttpGet]
        [Route("api/Cartao/Autorizacao/MotivosCancelamentoCartao")]
        public async Task<MotivosCancelamentoCartaoResponse> CardCancellationReasons()
        {
            return await _cardAuthorizationService.CardCancellationReasons();
        }
    }
}