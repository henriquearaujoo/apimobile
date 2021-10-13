using Ailos.SOA.Common;
using Ailos.SOA.Common.Card;
using Ailos.SOA.Common.Card.Response;
using System;
using System.Collections.Generic;

namespace Ailos.SOA.PreApprovedCard.DTO.Response
{
    public class DetalhesPropostaResponse
    {
        public string NumeroProposta { get; set; }

        public DetalhesModalidadeResponse Modalidade { get; set; }

        public DateTime DataContratacao { get; set; }

        public double LimiteContratado { get; set; }

        public int DiaVencimento { get; set; }

        public FormaPagamentoCartaoResponse FormaPagamento { get; set; }

        public int PrevisaoEntrega { get; set; }

        public string Endereco { get; set; }

        public string NomeTitular { get; set; }

        public string NomeEmpresa { get; set; }

        public StatusCartao Status { get; set; }

        public List<AppDetails> Detalhes { get; set; }
    }

    public class DetalhesModalidadeResponse
    {
        public string Nome { get; set; }

        public Uri Imagem { get; set; }

        public IEnumerable<string> Beneficios { get; set; }

        public CartaoAnuidadeResponse Anuidade { get; set; }
    }
}