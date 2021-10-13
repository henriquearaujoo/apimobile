using Ailos.SOA.Common;
using Ailos.SOA.PreApprovedCard.DTO.Common;
using Ailos.SOA.PreApprovedCard.DTO.Request;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.SOA.PreApprovedCard.Application
{
    public interface IPreApprovedCardService
    {
        Task<PropostaAndamentoResponse> PropouseProgress();

        Task<LimitesCooperado> GetCooperativistLimit();

        Task<ModalidadesResponse> Modalities(double limit);

        Task<EnderecoEntregaCartaoResponse> DeliveryAdresses();

        Task<MensagemRetorno> RequestPreApprovedCard(SolicitarNovoCartaoRequest request);

        Task<ListaMotivosCancelamentoOfertaResponse> GetOfferCancellationReason();

        Task<MensagemRetorno> CancelOffer(CancelarOfertaCartaoRequest request);
    }
}