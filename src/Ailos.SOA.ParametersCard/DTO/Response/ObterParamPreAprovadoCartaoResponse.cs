using Ailos.SOA.ParametersCard.DTO.Common;

namespace Ailos.SOA.ParametersCard.DTO.Response
{
    public class ObterParamPreAprovadoCartaoResponse
    {
        public PropostaCartao PropostaCartao { get; set; }
        public ConfiguracaoCredito ConfiguracaoCredito { get; set; }
    }

    public class PropostaCartao
    {
        public string IdentificadorProposta { get; set; }
    }
}