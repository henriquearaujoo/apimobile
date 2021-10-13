using Ailos.SOA.Common.Response;
using System;

namespace Ailos.SOA.ParametersCard.DTO.Response
{
    public class PropostaCartaoResponse
    {
        public Emitente Emitente { get; set; }
        public TipoDescricaoResponse TipoLiquidacao { get; set; }
        public int QtDiasEntregaPrevista { get; set; }
    }

    public partial class Emitente
    {
        public string IdentificadorReceitaFederal { get; set; }
        public TipoResponse Tipo { get; set; }
        public DateTime DataNascOuConstituicao { get; set; }
    }
}