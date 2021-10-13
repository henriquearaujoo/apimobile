using Ailos.SOA.Common;
using Ailos.SOA.PreApprovedCard.Application;
using Ailos.SOA.PreApprovedCard.DTO.Common;
using Ailos.SOA.PreApprovedCard.DTO.Request;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ailos.ApiMobile.Controllers.Api.SOA.Card
{
    public class PreApprovedCardController
    {
        private readonly IPreApprovedCardService _preApprovedCardService;

        public PreApprovedCardController(IPreApprovedCardService preApprovedCardService)
        {
            _preApprovedCardService = preApprovedCardService;
        }

        [HttpGet]
        [Route("api/Cartao/PreAprovado/PropostaAndamento")]
        public async Task<PropostaAndamentoResponse> PropouseProgress()
        {
            return await _preApprovedCardService.PropouseProgress();
        }

        [HttpGet]
        [Route("api/Cartao/PreAprovado/Limites")]
        public async Task<LimitesCooperado> GetCooperativistLimit()
        {
            return await _preApprovedCardService.GetCooperativistLimit();
        }

        [HttpGet]
        [Route("api/Cartao/PreAprovado/Modalidades")]
        public async Task<ModalidadesResponse> Modalities(double limit)
        {
            return await _preApprovedCardService.Modalities(limit);
        }

        [HttpGet]
        [Route("api/Cartao/PreAprovado/EnderecosEntrega")]
        public async Task<EnderecoEntregaCartaoResponse> DeliveryAdresses()
        {
            return await _preApprovedCardService.DeliveryAdresses();
        }

        [HttpPost]
        [Route("api/Cartao/PreAprovado/Solicitar")]
        public async Task<MensagemRetorno> RequestPreApprovedCard(SolicitarNovoCartaoRequest request)
        {
            return await _preApprovedCardService.RequestPreApprovedCard(request);
        }

        [HttpGet]
        [Route("api/Cartao/PreAprovado/MotivosCancelamentoOferta")]
        public async Task<ListaMotivosCancelamentoOfertaResponse> GetOfferCancellationReason()
        {
            return await _preApprovedCardService.GetOfferCancellationReason();
        }

        [HttpPost]
        [Route("api/Cartao/PreAprovado/CancelarOferta")]
        public async Task<MensagemRetorno> CancelarOferta(CancelarOfertaCartaoRequest request)
        {
            return await _preApprovedCardService.CancelOffer(request);
        }
    }
}