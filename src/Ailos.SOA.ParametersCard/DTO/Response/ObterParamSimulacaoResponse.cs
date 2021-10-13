using Ailos.SOA.Common.Response;
using System.Collections.Generic;

namespace Ailos.SOA.ParametersCard.DTO.Response
{
    public partial class ObterParamSimulacaoResponse
    {
        public ListaProdutosCredito ListaProdutosCredito { get; set; }
    }

    public partial class ListaProdutosCredito
    {
        public List<ProdutoCredito> ProdutoCredito { get; set; }
    }

    public partial class ProdutoCredito
    {
        public TipoResponse Cooperativa { get; set; }
        public Credito Credito { get; set; }
        public ProdutoCreditoConfiguracaoCredito ConfiguracaoCredito { get; set; }
        public ListaTiposLinhaCredito ListaTiposLinhaCredito { get; set; }
        public AutorizacaoPorLinhaCredito AutorizacaoPorLinhaCredito { get; set; }
    }

    public partial class AutorizacaoPorLinhaCredito
    {
        public ListaAutorizTipoPessoaPorLinhaCredito ListaAutorizTipoPessoaPorLinhaCredito { get; set; }
        public ListaAutorizCanaisPorLinhaCredito ListaAutorizCanaisPorLinhaCredito { get; set; }
    }

    public partial class ListaAutorizCanaisPorLinhaCredito
    {
        public List<AutorizCanalPorLinhaCredito> AutorizCanalPorLinhaCredito { get; set; }
    }

    public partial class AutorizCanalPorLinhaCredito
    {
        public CanalRelacionamentoParamSimulacao CanalRelacionamento { get; set; }
        public ConfiguracaoPessoaDigital ConfiguracaoPessoaDigital { get; set; }
    }

    public partial class CanalRelacionamentoParamSimulacao
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
    }

    public partial class ConfiguracaoPessoaDigital
    {
        public TipoDescricaoResponse CategoriaLimite { get; set; }
        public long ValorLimite { get; set; }
    }

    public partial class ListaAutorizTipoPessoaPorLinhaCredito
    {
        public List<PessoaParamSimulacao> Pessoa { get; set; }
    }

    public partial class PessoaParamSimulacao
    {
        public TipoResponse Tipo { get; set; }
    }

    public partial class ProdutoCreditoConfiguracaoCredito
    {
        public long QuantidadeMaxPropostas { get; set; }
        public long QuantidadeVariacParcelas { get; set; }
        public long TempoIntervaloEnvioPropostas { get; set; }
    }

    public partial class Credito
    {
        public Produto Produto { get; set; }
    }

    public partial class Produto
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string NomeAbreviado { get; set; }
    }

    public partial class ListaTiposLinhaCredito
    {
        public List<TipoLinhaCredito> TipoLinhaCredito { get; set; }
    }

    public partial class TipoLinhaCredito
    {
        public GarantiaContratoCredito GarantiaContratoCredito { get; set; }
        public TipoResponse FinalidadeCredito { get; set; }
        public LinhaCredito LinhaCredito { get; set; }
        public TipoLinhaCreditoConfiguracaoCredito ConfiguracaoCredito { get; set; }
        public PropostaContratoCredito PropostaContratoCredito { get; set; }
    }

    public partial class TipoLinhaCreditoConfiguracaoCredito
    {
        public long DiaLimiteDataVencimento { get; set; }
        public long DiasCarencia { get; set; }
        public long QuantidadeMaxParcelas { get; set; }
        public long ValorMaximo { get; set; }
    }

    public partial class GarantiaContratoCredito
    {
        public TipoDescricaoResponse Tipo { get; set; }
    }

    public partial class LinhaCredito
    {
        public long Codigo { get; set; }
        public string Descricao { get; set; }
        public LinhaCreditoTipo Tipo { get; set; }
    }

    public partial class LinhaCreditoTipo
    {
        public long Codigo { get; set; }
        public string Nome { get; set; }
    }

    public partial class PropostaContratoCredito
    {
        public bool GarantiaDeclarada { get; set; }
        public long PercExcedenteAprovSobreMax { get; set; }
        public long PercMercadoEValorAprovado { get; set; }
    }
}