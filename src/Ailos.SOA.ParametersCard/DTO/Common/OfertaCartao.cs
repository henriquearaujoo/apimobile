using Ailos.SOA.Common;

namespace Ailos.SOA.ParametersCard.DTO.Common
{
    public class OfertaCartao
    {
        public OfertaCartao()
        {
            ExpiracaoStatus = new TipoRequest
            {
                Codigo = 1
            };
            TipoInteracao = "BLOQUEAR";
        }

        public TipoRequest ExpiracaoStatus { get; private set; }
        public TipoRequest MotivoBloqueio { get; set; }
        public string TipoInteracao { get; private set; }
    }
}