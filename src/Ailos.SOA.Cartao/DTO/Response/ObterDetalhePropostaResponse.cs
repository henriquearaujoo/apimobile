using Ailos.SOA.Common.Card.Response;
using Ailos.SOA.Common.Cartao.Response;
using Ailos.SOA.Common.Response;
using System;
using System.Collections.Generic;

namespace Ailos.SOA.Card.DTO.Response
{
    public class ObterDetalhePropostaResponse
    {
        public PropostaCartao PropostaCartao { get; set; }
        public CartaoDetalhesProposta Cartao { get; set; }
        public ConfiguracaoCreditoDetalhesProposta ConfiguracaoCredito { get; set; }
        public ListaProgramasRecompensaResponse ListaProgramasRecompensa { get; set; }
        public ListaDiasVencimentoResponse ListaDiasVencimento { get; set; }
        public ListaTiposLiquidacaoDetalhesProposta ListaTiposLiquidacao { get; set; }
        public ListaEnderecosCooperadoResponse ListaEnderecosCooperado { get; set; }
        public ListaEnderecosCooperativaResponse ListaEnderecosCooperativa { get; set; }
        public ListaNomesImpressosResponse ListaNomesImpressos { get; set; }
        public ListaEmbossadorasResponse ListaEmbossadoras { get; set; }
    }

    public partial class CartaoDetalhesProposta
    {
        public int DiaVencimento { get; set; }
        public string NomeImpresso { get; set; }
        public EmbossadoraDetalhesResponse Embossadora { get; set; }
        public int QuantParcAnuidade { get; set; }
        public TipoResponse TipoAnuidade { get; set; }
        public TipoDescricaoResponse TipoModalidade { get; set; }
        public double ValorAnuidade { get; set; }
        public double ValorLimiteCredito { get; set; }
    }

    public partial class ConfiguracaoCreditoDetalhesProposta
    {
        public long ValorMaximo { get; set; }
        public long ValorMinimo { get; set; }
    }

    public partial class ListaTiposLiquidacaoDetalhesProposta
    {
        public List<TipoLiquidacaoDetalhesProposta> TipoLiquidacao { get; set; }
    }

    public partial class TipoLiquidacaoDetalhesProposta
    {
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public bool IndSelecao { get; set; }
    }

    public partial class PropostaCartao
    {
        public TipoLiquidacaoDetalhesResponse TipoLiquidacao { get; set; }
        public Emitente Emitente { get; set; }
        public TipoDescricaoResponse StatusProposta { get; set; }
        public DateTime DataCriacao { get; set; }
        public int QtDiasEntregaPrevista { get; set; }
    }

    public partial class Emitente
    {
        public string IdentificadorReceitaFederal { get; set; }
        public TipoResponse Tipo { get; set; }
    }

    public partial class TipoLiquidacaoDetalhesResponse
    {
        public int? Codigo { get; set; }
        public TipoLiquidacaoDescricao Descricao { get; set; }
    }

    public partial class TipoLiquidacaoDescricao
    {
        public string Descricao { get; set; }
    }

    public partial class EmbossadoraDetalhesResponse
    {
        public string RazaoSocialOuNome { get; set; }
    }
}