using Ailos.SOA.Common.Cartao.Response;
using Ailos.SOA.Common.Response;
using Ailos.SOA.ParametersCard.DTO.Common;
using System.Collections.Generic;

namespace Ailos.SOA.ParametersCard.DTO.Response
{
    public class ObterParametrosNovaSolicResponse
    {
        public PropostaCartaoResponse PropostaCartao { get; set; }

        public ListaEnderecosCooperativaResponse ListaEnderecosCooperativa { get; set; }

        public ListaEnderecosCooperadoResponse ListaEnderecosCooperado { get; set; }

        public ConfiguracaoCredito ConfiguracaoCredito { get; set; }

        public ListaNomesImpressosResponse ListaNomesImpressos { get; set; }

        public PessoaDocumento PessoaDocumento { get; set; }

        public ParametrosPropostaCartao ParametrosPropostaCartao { get; set; }

        public ListaTiposCartaoResponse ListaTiposCartao { get; set; }

        public ListaTiposLiquidacao ListaTiposLiquidacao { get; set; }

        public PessoaFisicaRendimento PessoaFisicaRendimento { get; set; }

        public ListaEmbossadorasResponse ListaEmbossadoras { get; set; }
    }

    public partial class ListaTiposLiquidacao
    {
        public List<TipoDescricaoResponse> TipoLiquidacao { get; set; }
    }

    public partial class ParametrosPropostaCartao
    {
        public long IdLimitePreAprovado { get; set; }
    }

    public partial class PessoaDocumento
    {
        public TipoPessoaDocumento Tipo { get; set; }
        public string Identificador { get; set; }
    }

    public partial class TipoPessoaDocumento
    {
        public string Sigla { get; set; }
    }

    public partial class PessoaFisicaRendimento
    {
        public long ValorMensal { get; set; }
        public string IndicadorRendimentoPrincipal { get; set; }
    }
}