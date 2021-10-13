using Ailos.SOA.CardAutorization.DTO.Request;
using Ailos.SOA.CardAutorization.DTO.Response;
using Ailos.SOA.Common;
using Ailos.SOA.Common.Response;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.SOA.CardAutorization.Application
{
    public interface ICardAuthorizationService
    {
        Task<AutorizacaoListaResponse> GetAuthorizePendencies();

        Task<DetalhesPropostaResponse> AuthorizePendancyDetails(string propouseNumber);

        Task<EditarCartaoResponse> AuthorizePendancyEdit(string propouseNumber);

        Task<MensagemRetorno> PropouseStatusApprove(AprovarCartaoRequest request);

        Task<MensagemRetorno> PropouseStatusCancel(CancelarCartaoRequest request);

        Task<ResponseControlResponse> PropouseStatusEffective(EfetivarSituacaoPropostaRequest request);

        Task<MotivosCancelamentoCartaoResponse> CardCancellationReasons();
    }
}