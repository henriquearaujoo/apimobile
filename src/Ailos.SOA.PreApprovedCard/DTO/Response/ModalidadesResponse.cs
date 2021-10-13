using Ailos.SOA.Common.Card.Response;
using System;
using System.Collections.Generic;

namespace Ailos.SOA.PreApprovedCard.DTO.Response
{
    public class ModalidadesResponse
    {
        public IEnumerable<CartaoModalidadeResponse> Cartoes { get; set; }
        public IEnumerable<FormaPagamentoCartaoResponse> FormasPagamento { get; set; }
        public NomesPlasticoCartaoResponse NomesCartao { get; set; }
    }

    public class CartaoModalidadeResponse
    {
        public int Codigo { get; set; }

        public string Nome { get; set; }
        public Uri Imagem { get; set; }

        public IEnumerable<int> DiasVencimento { get; set; }

        public IEnumerable<string> Beneficios { get; set; }

        public CartaoAnuidadeResponse Anuidade { get; set; }
    }
}