using Ailos.SOA.Common.Card.Response;
using Ailos.SOA.Common.Cartao.Response;
using Ailos.SOA.Common.Response;
using System.Collections.Generic;

namespace Ailos.SOA.ParametersCard.DTO.Response
{
    public class ListaTiposCartaoResponse
    {
        public List<TipoCartao> TipoCartao { get; set; }
    }

    public partial class TipoCartao
    {
        public ListaProgramasRecompensaResponse ListaProgramasRecompensa { get; set; }

        public ListaDiasVencimentoResponse ListaDiasVencimento { get; set; }

        public Cartao Cartao { get; set; }

        public TipoCartaoConfiguracaoCredito ConfiguracaoCredito { get; set; }
    }

    public partial class Cartao
    {
        public PessoaCartao Embossadora { get; set; }

        public TipoResponse TipoAnuidade { get; set; }

        public int QuantParcAnuidade { get; set; }

        public double ValorLimiteCredito { get; set; }

        public TipoDescricaoResponse TipoModalidade { get; set; }

        public double ValorAnuidade { get; set; }

        public string NomeImpresso { get; set; }

        public long DiaVencimento { get; set; }
    }

    public partial class PessoaCartao
    {
        public string RazaoSocialOuNome { get; set; }
    }

    public partial class TipoCartaoConfiguracaoCredito
    {
        public double ValorMaximo { get; set; }

        public double ValorMinimo { get; set; }
    }
}