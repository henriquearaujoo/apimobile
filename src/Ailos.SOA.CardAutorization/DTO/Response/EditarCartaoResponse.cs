using Ailos.SOA.Common.Card.Response;
using Ailos.SOA.PreApprovedCard.DTO.Response;
using System.Collections.Generic;

namespace Ailos.SOA.CardAutorization.DTO.Response
{
    public class EditarCartaoResponse
    {
        public List<int> DiasVencimento { get; set; }

        public IEnumerable<FormaPagamentoCartaoResponse> FormasPagamento { get; set; }

        public NomesPlasticoCartaoResponse NomesCartao { get; set; }
    }
}