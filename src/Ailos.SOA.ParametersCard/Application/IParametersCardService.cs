using Ailos.SOA.ParametersCard.DTO.Request;
using Ailos.SOA.ParametersCard.DTO.Response;
using System.Threading.Tasks;

namespace Ailos.SOA.ParametersCard.Application
{
    public interface IParametersCardService
    {
        Task<ObterParamPreAprovadoCartaoResponse> GetPreApprovedParameters(ObterParamPreAprovadoCartaoRequest request);

        Task<ObterParamSimulacaoResponse> GetSimulationParameters(ObterParamSimulacaoRequest request);

        Task<ObterParametrosCreditoResponse> GetCreditParameters(ObterParametrosCreditoRequest request);

        Task<ObterParametrosNovaSolicResponse> GetNewSolicitParameters(ObterParametrosNovaSolicRequest request);

        Task<ObterListaMotBloqueioOfertaCartaoResponse> GetCardOfferBlockReasonList(ObterListaMotBloqueioOfertaCartaoRequest request);

        Task<ObterListaMotivoNegCartaoResponse> GetDeniedCardReasonList(ObterListaMotivoNegCartaoRequest request);

        Task<ManterOfertaCartaoResponse> ManageCardOffer(ManterOfertaCartaoRestRequest request);
    }
}