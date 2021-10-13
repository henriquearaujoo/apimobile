using Ailos.Http;
using Ailos.SOA.ParametersCard.DTO.Request;
using Ailos.SOA.ParametersCard.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.SOA.ParametersCard.Application
{
    public class ParametersCardService : IParametersCardService
    {
        private readonly IClient _client;

        public ParametersCardService(IClient client)
        {
            _client = new SOAClient();
        }

        public async Task<ObterParametrosCreditoResponse> GetCreditParameters(ObterParametrosCreditoRequest request)
        {
            return await _client.Post<ObterParametrosCreditoResponse>("ObterParametrosCredito", request);
        }

        public async Task<ObterParametrosNovaSolicResponse> GetNewSolicitParameters(ObterParametrosNovaSolicRequest request)
        {
            return await _client.Post<ObterParametrosNovaSolicResponse>("ObterParametrosNovaSolic", request);
        }

        public async Task<ObterParamPreAprovadoCartaoResponse> GetPreApprovedParameters(ObterParamPreAprovadoCartaoRequest request)
        {
            return await _client.Post<ObterParamPreAprovadoCartaoResponse>("ObterParamPreAprovadoCartao", request);
        }

        public async Task<ObterParamSimulacaoResponse> GetSimulationParameters(ObterParamSimulacaoRequest request)
        {
            return await _client.Post<ObterParamSimulacaoResponse>("ObterParamSimulacao", request);
        }

        public async Task<ObterListaMotBloqueioOfertaCartaoResponse> GetCardOfferBlockReasonList(ObterListaMotBloqueioOfertaCartaoRequest request)
        {
            return await _client.Post<ObterListaMotBloqueioOfertaCartaoResponse>("ObterListaMotBloqueioOfertaCartao", request);
        }

        public async Task<ObterListaMotivoNegCartaoResponse> GetDeniedCardReasonList(ObterListaMotivoNegCartaoRequest request)
        {
            return await _client.Post<ObterListaMotivoNegCartaoResponse>("ObterListaMotivoNegCartao", request);
        }

        public async Task<ManterOfertaCartaoResponse> ManageCardOffer(ManterOfertaCartaoRestRequest request)
        {
            return await _client.Post<ManterOfertaCartaoResponse>("ManterOfertaCartao", request);
        }
    }
}