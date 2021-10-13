using Ailos.SOA.Common.Response;
using System.Collections.Generic;

namespace Ailos.SOA.ParametersCard.DTO.Response
{
    public partial class ObterParametrosCreditoResponse
    {
        public ListaMotivosAnulacaoProposta ListaMotivosAnulacaoProposta { get; set; }
    }

    public partial class ListaMotivosAnulacaoProposta
    {
        public List<PropostaContratoCreditoParametrosCreditoResponse> PropostaContratoCredito { get; set; }
    }

    public partial class PropostaContratoCreditoParametrosCreditoResponse
    {
        public TipoDescricaoResponse MotivoAnulacao { get; set; }
    }
}