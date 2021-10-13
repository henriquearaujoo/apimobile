using Ailos.SOA.Card.DTO.Request;
using Ailos.SOA.Card.DTO.Response;
using Ailos.SOA.Common.Cartao.Response;
using Ailos.SOA.DTO.Card.Request;
using Ailos.SOA.DTO.Card.Response;
using System;
using System.Threading.Tasks;

namespace Ailos.SOA.Cartao.Application
{
    public interface ICardService
    {
        Task<TermoAdesaoCartaoResponse> GetAdhesionTerm(ObterTermoAdesaoRequest request);

        Task<ObterDetalhePropostaResponse> GetPropouseDetails(ObterDetalhePropostaRestRequest request);

        Task<ObterListaPendenciasCartaoResponse> GetCardPendencyList(ObterListaPendenciasCartaoRequest request);

        Task<PermissoesCartaoResponse> TakeMenuPermissions();

        string GetPropouseAdress(ObterDetalhePropostaResponse proposta);

        Uri GetCardImage(int codigoCartao);
    }
}