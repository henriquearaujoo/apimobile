using System;
using System.Collections.Generic;

namespace Ailos.SOA.DTO.Card.Response
{
    public partial class ObterListaPendenciasCartaoResponse
    {
        public ListaOperacoesPendencia ListaOperacoesPendencia { get; set; }
    }

    public partial class ListaOperacoesPendencia
    {
        public List<OperacaoPendencia> OperacaoPendencia { get; set; }
    }

    public partial class OperacaoPendencia
    {
        public OperacaoDigital OperacaoDigital { get; set; }
        public PropostaCartaoOperacaoPendencia PropostaCartao { get; set; }
        public CartaoOperacaoPendencia Cartao { get; set; }
    }

    public partial class CartaoOperacaoPendencia
    {
        public TipoDescricaoOperacaoPendencia TipoModalidade { get; set; }
        public long ValorLimiteCredito { get; set; }
    }

    public partial class OperacaoDigital
    {
        public DateTime DataRegistro { get; set; }
        public TipoDescricaoOperacaoPendencia Status { get; set; }
    }

    public partial class PropostaCartaoOperacaoPendencia
    {
        public string IdentificadorProposta { get; set; }
        public DateTime DataCriacao { get; set; }
    }

    public partial class TipoDescricaoOperacaoPendencia
    {
        public int? Codigo { get; set; }

        public string Descricao { get; set; }
    }
}